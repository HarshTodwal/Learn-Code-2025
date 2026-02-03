using BankingSystem.Interfaces;
using BankingSystem.Utilities;

namespace BankingSystem.UI
{
    public class MenuHandler
    {
        private readonly IAccountService _accountService;
        private readonly ITransactionService _transactionService;
        private readonly ILoanService _loanService;

        public MenuHandler(
            IAccountService accountService, 
            ITransactionService transactionService,
            ILoanService loanService)
        {
            _accountService = accountService;
            _transactionService = transactionService;
            _loanService = loanService;
        }

        public void ShowMainMenu()
        {
            bool running = true;

            while (running)
            {
                ConsoleHelper.DisplayHeader("BANKING SYSTEM - MAIN MENU");
                
                Console.WriteLine("1. Account Management");
                Console.WriteLine("2. Transactions");
                Console.WriteLine("3. Loan Management");
                Console.WriteLine("4. Exit");
                
                string choice = ConsoleHelper.ReadString("\nSelect an option: ");

                switch (choice)
                {
                    case "1":
                        ShowAccountMenu();
                        break;
                    case "2":
                        ShowTransactionMenu();
                        break;
                    case "3":
                        ShowLoanMenu();
                        break;
                    case "4":
                        running = false;
                        ConsoleHelper.DisplaySuccess("Thank you for using the Banking System!");
                        break;
                    default:
                        ConsoleHelper.DisplayError("Invalid option. Please try again.");
                        ConsoleHelper.PressEnterToContinue();
                        break;
                }
            }
        }

        private void ShowAccountMenu()
        {
            bool back = false;

            while (!back)
            {
                ConsoleHelper.DisplayHeader("ACCOUNT MANAGEMENT");
                
                Console.WriteLine("1. Create New Account");
                Console.WriteLine("2. View Account Details");
                Console.WriteLine("3. List All Accounts");
                Console.WriteLine("4. Back to Main Menu");
                
                string choice = ConsoleHelper.ReadString("\nSelect an option: ");

                switch (choice)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        ViewAccountDetails();
                        break;
                    case "3":
                        ListAllAccounts();
                        break;
                    case "4":
                        back = true;
                        break;
                    default:
                        ConsoleHelper.DisplayError("Invalid option. Please try again.");
                        ConsoleHelper.PressEnterToContinue();
                        break;
                }
            }
        }

        private void ShowTransactionMenu()
        {
            bool back = false;

            while (!back)
            {
                ConsoleHelper.DisplayHeader("TRANSACTION MANAGEMENT");
                
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. View Transaction History");
                Console.WriteLine("5. Back to Main Menu");
                
                string choice = ConsoleHelper.ReadString("\nSelect an option: ");

                switch (choice)
                {
                    case "1":
                        PerformDeposit();
                        break;
                    case "2":
                        PerformWithdrawal();
                        break;
                    case "3":
                        PerformTransfer();
                        break;
                    case "4":
                        ViewTransactionHistory();
                        break;
                    case "5":
                        back = true;
                        break;
                    default:
                        ConsoleHelper.DisplayError("Invalid option. Please try again.");
                        ConsoleHelper.PressEnterToContinue();
                        break;
                }
            }
        }

        private void ShowLoanMenu()
        {
            bool back = false;

            while (!back)
            {
                ConsoleHelper.DisplayHeader("LOAN MANAGEMENT");
                
                Console.WriteLine("1. Apply for Loan");
                Console.WriteLine("2. Make Loan Payment");
                Console.WriteLine("3. View Loan Details");
                Console.WriteLine("4. View Account Loans");
                Console.WriteLine("5. Back to Main Menu");
                
                string choice = ConsoleHelper.ReadString("\nSelect an option: ");

                switch (choice)
                {
                    case "1":
                        ApplyForLoan();
                        break;
                    case "2":
                        MakeLoanPayment();
                        break;
                    case "3":
                        ViewLoanDetails();
                        break;
                    case "4":
                        ViewAccountLoans();
                        break;
                    case "5":
                        back = true;
                        break;
                    default:
                        ConsoleHelper.DisplayError("Invalid option. Please try again.");
                        ConsoleHelper.PressEnterToContinue();
                        break;
                }
            }
        }

