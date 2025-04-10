using System.Text;
using System.Xml;
using OFXSDK.Core.Models;
using OFXSDK.Core.Models.Banking;
using OFXSDK.Core.Models.CreditCard;
using OFXSDK.Core.Models.Investment;
using OFXSDK.Core.Models.SignOn;
using OFXSDK.Parsing.Interfaces;

namespace OFXSDK.Parsing.Parsers;

/// <summary>
/// Parser implementation for OFX 2.x format (XML-based)
/// </summary>
public class OFX2Parser : IOFXParser {
    /// <summary>
    /// Parse OFX data from a string
    /// </summary>
    public OFXDocument Parse(string ofxData) {
        if (string.IsNullOrWhiteSpace(ofxData)) {
            throw new ArgumentException("OFX data cannot be null or empty", nameof(ofxData));
        }

        // Split headers and content
        var (Headers, Content) = SplitHeaderAndContent(ofxData);
        var headers = ParseHeaders(Headers);

        // Create OFX document with the parsed headers
        var document = new OFXDocument {
            Header = headers
        };

        try {
            // Process the XML content
            using var stringReader = new StringReader(Content);
            using var reader = XmlReader.Create(stringReader,
                new XmlReaderSettings {
                    DtdProcessing = DtdProcessing.Ignore,
                    XmlResolver = null,
                    IgnoreWhitespace = true,
                    IgnoreComments = true
                });

            // Parse the XML content into the document
            ParseXmlContent(reader, document);
        } catch (XmlException ex) {
            throw new FormatException("Invalid OFX 2.0 XML format", ex);
        }

        return document;
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
        ArgumentNullException.ThrowIfNull(stream, nameof(stream));

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
        ArgumentNullException.ThrowIfNull(stream, nameof(stream));

        using var reader = new StreamReader(stream, Encoding.UTF8, true, 4096, true);
        var ofxData = await reader.ReadToEndAsync();
        stream.Position = 0; // Reset the stream position
        return Parse(ofxData);
    }

    /// <summary>
    /// Split the OFX headers from the content
    /// </summary>
    private static (string Headers, string Content) SplitHeaderAndContent(string ofxData) {
        var xmlDeclarationIndex = ofxData.IndexOf("<?xml");
        if (xmlDeclarationIndex < 0) {
            xmlDeclarationIndex = ofxData.IndexOf("<OFX>");
            if (xmlDeclarationIndex < 0) {
                xmlDeclarationIndex = ofxData.IndexOf("<ofx>");
            }
        }

        if (xmlDeclarationIndex < 0) {
            return (string.Empty, ofxData);
        }

        var headers = ofxData[..xmlDeclarationIndex].Trim();
        var content = ofxData[xmlDeclarationIndex..];

        return (headers, content);
    }

