namespace BankingSystem.Entities{
    public enum TransactionType{
        Deposit,
        Withdrawal,
        Transfer
    }

    public class TransactionCreationData{
        public string TransactionId { get; set; }
        public string AccountNumber { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string? TargetAccountNumber { get; set; }
    }

    public class Transaction{
        public string TransactionId { get; private set; }
        public string AccountNumber { get; private set; }
        public TransactionType Type { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public string? TargetAccountNumber { get; private set; }
        public string Description { get; private set; }

        public Transaction(TransactionCreationData data){
            TransactionId = data.TransactionId;
            AccountNumber = data.AccountNumber;
            Type = data.Type;
            Amount = data.Amount;
            TransactionDate = DateTime.Now;
            TargetAccountNumber = data.TargetAccountNumber;
            Description = data.Description;
        }

        public string GetFormattedDetails(){
            string details = $"[{TransactionDate:yyyy-MM-dd HH:mm:ss}] {Type}: ${Amount:N2}";

            if (!string.IsNullOrEmpty(TargetAccountNumber))
                details += $" to {TargetAccountNumber}";

            details += $" - {Description}";

            return details;
        }
    }
}
