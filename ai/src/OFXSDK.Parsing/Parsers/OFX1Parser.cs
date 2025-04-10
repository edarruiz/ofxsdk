using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using OFXSDK.Core.Models;
using OFXSDK.Core.Models.Banking;
using OFXSDK.Core.Models.CreditCard;
using OFXSDK.Core.Models.Investment;
using OFXSDK.Core.Models.SignOn;
using OFXSDK.Parsing.Interfaces;

namespace OFXSDK.Parsing.Parsers;

/// <summary>
/// Parser implementation for OFX 1.x format (SGML-based)
/// </summary>
public class OFX1Parser : IOFXParser {
    /// <summary>
    /// Parse OFX data from a string
    /// </summary>
    public OFXDocument Parse(string ofxData) {
        if (string.IsNullOrWhiteSpace(ofxData)) {
            throw new ArgumentException("OFX data cannot be null or empty", nameof(ofxData));
        }

        // Split headers and content
        var parts = SplitHeaderAndContent(ofxData);
        var headers = ParseHeaders(parts.Headers);

        // Create OFX document with the parsed headers
        var document = new OFXDocument {
            Header = headers
        };

        // Process the SGML content
        string xmlContent = ConvertSgmlToXml(parts.Content);

        try {
            XmlDocument xmlDoc = new();
            xmlDoc.LoadXml(xmlContent);

            // Parse Sign-On Message Set
            var signOnNode = xmlDoc.SelectSingleNode("//SIGNONMSGSRSV1");
            if (signOnNode != null) {
                document.SignOn = ParseSignOnResponse(signOnNode);
            }

            // Parse Banking Message Set
            var bankMsgsRsV1Node = xmlDoc.SelectSingleNode("//BANKMSGSRSV1");
            if (bankMsgsRsV1Node != null) {
                document.Banking = ParseBankingResponse(bankMsgsRsV1Node);
            }

            // Parse Credit Card Message Set
            var ccMsgsRsV1Node = xmlDoc.SelectSingleNode("//CREDITCARDMSGSRSV1");
            if (ccMsgsRsV1Node != null) {
                document.CreditCard = ParseCreditCardResponse(ccMsgsRsV1Node);
            }

            // Parse Investment Message Set
            var invMsgsRsV1Node = xmlDoc.SelectSingleNode("//INVSTMTMSGSRSV1");
            if (invMsgsRsV1Node != null) {
                document.Investment = ParseInvestmentResponse(invMsgsRsV1Node);
            }
        } catch (XmlException ex) {
            throw new InvalidOperationException("Error parsing OFX content as XML", ex);
        }

        return document;
    }

    /// <summary>
    /// Converts SGML-formatted OFX data to a more XML-like structure
    /// </summary>
    private static string ConvertSgmlToXml(string sgmlContent) {
        // Add missing closing tags (very basic implementation)
        sgmlContent = Regex.Replace(sgmlContent, "<([A-Z]+)>([^<]+)", "<$1>$2</$1>");

        // Handle attribute values without quotes (very basic implementation)
        sgmlContent = Regex.Replace(sgmlContent, "([A-Z]+)=([^\\s>]+)", "$1=\"$2\"");

        // Remove SGML header if present
        sgmlContent = Regex.Replace(sgmlContent, @"OFXHEADER:.*", "");
        sgmlContent = Regex.Replace(sgmlContent, @"DATA:.*", "");
        sgmlContent = Regex.Replace(sgmlContent, @"VERSION:.*", "");
        sgmlContent = Regex.Replace(sgmlContent, @"SECURITY:.*", "");
        sgmlContent = Regex.Replace(sgmlContent, @"ENCODING:.*", "");
        sgmlContent = Regex.Replace(sgmlContent, @"CHARSET:.*", "");
        sgmlContent = Regex.Replace(sgmlContent, @"COMPRESSION:.*", "");
        sgmlContent = Regex.Replace(sgmlContent, @"OLDFILEUID:.*", "");
        sgmlContent = Regex.Replace(sgmlContent, @"NEWFILEUID:.*", "");

        return $"<OFX>{sgmlContent}</OFX>";
    }

