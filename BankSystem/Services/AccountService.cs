using BankingSystem.Entities;
using BankingSystem.Interfaces;
using BankingSystem.Utilities;

namespace BankingSystem.Services{
    public class AccountService : IAccountService{
        private readonly IAccountRepository _accountRepository;
        private readonly IIdGenerator _idGenerator;

        public AccountService(IAccountRepository accountRepository, IIdGenerator idGenerator){
            _accountRepository = accountRepository;
            _idGenerator = idGenerator;
        }

        public Account CreateAccount(string customerName, decimal initialBalance){
            ValidateCustomerName(customerName);
            ValidateInitialBalance(initialBalance);

            string accountNumber = _idGenerator.GenerateAccountNumber();
            var account = new Account(accountNumber, customerName, initialBalance);

            _accountRepository.Add(account);

            return account;
        }

        public Account GetAccount(string accountNumber){
            var account = _accountRepository.GetByAccountNumber(accountNumber);

            if (account == null)
                throw new InvalidOperationException($"Account {accountNumber} not found");

            return account;
        }

        public void DisplayAccountDetails(string accountNumber){
            var account = GetAccount(accountNumber);

            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("ACCOUNT DETAILS");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"Account Number : {account.AccountNumber}");
            Console.WriteLine($"Customer Name : {account.CustomerName}");
            Console.WriteLine($"Balance : ${account.Balance:N2}");
            Console.WriteLine($"Created Date : {account.CreatedDate:yyyy-MM-dd}");
            Console.WriteLine($"Status : {(account.IsActive ? "Active" : "Inactive")}");
            Console.WriteLine(new string('=', 50));
        }

        public List<Account> GetAllAccounts(){
            return _accountRepository.GetAll();
        }

        private void ValidateCustomerName(string customerName){
            if (string.IsNullOrWhiteSpace(customerName))
                throw new ArgumentException("Customer name cannot be empty");
        }

        private void ValidateInitialBalance(decimal initialBalance){
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative");
        }
    }
}
