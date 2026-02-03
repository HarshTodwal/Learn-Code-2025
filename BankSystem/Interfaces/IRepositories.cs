using BankingSystem.Entities;

namespace BankingSystem.Interfaces
{
    public interface IAccountRepository
    {
        void Add(Account account);
        Account? GetByAccountNumber(string accountNumber);
        List<Account> GetAll();
        bool Exists(string accountNumber);
    }

    public interface ITransactionRepository
    {
        void Add(Transaction transaction);
        List<Transaction> GetByAccountNumber(string accountNumber);
        List<Transaction> GetAll();
    }

    public interface ILoanRepository
    {
        void Add(Loan loan);
        Loan? GetByLoanNumber(string loanNumber);
        List<Loan> GetByAccountNumber(string accountNumber);
        List<Loan> GetAll();
        bool Exists(string loanNumber);
    }
}