    /// <summary>
    /// Parse the sign-on response section
    /// </summary>
    private SignOnResponseMessageSet ParseSignOnResponse(XmlNode signonNode) {
        var signOn = new SignOnResponseMessageSet();

        // Parse status
        var statusNode = signonNode.SelectSingleNode("STATUS");
        if (statusNode != null) {
            // Fully qualify the Status class to avoid ambiguity
            signOn.Status = new Status {
                Code = int.Parse(statusNode.SelectSingleNode("CODE")?.InnerText ?? "0"),
                Severity = statusNode.SelectSingleNode("SEVERITY")?.InnerText ?? "INFO",
                Message = statusNode.SelectSingleNode("MESSAGE")?.InnerText ?? string.Empty
            };
            signOn.Status = new Status {
                Code = int.Parse(statusNode.SelectSingleNode("CODE")?.InnerText ?? "0"),
                Severity = statusNode.SelectSingleNode("SEVERITY")?.InnerText ?? "INFO",
                Message = statusNode.SelectSingleNode("MESSAGE")?.InnerText ?? string.Empty
            };
        }

        // Parse other sign-on elements
        signOn.ServerDate = DateTime.Parse(signonNode.SelectSingleNode("DTSERVER")?.InnerText ?? DateTime.Now.ToString("yyyyMMddHHmmss"));
        signOn.Language = signonNode.SelectSingleNode("LANGUAGE")?.InnerText ?? "ENG";
        signOn.InstitutionName = signonNode.SelectSingleNode("FI/ORG")?.InnerText ?? string.Empty;
        signOn.InstitutionId = signonNode.SelectSingleNode("FI/FID")?.InnerText ?? string.Empty;

        return signOn;
    }

    /// <summary>
    /// Parse the banking response section
    /// </summary>
    private static BankingResponseMessageSet ParseBankingResponse(XmlNode bankMsgsRsV1Node) {
        var banking = new BankingResponseMessageSet();

        // Parse account info
        var stmtAcctFromNode = bankMsgsRsV1Node.SelectSingleNode("STMTTRNRS/STMTRS/BANKACCTFROM");
        if (stmtAcctFromNode != null) {
            banking.AccountInfo = new BankAccountInfo {
                AccountNumber = stmtAcctFromNode.SelectSingleNode("ACCTID")?.InnerText ?? string.Empty,
                AccountType = stmtAcctFromNode.SelectSingleNode("ACCTTYPE")?.InnerText ?? string.Empty,
                BankId = stmtAcctFromNode.SelectSingleNode("BANKID")?.InnerText ?? string.Empty
            };
        }

        // Parse transactions
        var stmtTrnNodes = bankMsgsRsV1Node.SelectNodes("STMTTRNRS/STMTRS/BANKTRANLIST/STMTTRN");
        if (stmtTrnNodes != null) {
            foreach (XmlNode stmtTrnNode in stmtTrnNodes) {
                var transaction = new Transaction {
                    Type = stmtTrnNode.SelectSingleNode("TRNTYPE")?.InnerText ?? string.Empty,
                    DatePosted = DateTime.Parse(stmtTrnNode.SelectSingleNode("DTPOSTED")?.InnerText ?? DateTime.Now.ToString("yyyyMMddHHmmss")),
                    Amount = decimal.Parse(stmtTrnNode.SelectSingleNode("TRNAMT")?.InnerText ?? "0"),
                    TransactionId = stmtTrnNode.SelectSingleNode("FITID")?.InnerText ?? string.Empty,
                    Name = stmtTrnNode.SelectSingleNode("NAME")?.InnerText ?? string.Empty,
                    Memo = stmtTrnNode.SelectSingleNode("MEMO")?.InnerText ?? string.Empty
                };
                banking.Statement.Transactions.Add(transaction);
            }
        }

        return banking;
    }

    /// <summary>
    /// Parse the credit card response section
    /// </summary>
    private static CreditCardResponseMessageSet ParseCreditCardResponse(XmlNode ccMsgsRsV1Node) {
        var creditCard = new CreditCardResponseMessageSet();

        // Parse account info
        var ccAcctFromNode = ccMsgsRsV1Node.SelectSingleNode("CCSTMTTRNRS/CCSTMTRS/CCACCTFROM");
        if (ccAcctFromNode != null) {
            creditCard.AccountInfo = new CreditCardAccountInfo {
                AccountNumber = ccAcctFromNode.SelectSingleNode("ACCTID")?.InnerText ?? string.Empty
            };
        }

        // Parse transactions
        var ccStmtTrnNodes = ccMsgsRsV1Node.SelectNodes("CCSTMTTRNRS/CCSTMTRS/BANKTRANLIST/STMTTRN");
        if (ccStmtTrnNodes != null) {
            foreach (XmlNode ccStmtTrnNode in ccStmtTrnNodes) {
                var transaction = new Transaction {
                    Type = ccStmtTrnNode.SelectSingleNode("TRNTYPE")?.InnerText ?? string.Empty,
                    DatePosted = DateTime.Parse(ccStmtTrnNode.SelectSingleNode("DTPOSTED")?.InnerText ?? DateTime.Now.ToString("yyyyMMddHHmmss")),
                    Amount = decimal.Parse(ccStmtTrnNode.SelectSingleNode("TRNAMT")?.InnerText ?? "0"),
                    TransactionId = ccStmtTrnNode.SelectSingleNode("FITID")?.InnerText ?? string.Empty,
                    Name = ccStmtTrnNode.SelectSingleNode("NAME")?.InnerText ?? string.Empty,
                    Memo = ccStmtTrnNode.SelectSingleNode("MEMO")?.InnerText ?? string.Empty
                };
                creditCard.Statement.Transactions.Add(transaction);
            }
        }

        return creditCard;
    }

