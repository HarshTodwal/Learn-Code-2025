using BankingSystem.Entities;
using BankingSystem.Interfaces;
using BankingSystem.Utilities;

namespace BankingSystem.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IIdGenerator _idGenerator;

        public LoanService(
            ILoanRepository loanRepository, 
            IAccountRepository accountRepository,
            IIdGenerator idGenerator)
        {
            _loanRepository = loanRepository;
            _accountRepository = accountRepository;
            _idGenerator = idGenerator;
        }

        public Loan CreateLoan(string accountNumber, decimal amount, decimal interestRate, int durationInMonths)
        {
            var account = ValidateAndGetAccount(accountNumber);
            ValidateLoanParameters(amount, interestRate, durationInMonths);

            string loanNumber = _idGenerator.GenerateLoanNumber();
            var loan = new Loan(loanNumber, accountNumber, amount, interestRate, durationInMonths);
            
            _loanRepository.Add(loan);
            
            account.Deposit(amount);
            
            return loan;
        }

        public void MakeLoanPayment(string loanNumber, decimal amount)
        {
            var loan = GetLoanOrThrow(loanNumber);
            
            if (!loan.IsActive)
                throw new InvalidOperationException("Loan is already fully paid");

            loan.MakePayment(amount);
        }

        public void DisplayLoanDetails(string loanNumber)
        {
            var loan = GetLoanOrThrow(loanNumber);

            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("LOAN DETAILS");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Loan Number : {loan.LoanNumber}");
            Console.WriteLine($"Account Number : {loan.AccountNumber}");
            Console.WriteLine($"Principal Amount : ${loan.PrincipalAmount:N2}");
            Console.WriteLine($"Interest Rate : {loan.InterestRate}%");
            Console.WriteLine($"Duration : {loan.DurationInMonths} months");
            Console.WriteLine($"Monthly Payment : ${loan.CalculateMonthlyPayment():N2}");
            Console.WriteLine($"Outstanding : ${loan.OutstandingAmount:N2}");
            Console.WriteLine($"Issue Date : {loan.IssueDate:yyyy-MM-dd}");
            Console.WriteLine($"Status : {(loan.IsActive ? "Active" : "Fully Paid")}");
            Console.WriteLine(new string('=', 50));
        }

        public List<Loan> GetAccountLoans(string accountNumber)
        {
            ValidateAndGetAccount(accountNumber);
            return _loanRepository.GetByAccountNumber(accountNumber);
        }

        private Account ValidateAndGetAccount(string accountNumber)
        {
            var account = _accountRepository.GetByAccountNumber(accountNumber);
            if (account == null)
                throw new InvalidOperationException($"Account {accountNumber} not found");
            return account;
        }

        private void ValidateLoanParameters(decimal amount, decimal interestRate, int durationInMonths)
        {
            if (amount <= 0)
                throw new ArgumentException("Loan amount must be positive");

            if (interestRate < 0)
                throw new ArgumentException("Interest rate cannot be negative");

            if (durationInMonths <= 0)
                throw new ArgumentException("Duration must be positive");
        }

        private Loan GetLoanOrThrow(string loanNumber)
        {
            var loan = _loanRepository.GetByLoanNumber(loanNumber);
            
            if (loan == null)
                throw new InvalidOperationException($"Loan {loanNumber} not found");

            return loan;
        }
    }
}
