using BankingSystem.Entities;
using BankingSystem.Interfaces;

namespace BankingSystem.Repositories{
    public class TransactionRepository : ITransactionRepository{
        private readonly List<Transaction> _transactions;

        public TransactionRepository(){
            _transactions = new List<Transaction>();
        }

        public void Add(Transaction transaction){
            if (transaction == null)
                throw new ArgumentNullException(nameof(transaction));

            _transactions.Add(transaction);
        }

        public List<Transaction> GetByAccountNumber(string accountNumber){
            return _transactions
                .Where(t => t.AccountNumber == accountNumber || t.TargetAccountNumber == accountNumber)
                .OrderByDescending(t => t.TransactionDate)
                .ToList();
        }

        public List<Transaction> GetAll(){
            return new List<Transaction>(_transactions);
        }
    }
}