        private void CreateAccount()
        {
            try
            {
                ConsoleHelper.DisplayHeader("CREATE NEW ACCOUNT");
                
                string customerName = ConsoleHelper.ReadString("Enter customer name: ");
                decimal initialBalance = ConsoleHelper.ReadDecimal("Enter initial balance: $");

                var account = _accountService.CreateAccount(customerName, initialBalance);
                
                ConsoleHelper.DisplaySuccess($"Account created successfully! Account Number: {account.AccountNumber}");
            }
            catch (Exception ex)
            {
                ConsoleHelper.DisplayError(ex.Message);
            }
            
            ConsoleHelper.PressEnterToContinue();
        }

        private void ViewAccountDetails()
        {
            try
            {
                ConsoleHelper.DisplayHeader("VIEW ACCOUNT DETAILS");
                
                string accountNumber = ConsoleHelper.ReadString("Enter account number: ");
                _accountService.DisplayAccountDetails(accountNumber);
            }
            catch (Exception ex)
            {
                ConsoleHelper.DisplayError(ex.Message);
            }
            
            ConsoleHelper.PressEnterToContinue();
        }

        private void ListAllAccounts()
        {
            ConsoleHelper.DisplayHeader("ALL ACCOUNTS");
            
            var accounts = _accountService.GetAllAccounts();

            if (accounts.Count == 0)
            {
                Console.WriteLine("No accounts found.");
            }
            else
            {
                Console.WriteLine($"{"Account No",-15} {"Customer Name",-25} {"Balance",15}");
                Console.WriteLine(new string('-', 55));
                
                foreach (var account in accounts)
                {
                    Console.WriteLine($"{account.AccountNumber,-15} {account.CustomerName,-25} ${account.Balance,13:N2}");
                }
            }
            
            ConsoleHelper.PressEnterToContinue();
        }

        private void PerformDeposit()
        {
            try
            {
                ConsoleHelper.DisplayHeader("DEPOSIT");
                
                string accountNumber = ConsoleHelper.ReadString("Enter account number: ");
                decimal amount = ConsoleHelper.ReadDecimal("Enter deposit amount: $");

                _transactionService.Deposit(accountNumber, amount);
                
                ConsoleHelper.DisplaySuccess($"Successfully deposited ${amount:N2} to account {accountNumber}");
            }
            catch (Exception ex)
            {
                ConsoleHelper.DisplayError(ex.Message);
            }
            
            ConsoleHelper.PressEnterToContinue();
        }

        private void PerformWithdrawal()
        {
            try
            {
                ConsoleHelper.DisplayHeader("WITHDRAWAL");
                
                string accountNumber = ConsoleHelper.ReadString("Enter account number: ");
                decimal amount = ConsoleHelper.ReadDecimal("Enter withdrawal amount: $");

                _transactionService.Withdraw(accountNumber, amount);
                
                ConsoleHelper.DisplaySuccess($"Successfully withdrew ${amount:N2} from account {accountNumber}");
            }
            catch (Exception ex)
            {
                ConsoleHelper.DisplayError(ex.Message);
            }
            
            ConsoleHelper.PressEnterToContinue();
        }

        private void PerformTransfer()
        {
            try
            {
                ConsoleHelper.DisplayHeader("TRANSFER");
                
                string fromAccount = ConsoleHelper.ReadString("Enter source account number: ");
                string toAccount = ConsoleHelper.ReadString("Enter destination account number: ");
                decimal amount = ConsoleHelper.ReadDecimal("Enter transfer amount: $");

                _transactionService.Transfer(fromAccount, toAccount, amount);
                
                ConsoleHelper.DisplaySuccess($"Successfully transferred ${amount:N2} from {fromAccount} to {toAccount}");
            }
            catch (Exception ex)
            {
                ConsoleHelper.DisplayError(ex.Message);
            }
            
            ConsoleHelper.PressEnterToContinue();
        }

