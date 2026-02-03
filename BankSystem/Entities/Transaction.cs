namespace BankingSystem.Entities
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Transfer
    }

    public class Transaction
    {
        public string TransactionId { get; private set; }
        public string AccountNumber { get; private set; }
        public TransactionType Type { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public string? TargetAccountNumber { get; private set; }
        public string Description { get; private set; }

        public Transaction(string transactionId, string accountNumber, TransactionType type, 
                          decimal amount, string description, string? targetAccountNumber = null)
        {
            TransactionId = transactionId;
            AccountNumber = accountNumber;
            Type = type;
            Amount = amount;
            TransactionDate = DateTime.Now;
            TargetAccountNumber = targetAccountNumber;
            Description = description;
        }

        public string GetFormattedDetails()
        {
            string details = $"[{TransactionDate:yyyy-MM-dd HH:mm:ss}] {Type}: ${Amount:N2}";
            
            if (!string.IsNullOrEmpty(TargetAccountNumber))
                details += $" to {TargetAccountNumber}";
            
            details += $" - {Description}";
            
            return details;
        }
    }
}
