using BankingSystem.Entities;

namespace BankingSystem.Interfaces{
    public interface IAccountService{
        Account CreateAccount(string customerName, decimal initialBalance);
        Account GetAccount(string accountNumber);
        void DisplayAccountDetails(string accountNumber);
        List<Account> GetAllAccounts();
    }

    public interface ITransactionService{
        void Deposit(string accountNumber, decimal amount);
        void Withdraw(string accountNumber, decimal amount);
        void Transfer(string fromAccount, string toAccount, decimal amount);
        void DisplayTransactionHistory(string accountNumber);
    }

    public interface ILoanService{
        Loan CreateLoan(string accountNumber, decimal amount, decimal interestRate, int durationInMonths);
        void MakeLoanPayment(string loanNumber, decimal amount);
        void DisplayLoanDetails(string loanNumber);
        List<Loan> GetAccountLoans(string accountNumber);
    }
}
