using BankingSystem.Entities;
using BankingSystem.Interfaces;
using BankingSystem.Utilities;

namespace BankingSystem.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IIdGenerator _idGenerator;

        public TransactionService(
            IAccountRepository accountRepository, 
            ITransactionRepository transactionRepository,
            IIdGenerator idGenerator)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _idGenerator = idGenerator;
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            var account = GetAccountOrThrow(accountNumber);
            
            account.Deposit(amount);
            
            RecordTransaction(accountNumber, TransactionType.Deposit, amount, "Deposit");
        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            var account = GetAccountOrThrow(accountNumber);
            
            account.Withdraw(amount);
            
            RecordTransaction(accountNumber, TransactionType.Withdrawal, amount, "Withdrawal");
        }

        public void Transfer(string fromAccount, string toAccount, decimal amount)
        {
            var sourceAccount = GetAccountOrThrow(fromAccount);
            var targetAccount = GetAccountOrThrow(toAccount);

            if (fromAccount == toAccount)
                throw new InvalidOperationException("Cannot transfer to the same account");

            sourceAccount.Withdraw(amount);
            targetAccount.Deposit(amount);

            RecordTransfer(fromAccount, toAccount, amount);
        }

        public void DisplayTransactionHistory(string accountNumber)
        {
            var account = GetAccountOrThrow(accountNumber);
            var transactions = _transactionRepository.GetByAccountNumber(accountNumber);

            Console.WriteLine("\n" + new string('=', 70));
            Console.WriteLine($"TRANSACTION HISTORY - {accountNumber}");
            Console.WriteLine(new string('=', 70));

            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions found.");
            }
            else
            {
                foreach (var transaction in transactions)
                {
                    Console.WriteLine(transaction.GetFormattedDetails());
                }
            }

            Console.WriteLine(new string('=', 70));
        }

        private Account GetAccountOrThrow(string accountNumber)
        {
            var account = _accountRepository.GetByAccountNumber(accountNumber);
            
            if (account == null)
                throw new InvalidOperationException($"Account {accountNumber} not found");

            return account;
        }

        private void RecordTransaction(string accountNumber, TransactionType type, 
                                       decimal amount, string description)
        {
            string transactionId = _idGenerator.GenerateTransactionId();
            var transaction = new Transaction(transactionId, accountNumber, type, amount, description);
            _transactionRepository.Add(transaction);
        }

        private void RecordTransfer(string fromAccount, string toAccount, decimal amount)
        {
            string transactionId = _idGenerator.GenerateTransactionId();
            
            var outgoingTransaction = new Transaction(
                transactionId, 
                fromAccount, 
                TransactionType.Transfer, 
                amount, 
                "Transfer Out", 
                toAccount
            );
            
            var incomingTransaction = new Transaction(
                transactionId, 
                toAccount, 
                TransactionType.Transfer, 
                amount, 
                "Transfer In", 
                fromAccount
            );

            _transactionRepository.Add(outgoingTransaction);
            _transactionRepository.Add(incomingTransaction);
        }
    }
}
