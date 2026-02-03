using BankingSystem.Entities;
using BankingSystem.Interfaces;

namespace BankingSystem.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts;

        public AccountRepository()
        {
            _accounts = new List<Account>();
        }

        public void Add(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            if (Exists(account.AccountNumber))
                throw new InvalidOperationException($"Account {account.AccountNumber} already exists");

            _accounts.Add(account);
        }

        public Account? GetByAccountNumber(string accountNumber)
        {
            return _accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public List<Account> GetAll()
        {
            return new List<Account>(_accounts);
        }

        public bool Exists(string accountNumber)
        {
            return _accounts.Any(a => a.AccountNumber == accountNumber);
        }
    }
}