    /// <summary>
    /// Parse the investment response section
    /// </summary>
    private InvestmentResponseMessageSet ParseInvestmentResponse(XmlNode invMsgsRsV1Node) {
        var investment = new InvestmentResponseMessageSet();

        // TODO: Implement investment parsing logic here

        return investment;
    }

    /// <summary>
    /// Parse OFX data from a file
    /// </summary>
    public OFXDocument ParseFile(string filePath) {
        if (string.IsNullOrEmpty(filePath)) {
            throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
        }

        if (!File.Exists(filePath)) {
            throw new FileNotFoundException("OFX file not found", filePath);
        }

        var ofxData = File.ReadAllText(filePath);
        return Parse(ofxData);
    }

    /// <summary>
    /// Parse OFX data from a stream
    /// </summary>
    public OFXDocument Parse(Stream stream) {
        if (stream == null) {
            throw new ArgumentNullException(nameof(stream));
        }

        using var reader = new StreamReader(stream, Encoding.UTF8, true, 4096, true);
        var ofxData = reader.ReadToEnd();
        stream.Position = 0; // Reset the stream position
        return Parse(ofxData);
    }

    /// <summary>
    /// Asynchronously parse OFX data from a file
    /// </summary>
    public async Task<OFXDocument> ParseFileAsync(string filePath) {
        if (string.IsNullOrEmpty(filePath)) {
            throw new ArgumentException("File path cannot be null or empty", nameof(filePath));
        }

        if (!File.Exists(filePath)) {
            throw new FileNotFoundException("OFX file not found", filePath);
        }

        var ofxData = await File.ReadAllTextAsync(filePath);
        return Parse(ofxData);
    }

    /// <summary>
    /// Asynchronously parse OFX data from a stream
    /// </summary>
    public async Task<OFXDocument> ParseAsync(Stream stream) {
        if (stream == null) {
            throw new ArgumentNullException(nameof(stream));
        }

        using var reader = new StreamReader(stream, Encoding.UTF8, true, 4096, true);
        var ofxData = await reader.ReadToEndAsync();
        stream.Position = 0; // Reset the stream position
        return Parse(ofxData);
    }

    /// <summary>
    /// Split the OFX headers from the content
    /// </summary>
    private (string Headers, string Content) SplitHeaderAndContent(string ofxData) {
        var headerEndIndex = ofxData.IndexOf("<OFX>");
        if (headerEndIndex < 0) {
            headerEndIndex = ofxData.IndexOf("<ofx>");
        }

        if (headerEndIndex < 0) {
            return (string.Empty, ofxData);
        }

        var headers = ofxData.Substring(0, headerEndIndex).Trim();
        var content = ofxData.Substring(headerEndIndex);

        return (headers, content);
    }

    /// <summary>
    /// Parse OFX header lines into an OFXHeader object
    /// </summary>
    private static OFXHeader ParseHeaders(string headerText) {
        var header = new OFXHeader();

        if (string.IsNullOrWhiteSpace(headerText)) {
            return header;
        }

        var headerLines = headerText.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
        foreach (var line in headerLines) {
            var parts = line.Split(':', 2);
            if (parts.Length == 2) {
                var key = parts[0].Trim();
                var value = parts[1].Trim();

                switch (key.ToUpper()) {
                    case "OFXHEADER":
                        header.Version = value;
                        break;
                    case "DATA":
                        header.DataType = value;
                        break;
                    case "VERSION":
                        header.FormatVersion = value;
                        break;
                    case "SECURITY":
                        header.Security = value;
                        break;
                    case "ENCODING":
                        header.Encoding = value;
                        break;
                    case "CHARSET":
                        header.Charset = value;
                        break;
                    case "COMPRESSION":
                        header.Compression = value;
                        break;
                    case "OLDFILEUID":
                        header.OldFileUid = value;
                        break;
                    case "NEWFILEUID":
                        header.NewFileUid = value;
                        break;
                }
            }
        }

        return header;
    }
}