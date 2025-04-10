using OFXSDK;
using OFXSDK.Core.Models;
using OFXSDK.Validation.Validators;

namespace FullFeaturedClient;

class Program {
    static async Task Main(string[] args) {
        DisplayHeader();

        try {
            // Process command line arguments
            var options = ParseCommandLineArguments(args);

            if (!options.IsValid) {
                DisplayUsage();
                return;
            }

            if (options.ShowHelp) {
                DisplayUsage();
                return;
            }

            // Create OFX client with enhanced validation if requested
            var client = new OFXClient(new BasicOFXValidator());

            // Check if we're processing a single file or a directory
            if (options.IsDirectory) {
                await ProcessDirectoryAsync(client, options.Path, options.OutputPath, options.Validate);
            } else {
                await ProcessSingleFileAsync(client, options.Path, options.OutputPath, options.Validate);
            }
        } catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
            if (ex.InnerException != null) {
                Console.WriteLine($"Inner Error: {ex.InnerException.Message}");
            }
        }

        if (!Console.IsOutputRedirected) {
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    static void DisplayHeader() {
        Console.WriteLine("OFX Full-Featured Client Example");
        Console.WriteLine("================================");
        Console.WriteLine();
    }

    static void DisplayUsage() {
        Console.WriteLine("Usage: FullFeaturedClient [options] <file-or-directory-path>");
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("  -h, --help             Show this help message");
        Console.WriteLine("  -o, --output <path>    Specify output directory for reports");
        Console.WriteLine("  --no-validate          Skip OFX validation");
        Console.WriteLine();
        Console.WriteLine("Examples:");
        Console.WriteLine("  FullFeaturedClient statement.ofx");
        Console.WriteLine("  FullFeaturedClient -o C:\\Reports C:\\OFX\\Files");
        Console.WriteLine("  FullFeaturedClient --no-validate statement.ofx");
        Console.WriteLine();
    }

    static ProgramOptions ParseCommandLineArguments(string[] args) {
        var options = new ProgramOptions();

        if (args.Length == 0) {
            Console.Write("Enter path to OFX file or directory: ");
            options.Path = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(options.Path)) {
                return options;
            }
        } else {
            for (int i = 0; i < args.Length; i++) {
                string arg = args[i];

                if (arg.StartsWith('-') || arg.StartsWith("--")) {
                    switch (arg.ToLower()) {
                        case "-h":
                        case "--help":
                            options.ShowHelp = true;
                            break;

                        case "-o":
                        case "--output":
                            if (i + 1 < args.Length) {
                                options.OutputPath = args[++i];
                            }
                            break;

                        case "--no-validate":
                            options.Validate = false;
                            break;
                    }
                } else {
                    options.Path ??= arg;
                }
            }
        }

        // Validate path
        if (string.IsNullOrEmpty(options.Path)) {
            Console.WriteLine("No file or directory path specified.");
            return options;
        }

        if (!File.Exists(options.Path) && !Directory.Exists(options.Path)) {
            Console.WriteLine($"File or directory not found: {options.Path}");
            return options;
        }

        // Check if path is a directory
        options.IsDirectory = Directory.Exists(options.Path);

        // Create output directory if specified
        if (!string.IsNullOrEmpty(options.OutputPath) && !Directory.Exists(options.OutputPath)) {
            try {
                Directory.CreateDirectory(options.OutputPath);
            } catch (Exception ex) {
                Console.WriteLine($"Error creating output directory: {ex.Message}");
                return options;
            }
        }

        // Set option validity
        options.IsValid = true;

        return options;
    }

    static async Task ProcessSingleFileAsync(OFXClient client, string? filePath, string? outputPath, bool validate) {
        Console.WriteLine($"Processing file: {filePath}");

        // Parse the OFX file
        var document = await client.ParseFileAsync(filePath, validate);

        // Display summary
        DisplayDocumentSummary(document);

        // Generate report if output path is specified
        if (!string.IsNullOrEmpty(outputPath)) {
            string reportPath = Path.Combine(outputPath,
                $"{Path.GetFileNameWithoutExtension(filePath)}_report.txt");

            await GenerateReportAsync(document, reportPath);
            Console.WriteLine($"Report saved to: {reportPath}");
        }
    }