    /// <summary>
    /// Parse OFX header lines into an OFXHeader object
    /// </summary>
    private static OFXHeader ParseHeaders(string headerText) {
        var header = new OFXHeader();

        if (string.IsNullOrWhiteSpace(headerText)) {
            // Set default values for OFX 2.0
            header.Version = "200";
            header.DataType = "OFXSGML";
            header.FormatVersion = "202";
            header.Security = "NONE";
            header.Encoding = "UTF-8";
            header.Charset = "1252";
            header.Compression = "NONE";
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

    /// <summary>
    /// Parse the XML content of the OFX document
    /// </summary>
    private static void ParseXmlContent(XmlReader reader, OFXDocument document) {
        // Move to the root element
        reader.MoveToContent();

        // Create a DOM for easier navigation
        var doc = new XmlDocument {
            XmlResolver = null
        };
        doc.Load(reader);

        // Get the OFX root element
        XmlNode? rootNode = doc.DocumentElement ?? throw new FormatException("Invalid OFX format: missing root element");

        // Parse sign-on response
        XmlNode? signonNode = rootNode.SelectSingleNode("//SIGNONMSGSRSV1/SONRS");
        if (signonNode != null) {
            document.SignOn = ParseSignOnResponse(signonNode);
        }

        // Parse banking response
        XmlNode? bankingNode = rootNode.SelectSingleNode("//BANKMSGSRSV1/STMTTRNRS");
        if (bankingNode != null) {
            document.Banking = ParseBankingResponse(bankingNode);
        }

        // Parse credit card response
        XmlNode? creditCardNode = rootNode.SelectSingleNode("//CREDITCARDMSGSRSV1/CCSTMTTRNRS");
        if (creditCardNode != null) {
            document.CreditCard = ParseCreditCardResponse(creditCardNode);
        }

        // Parse investment response
        XmlNode? investmentNode = rootNode.SelectSingleNode("//INVSTMTMSGSRSV1/INVSTMTRS");
        if (investmentNode != null) {
            document.Investment = ParseInvestmentResponse(investmentNode);
        }
    }

    /// <summary>
    /// Parse the sign-on response section
    /// </summary>
    private static SignOnResponseMessageSet ParseSignOnResponse(XmlNode signonNode) {
        var signOn = new SignOnResponseMessageSet();

        // Parse status
        var statusNode = signonNode.SelectSingleNode("STATUS");
        if (statusNode != null) {
            signOn.Status = new Status {
                Code = int.Parse(GetNodeValue(statusNode, "CODE") ?? "0"),
                Severity = GetNodeValue(statusNode, "SEVERITY") ?? "INFO",
                Message = GetNodeValue(statusNode, "MESSAGE") ?? string.Empty
            };
        }

        // Parse other sign-on elements
        signOn.ServerDate = DateTime.Parse(GetNodeValue(signonNode, "DTSERVER") ?? DateTime.Now.ToString("yyyyMMddHHmmss"));
        signOn.Language = GetNodeValue(signonNode, "LANGUAGE") ?? "ENG";
        signOn.InstitutionName = GetNodeValue(signonNode, "FI/ORG") ?? string.Empty;
        signOn.InstitutionId = GetNodeValue(signonNode, "FI/FID") ?? string.Empty;

        return signOn;
    }

    /// <summary>
    /// Parse the banking response section
    /// </summary>
    private static BankingResponseMessageSet ParseBankingResponse(XmlNode bankingNode) {
        var banking = new BankingResponseMessageSet();

        // Get statement response
        var stmtNode = bankingNode.SelectSingleNode("STMTRS");
        if (stmtNode == null) {
            return banking;
        }

        // Parse account info
        var acctNode = stmtNode.SelectSingleNode("BANKACCTFROM");
        if (acctNode != null) {
            banking.AccountInfo = new BankAccountInfo {
                BankId = GetNodeValue(acctNode, "BANKID"),
                AccountNumber = GetNodeValue(acctNode, "ACCTID"),
                AccountType = GetNodeValue(acctNode, "ACCTTYPE")
            };
        }

        // Create statement response
        banking.Statement = new StatementResponse {
            CurrencyCode = GetNodeValue(stmtNode, "CURDEF") ?? "USD",
            StartDate = ParseDateValue(GetNodeValue(stmtNode, "BANKTRANLIST/DTSTART")),
            EndDate = ParseDateValue(GetNodeValue(stmtNode, "BANKTRANLIST/DTEND"))
        };

        // Parse balance info
        var ledgerBalNode = stmtNode.SelectSingleNode("LEDGERBAL");
        var availBalNode = stmtNode.SelectSingleNode("AVAILBAL");

        if (ledgerBalNode != null || availBalNode != null) {
            banking.Statement.Balance = new BalanceInfo();

            if (ledgerBalNode != null) {
                banking.Statement.Balance.LedgerBalance = decimal.Parse(GetNodeValue(ledgerBalNode, "BALAMT") ?? "0");
                banking.Statement.Balance.LedgerBalanceDate = ParseDateValue(GetNodeValue(ledgerBalNode, "DTASOF"));
            }

            if (availBalNode != null) {
                banking.Statement.Balance.AvailableBalance = decimal.Parse(GetNodeValue(availBalNode, "BALAMT") ?? "0");
                banking.Statement.Balance.AvailableBalanceDate = ParseDateValue(GetNodeValue(availBalNode, "DTASOF"));
            }
        }

        // Parse transactions
        var transNodes = stmtNode.SelectNodes("BANKTRANLIST/STMTTRN");
        if (transNodes != null) {
            foreach (XmlNode transNode in transNodes) {
                var trans = new Transaction {
                    TransactionId = GetNodeValue(transNode, "FITID"),
                    Type = GetNodeValue(transNode, "TRNTYPE"),
                    DatePosted = ParseDateValue(GetNodeValue(transNode, "DTPOSTED")),
                    TransactionDate = ParseDateValue(GetNodeValue(transNode, "DTUSER") ?? GetNodeValue(transNode, "DTPOSTED")),
                    Amount = decimal.Parse(GetNodeValue(transNode, "TRNAMT") ?? "0"),
                    Name = GetNodeValue(transNode, "NAME"),
                    Memo = GetNodeValue(transNode, "MEMO"),
                    CheckNumber = GetNodeValue(transNode, "CHECKNUM")
                };

                banking.Statement.Transactions.Add(trans);
            }
        }

        return banking;
    }

    /// <summary>
    /// Parse the credit card response section
    /// </summary>
    private static CreditCardResponseMessageSet ParseCreditCardResponse(XmlNode ccNode) {
        var creditCard = new CreditCardResponseMessageSet();

        // Get statement response
        var stmtNode = ccNode.SelectSingleNode("CCSTMTRS");
        if (stmtNode == null) {
            return creditCard;
        }

        // Parse account info
        var acctNode = stmtNode.SelectSingleNode("CCACCTFROM");
        if (acctNode != null) {
            creditCard.AccountInfo = new CreditCardAccountInfo {
                AccountNumber = GetNodeValue(acctNode, "ACCTID")
            };
        }

        // Create statement response
        creditCard.Statement = new CreditCardStatementResponse {
            CurrencyCode = GetNodeValue(stmtNode, "CURDEF") ?? "USD",
            StartDate = ParseDateValue(GetNodeValue(stmtNode, "CCBANKTRANLIST/DTSTART")),
            EndDate = ParseDateValue(GetNodeValue(stmtNode, "CCBANKTRANLIST/DTEND"))
        };

        // Parse balance info
        var ledgerBalNode = stmtNode.SelectSingleNode("LEDGERBAL");
        var availBalNode = stmtNode.SelectSingleNode("AVAILBAL");

        if (ledgerBalNode != null || availBalNode != null) {
            creditCard.Statement.Balance = new CreditCardBalanceInfo();

            if (ledgerBalNode != null) {
                creditCard.Statement.Balance.CurrentBalance = decimal.Parse(GetNodeValue(ledgerBalNode, "BALAMT") ?? "0");
                creditCard.Statement.Balance.CurrentBalanceDate = ParseDateValue(GetNodeValue(ledgerBalNode, "DTASOF"));
            }

            if (availBalNode != null) {
                creditCard.Statement.Balance.AvailableCredit = decimal.Parse(GetNodeValue(availBalNode, "BALAMT") ?? "0");
                creditCard.Statement.Balance.AvailableCreditDate = ParseDateValue(GetNodeValue(availBalNode, "DTASOF"));
            }
        }

        // Parse transactions
        var transNodes = stmtNode.SelectNodes("CCBANKTRANLIST/STMTTRN");
        if (transNodes != null) {
            foreach (XmlNode transNode in transNodes) {
                var trans = new Transaction {
                    TransactionId = GetNodeValue(transNode, "FITID"),
                    Type = GetNodeValue(transNode, "TRNTYPE"),
                    DatePosted = ParseDateValue(GetNodeValue(transNode, "DTPOSTED")),
                    TransactionDate = ParseDateValue(GetNodeValue(transNode, "DTUSER") ?? GetNodeValue(transNode, "DTPOSTED")),
                    Amount = decimal.Parse(GetNodeValue(transNode, "TRNAMT") ?? "0"),
                    Name = GetNodeValue(transNode, "NAME"),
                    Memo = GetNodeValue(transNode, "MEMO")
                };

                creditCard.Statement.Transactions.Add(trans);
            }
        }

        return creditCard;
    }

    /// <summary>
    /// Parse the investment response section
    /// </summary>
    private static InvestmentResponseMessageSet ParseInvestmentResponse(XmlNode investmentNode) {
        var investment = new InvestmentResponseMessageSet();

        // Get account info
        var acctNode = investmentNode.SelectSingleNode("INVACCTFROM");
        if (acctNode != null) {
            investment.AccountInfo = new InvestmentAccountInfo {
                AccountNumber = GetNodeValue(acctNode, "ACCTID"),
                BrokerId = GetNodeValue(acctNode, "BROKERID")
            };
        }

        // Get statement response
        var stmtNode = investmentNode.SelectSingleNode("INVSTMTRS");
        if (stmtNode == null) {
            return investment;
        }

        // Create statement response
        investment.Statement = new InvestmentStatementResponse {
            CurrencyCode = GetNodeValue(stmtNode, "CURDEF") ?? "USD",
            StartDate = ParseDateValue(GetNodeValue(stmtNode, "DTSTART")),
            EndDate = ParseDateValue(GetNodeValue(stmtNode, "DTEND"))
        };

        // Parse balance info
        var balNode = stmtNode.SelectSingleNode("INVBAL");
        if (balNode != null) {
            investment.Statement.BalanceInfo = new InvestmentBalanceInfo {
                AvailableCash = decimal.Parse(GetNodeValue(balNode, "AVAILCASH") ?? "0"),
                MarginBalance = decimal.Parse(GetNodeValue(balNode, "MARGINBAL") ?? "0"),
                ShortBalance = decimal.Parse(GetNodeValue(balNode, "SHORTBAL") ?? "0"),
                BalanceDate = ParseDateValue(GetNodeValue(balNode, "DTASOF"))
            };
        }

        // Parse positions
        var posNodes = stmtNode.SelectNodes("POSLIST/POS");
        if (posNodes != null) {
            foreach (XmlNode posNode in posNodes) {
                var position = new InvestmentPosition {
                    PositionType = GetNodeValue(posNode, "POSTYPE"),
                    Units = decimal.Parse(GetNodeValue(posNode, "UNITS") ?? "0"),
                    UnitPrice = decimal.Parse(GetNodeValue(posNode, "UNITPRICE") ?? "0"),
                    MarketValue = decimal.Parse(GetNodeValue(posNode, "MKTVAL") ?? "0"),
                    PositionDate = ParseDateValue(GetNodeValue(posNode, "DTPOS"))
                };

                // Parse security info
                var secNode = posNode.SelectSingleNode("SECID");
                if (secNode != null) {
                    position.Security = new SecurityInfo {
                        UniqueId = GetNodeValue(secNode, "UNIQUEID"),
                        UniqueIdType = GetNodeValue(secNode, "UNIQUEIDTYPE")
                    };
                }

                investment.Statement.Positions.Add(position);
            }
        }

        // Parse transactions
        var tranNodes = stmtNode.SelectNodes("INVTRANLIST/INVTRAN");
        if (tranNodes != null) {
            foreach (XmlNode tranNode in tranNodes) {
                var transaction = new InvestmentTransaction {
                    TransactionId = GetNodeValue(tranNode, "FITID"),
                    TransactionType = GetNodeValue(tranNode, "INVTRNTYPE"),
                    DatePosted = ParseDateValue(GetNodeValue(tranNode, "DTTRADE")),
                    Amount = decimal.Parse(GetNodeValue(tranNode, "TRNAMT") ?? "0"),
                    Memo = GetNodeValue(tranNode, "MEMO")
                };

                // Parse security info
                var secNode = tranNode.SelectSingleNode("SECID");
                if (secNode != null) {
                    transaction.Security = new SecurityInfo {
                        UniqueId = GetNodeValue(secNode, "UNIQUEID"),
                        UniqueIdType = GetNodeValue(secNode, "UNIQUEIDTYPE")
                    };
                }

                investment.Statement.Transactions.Add(transaction);
            }
        }

        return investment;
    }

    /// <summary>
    /// Get the text value of an XML node
    /// </summary>
    private static string GetNodeValue(XmlNode parentNode, string xpath) {
        var node = parentNode.SelectSingleNode(xpath);
        return node?.InnerText ?? string.Empty;
    }

    /// <summary>
    /// Parse OFX date value in format YYYYMMDDHHMMSS
    /// </summary>
    private static DateTime ParseDateValue(string dateString) {
        if (string.IsNullOrEmpty(dateString)) {
            return DateTime.Now;
        }

        // Handle timezone indicator if present
        if (dateString.Contains('[')) {
            dateString = dateString[..dateString.IndexOf('[')];
        }

        // Parse based on length
        if (dateString.Length >= 14) {
            // Has time component: YYYYMMDDHHMMSS
            return new DateTime(
                int.Parse(dateString[..4]),   // Year
                int.Parse(dateString.Substring(4, 2)),   // Month
                int.Parse(dateString.Substring(6, 2)),   // Day
                int.Parse(dateString.Substring(8, 2)),   // Hour
                int.Parse(dateString.Substring(10, 2)),  // Minute
                int.Parse(dateString.Substring(12, 2))); // Second
        } else if (dateString.Length >= 8) {
            // Date only: YYYYMMDD
            return new DateTime(
                int.Parse(dateString[..4]),   // Year
                int.Parse(dateString.Substring(4, 2)),   // Month
                int.Parse(dateString.Substring(6, 2)));  // Day
        }

        // Fallback
        return DateTime.Parse(dateString);
    }
}