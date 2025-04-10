using OFXSDK;

namespace SimpleParser;

class Program {
    static async Task Main(string[] args) {
        Console.WriteLine("OFX Simple Parser Example");
        Console.WriteLine("=========================");
        Console.WriteLine();

        try {
            // Check if a file was provided as a command line argument
            string? filePath = null;
            if (args.Length > 0) {
                filePath = args[0];
            } else {
                Console.Write("Enter path to OFX file: ");
                filePath = Console.ReadLine()?.Trim();
            }

            if (string.IsNullOrEmpty(filePath)) {
                Console.WriteLine("No file path provided. Exiting.");
                return;
            }

            if (!File.Exists(filePath)) {
                Console.WriteLine($"File not found: {filePath}");
                return;
            }

            // Create OFX client and parse the file
            var client = new OFXClient();
            var document = await client.ParseFileAsync(filePath);

            // Display basic document info
            Console.WriteLine();
            Console.WriteLine($"OFX Format Version: {document.Header.Version}");
            Console.WriteLine($"Parsed at: {document.ParsedAt}");

            // Display sign-on info
            if (document.SignOn != null) {
                Console.WriteLine();
                Console.WriteLine("Sign-On Information:");
                Console.WriteLine($"  Status Code: {document.SignOn.Status?.Code}");
                Console.WriteLine($"  Institution: {document.SignOn.InstitutionName}");
                Console.WriteLine($"  Server Date: {document.SignOn.ServerDate}");
                Console.WriteLine($"  Language: {document.SignOn.Language}");
            }

            // Display banking info
            if (document.Banking != null) {
                Console.WriteLine();
                Console.WriteLine("Banking Information:");

                var acct = document.Banking.AccountInfo;
                if (acct != null) {
                    Console.WriteLine($"  Account: {MaskAccountNumber(acct.AccountNumber)}");
                    Console.WriteLine($"  Type: {acct.AccountType}");
                    Console.WriteLine($"  Bank ID: {acct.BankId}");
                }

                var stmt = document.Banking.Statement;
                if (stmt != null) {
                    Console.WriteLine($"  Currency: {stmt.CurrencyCode}");
                    Console.WriteLine($"  Statement Period: {stmt.StartDate.ToShortDateString()} to {stmt.EndDate.ToShortDateString()}");

                    if (stmt.Balance != null) {
                        Console.WriteLine($"  Ledger Balance: {stmt.Balance.LedgerBalance:C} as of {stmt.Balance.LedgerBalanceDate.ToShortDateString()}");
                        Console.WriteLine($"  Available Balance: {stmt.Balance.AvailableBalance:C} as of {stmt.Balance.AvailableBalanceDate.ToShortDateString()}");
                    }

                    Console.WriteLine($"  Transaction Count: {stmt.Transactions.Count}");

                    // Display transaction summary
                    if (stmt.Transactions.Count > 0) {
                        Console.WriteLine();
                        Console.WriteLine("Transaction Summary:");
                        Console.WriteLine("  Date       | Amount    | Description");
                        Console.WriteLine("  -----------+-----------+-------------------------");

                        // Only show up to 10 transactions to keep the output clean
                        int maxDisplayCount = Math.Min(10, stmt.Transactions.Count);
                        for (int i = 0; i < maxDisplayCount; i++) {
                            var trans = stmt.Transactions[i];
                            Console.WriteLine($"  {trans.DatePosted.ToShortDateString(),-10} | {trans.Amount,9:C} | {TruncateString(trans.Name ?? trans.Memo, 25)}");
                        }

                        if (stmt.Transactions.Count > maxDisplayCount) {
                            Console.WriteLine($"  ... and {stmt.Transactions.Count - maxDisplayCount} more transactions");
                        }
                    }
                }
            }

            // Display credit card info
            if (document.CreditCard != null) {
                Console.WriteLine();
                Console.WriteLine("Credit Card Information:");

                var acct = document.CreditCard.AccountInfo;
                if (acct != null) {
                    Console.WriteLine($"  Account: {MaskAccountNumber(acct.AccountNumber)}");
                    Console.WriteLine($"  Description: {acct.Description}");
                }

                var stmt = document.CreditCard.Statement;
                if (stmt != null) {
                    Console.WriteLine($"  Currency: {stmt.CurrencyCode}");
                    Console.WriteLine($"  Statement Period: {stmt.StartDate.ToShortDateString()} to {stmt.EndDate.ToShortDateString()}");

                    if (stmt.Balance != null) {
                        Console.WriteLine($"  Current Balance: {stmt.Balance.CurrentBalance:C} as of {stmt.Balance.CurrentBalanceDate.ToShortDateString()}");
                    }

                    if (stmt.PaymentDueDate.HasValue) {
                        Console.WriteLine($"  Payment Due: {stmt.MinimumPaymentDue:C} by {stmt.PaymentDueDate.Value.ToShortDateString()}");
                    }

                    Console.WriteLine($"  Transaction Count: {stmt.Transactions.Count}");

                    // Display transaction summary
                    if (stmt.Transactions.Count > 0) {
                        Console.WriteLine();
                        Console.WriteLine("Transaction Summary:");
                        Console.WriteLine("  Date       | Amount    | Description");
                        Console.WriteLine("  -----------+-----------+-------------------------");

                        // Only show up to 10 transactions to keep the output clean
                        int maxDisplayCount = Math.Min(10, stmt.Transactions.Count);
                        for (int i = 0; i < maxDisplayCount; i++) {
                            var trans = stmt.Transactions[i];
                            Console.WriteLine($"  {trans.DatePosted.ToShortDateString(),-10} | {trans.Amount,9:C} | {TruncateString(trans.Name ?? trans.Memo, 25)}");
                        }

                        if (stmt.Transactions.Count > maxDisplayCount) {
                            Console.WriteLine($"  ... and {stmt.Transactions.Count - maxDisplayCount} more transactions");
                        }
                    }
                }
            }
        } catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
            if (ex.InnerException != null) {
                Console.WriteLine($"Inner Error: {ex.InnerException.Message}");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    /// <summary>
    /// Masks an account number for display, showing only the last 4 digits
    /// </summary>
    static string MaskAccountNumber(string accountNumber) {
        if (string.IsNullOrEmpty(accountNumber)) {
            return string.Empty;
        }

        if (accountNumber.Length <= 4) {
            return accountNumber;
        }

        return new string('*', accountNumber.Length - 4) + accountNumber.Substring(accountNumber.Length - 4);
    }

    /// <summary>
    /// Truncates a string to a specified length
    /// </summary>
    static string TruncateString(string input, int maxLength) {
        if (string.IsNullOrEmpty(input)) {
            return string.Empty;
        }

        if (input.Length <= maxLength) {
            return input;
        }

        return input.Substring(0, maxLength - 3) + "...";
    }
}