    static async Task ProcessDirectoryAsync(OFXClient client, string? directoryPath, string? outputPath, bool validate) {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(directoryPath, nameof(directoryPath));

        Console.WriteLine($"Processing directory: {directoryPath}");

        // Find all OFX files
        var ofxFiles = Directory.GetFiles(directoryPath, "*.ofx");
        if (ofxFiles.Length == 0) {
            Console.WriteLine("No OFX files found in the directory.");
            return;
        }

        Console.WriteLine($"Found {ofxFiles.Length} OFX file(s)");

        // Process each file
        int processedCount = 0;
        int errorCount = 0;

        foreach (var file in ofxFiles) {
            try {
                Console.WriteLine();
                Console.WriteLine($"Processing file {++processedCount} of {ofxFiles.Length}: {Path.GetFileName(file)}");

                // Parse the OFX file
                var document = await client.ParseFileAsync(file, validate);

                // Display summary
                DisplayDocumentSummary(document);

                // Generate report if output path is specified
                if (!string.IsNullOrEmpty(outputPath)) {
                    string reportPath = Path.Combine(outputPath,
                        $"{Path.GetFileNameWithoutExtension(file)}_report.txt");

                    await GenerateReportAsync(document, reportPath);
                    Console.WriteLine($"Report saved to: {reportPath}");
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error processing file: {ex.Message}");
                errorCount++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Processed {processedCount} file(s), {errorCount} error(s)");
    }

    static void DisplayDocumentSummary(OFXDocument document) {
        Console.WriteLine();
        Console.WriteLine($"OFX Version: {document.Header.Version}");

        if (document.SignOn != null) {
            Console.WriteLine($"Financial Institution: {document.SignOn.InstitutionName}");
            Console.WriteLine($"Server Date: {document.SignOn.ServerDate}");
        }

        if (document.Banking != null) {
            Console.WriteLine("Banking Information:");
            if (document.Banking.AccountInfo != null) {
                Console.WriteLine($"  Account: ****{document.Banking.AccountInfo.AccountNumber?[Math.Max(0, document.Banking.AccountInfo.AccountNumber.Length - 4)..]}");
                Console.WriteLine($"  Type: {document.Banking.AccountInfo.AccountType}");
            }

            if (document.Banking.Statement?.Transactions != null) {
                var txCount = document.Banking.Statement.Transactions.Count;
                var startDate = document.Banking.Statement.StartDate;
                var endDate = document.Banking.Statement.EndDate;

                Console.WriteLine($"  {txCount} transaction(s) from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}");

                if (document.Banking.Statement.Balance != null) {
                    Console.WriteLine($"  Ledger Balance: {document.Banking.Statement.Balance.LedgerBalance:C}");
                }
            }
        }

        if (document.CreditCard != null) {
            Console.WriteLine("Credit Card Information:");
            if (document.CreditCard.AccountInfo != null) {
                Console.WriteLine($"  Account: ****{document.CreditCard.AccountInfo.AccountNumber?[Math.Max(0, document.CreditCard.AccountInfo.AccountNumber.Length - 4)..]}");
            }

            if (document.CreditCard.Statement?.Transactions != null) {
                var txCount = document.CreditCard.Statement.Transactions.Count;
                var startDate = document.CreditCard.Statement.StartDate;
                var endDate = document.CreditCard.Statement.EndDate;

                Console.WriteLine($"  {txCount} transaction(s) from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}");

                if (document.CreditCard.Statement.Balance != null) {
                    Console.WriteLine($"  Current Balance: {document.CreditCard.Statement.Balance.CurrentBalance:C}");
                }
            }
        }

        Console.WriteLine();
    }

    static async Task GenerateReportAsync(OFXDocument document, string reportPath) {
        using var writer = new StreamWriter(reportPath);

        await writer.WriteLineAsync("OFX DOCUMENT REPORT");
        await writer.WriteLineAsync("=================");
        await writer.WriteLineAsync();

        await writer.WriteLineAsync($"Generated: {DateTime.Now}");
        await writer.WriteLineAsync($"OFX Version: {document.Header.Version}");
        await writer.WriteLineAsync($"Format Version: {document.Header.FormatVersion}");
        await writer.WriteLineAsync($"Data Type: {document.Header.DataType}");
        await writer.WriteLineAsync($"Encoding: {document.Header.Encoding}");
        await writer.WriteLineAsync();

        if (document.SignOn != null) {
            await writer.WriteLineAsync("SIGN-ON INFORMATION");
            await writer.WriteLineAsync("------------------");
            await writer.WriteLineAsync($"Status: {document.SignOn.Status?.Code} - {document.SignOn.Status?.Severity}");
            await writer.WriteLineAsync($"Server Date: {document.SignOn.ServerDate}");
            await writer.WriteLineAsync($"Institution: {document.SignOn.InstitutionName} (ID: {document.SignOn.InstitutionId})");
            await writer.WriteLineAsync($"Language: {document.SignOn.Language}");
            await writer.WriteLineAsync();
        }

        if (document.Banking != null && document.Banking.Statement != null) {
            await writer.WriteLineAsync("BANKING INFORMATION");
            await writer.WriteLineAsync("------------------");

            var acct = document.Banking.AccountInfo;
            if (acct != null) {
                await writer.WriteLineAsync($"Account: {acct.AccountNumber}");
                await writer.WriteLineAsync($"Type: {acct.AccountType}");
                await writer.WriteLineAsync($"Bank ID: {acct.BankId}");
                await writer.WriteLineAsync($"Description: {acct.Description}");
            }

            var stmt = document.Banking.Statement;
            await writer.WriteLineAsync($"Currency: {stmt.CurrencyCode}");
            await writer.WriteLineAsync($"Period: {stmt.StartDate.ToShortDateString()} to {stmt.EndDate.ToShortDateString()}");

            if (stmt.Balance != null) {
                await writer.WriteLineAsync($"Ledger Balance: {stmt.Balance.LedgerBalance:C} as of {stmt.Balance.LedgerBalanceDate}");
                await writer.WriteLineAsync($"Available Balance: {stmt.Balance.AvailableBalance:C} as of {stmt.Balance.AvailableBalanceDate}");
            }

            if (stmt.Transactions.Count > 0) {
                await writer.WriteLineAsync();
                await writer.WriteLineAsync("TRANSACTIONS");
                await writer.WriteLineAsync("-----------");
                await writer.WriteLineAsync($"{"Date",-12}{"Amount",12}  {"Description"}");
                await writer.WriteLineAsync(new string('-', 60));

                foreach (var tx in stmt.Transactions.OrderBy(t => t.DatePosted)) {
                    string description = !string.IsNullOrEmpty(tx.Name) ? tx.Name : tx.Memo;
                    await writer.WriteLineAsync($"{tx.DatePosted.ToShortDateString(),-12}{tx.Amount,12:C}  {description}");
                }
            }

            await writer.WriteLineAsync();
        }

        if (document.CreditCard != null && document.CreditCard.Statement != null) {
            await writer.WriteLineAsync("CREDIT CARD INFORMATION");
            await writer.WriteLineAsync("----------------------");

            var acct = document.CreditCard.AccountInfo;
            if (acct != null) {
                await writer.WriteLineAsync($"Account: {acct.AccountNumber}");
                await writer.WriteLineAsync($"Description: {acct.Description}");
            }

            var stmt = document.CreditCard.Statement;
            await writer.WriteLineAsync($"Currency: {stmt.CurrencyCode}");
            await writer.WriteLineAsync($"Period: {stmt.StartDate.ToShortDateString()} to {stmt.EndDate.ToShortDateString()}");

            if (stmt.Balance != null) {
                await writer.WriteLineAsync($"Current Balance: {stmt.Balance.CurrentBalance:C} as of {stmt.Balance.CurrentBalanceDate}");
            }

            if (stmt.PaymentDueDate.HasValue) {
                await writer.WriteLineAsync($"Payment Due: {stmt.MinimumPaymentDue:C} by {stmt.PaymentDueDate.Value.ToShortDateString()}");
            }

            if (stmt.Transactions.Count > 0) {
                await writer.WriteLineAsync();
                await writer.WriteLineAsync("TRANSACTIONS");
                await writer.WriteLineAsync("-----------");
                await writer.WriteLineAsync($"{"Date",-12}{"Amount",12}  {"Description"}");
                await writer.WriteLineAsync(new string('-', 60));

                foreach (var tx in stmt.Transactions.OrderBy(t => t.DatePosted)) {
                    string description = !string.IsNullOrEmpty(tx.Name) ? tx.Name : tx.Memo;
                    await writer.WriteLineAsync($"{tx.DatePosted.ToShortDateString(),-12}{tx.Amount,12:C}  {description}");
                }
            }

            await writer.WriteLineAsync();
        }
    }

    class ProgramOptions {
        public string? Path { get; set; }
        public string? OutputPath { get; set; }
        public bool IsDirectory { get; set; }
        public bool ShowHelp { get; set; }
        public bool Validate { get; set; } = true;
        public bool IsValid { get; set; }
    }
}