        private void ViewTransactionHistory()
        {
            try
            {
                ConsoleHelper.DisplayHeader("TRANSACTION HISTORY");
                
                string accountNumber = ConsoleHelper.ReadString("Enter account number: ");
                _transactionService.DisplayTransactionHistory(accountNumber);
            }
            catch (Exception ex)
            {
                ConsoleHelper.DisplayError(ex.Message);
            }
            
            ConsoleHelper.PressEnterToContinue();
        }

        private void ApplyForLoan()
        {
            try
            {
                ConsoleHelper.DisplayHeader("APPLY FOR LOAN");
                
                string accountNumber = ConsoleHelper.ReadString("Enter account number: ");
                decimal amount = ConsoleHelper.ReadDecimal("Enter loan amount: $");
                decimal interestRate = ConsoleHelper.ReadDecimal("Enter interest rate (%): ");
                int duration = ConsoleHelper.ReadInt("Enter duration (months): ");

                var loan = _loanService.CreateLoan(accountNumber, amount, interestRate, duration);
                
                ConsoleHelper.DisplaySuccess($"Loan approved! Loan Number: {loan.LoanNumber}");
                Console.WriteLine($"Monthly Payment: ${loan.CalculateMonthlyPayment():N2}");
                Console.WriteLine($"Total Amount to Pay: ${loan.OutstandingAmount:N2}");
            }
            catch (Exception ex)
            {
                ConsoleHelper.DisplayError(ex.Message);
            }
            
            ConsoleHelper.PressEnterToContinue();
        }

        private void MakeLoanPayment()
        {
            try
            {
                ConsoleHelper.DisplayHeader("MAKE LOAN PAYMENT");
                
                string loanNumber = ConsoleHelper.ReadString("Enter loan number: ");
                decimal amount = ConsoleHelper.ReadDecimal("Enter payment amount: $");

                _loanService.MakeLoanPayment(loanNumber, amount);
                
                ConsoleHelper.DisplaySuccess($"Payment of ${amount:N2} processed successfully!");
            }
            catch (Exception ex)
            {
                ConsoleHelper.DisplayError(ex.Message);
            }
            
            ConsoleHelper.PressEnterToContinue();
        }

        private void ViewLoanDetails()
        {
            try
            {
                ConsoleHelper.DisplayHeader("VIEW LOAN DETAILS");
                
                string loanNumber = ConsoleHelper.ReadString("Enter loan number: ");
                _loanService.DisplayLoanDetails(loanNumber);
            }
            catch (Exception ex)
            {
                ConsoleHelper.DisplayError(ex.Message);
            }
            
            ConsoleHelper.PressEnterToContinue();
        }

        private void ViewAccountLoans()
        {
            try
            {
                ConsoleHelper.DisplayHeader("VIEW ACCOUNT LOANS");
                
                string accountNumber = ConsoleHelper.ReadString("Enter account number: ");
                var loans = _loanService.GetAccountLoans(accountNumber);

                if (loans.Count == 0)
                {
                    Console.WriteLine("No loans found for this account.");
                }
                else
                {
                    Console.WriteLine($"\n{"Loan No",-12} {"Principal",12} {"Rate",8} {"Duration",10} {"Outstanding",15} {"Status",-12}");
                    Console.WriteLine(new string('-', 70));
                    
                    foreach (var loan in loans)
                    {
                        Console.WriteLine($"{loan.LoanNumber,-12} ${loan.PrincipalAmount,10:N2} {loan.InterestRate,6}% {loan.DurationInMonths,8}m ${loan.OutstandingAmount,13:N2} {(loan.IsActive ? "Active" : "Paid"),-12}");
                    }
                }
            }
            catch (Exception ex)
            {
                ConsoleHelper.DisplayError(ex.Message);
            }
            
            ConsoleHelper.PressEnterToContinue();
        }
    }
}
