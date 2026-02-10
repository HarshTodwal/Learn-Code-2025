namespace BankingSystem.Entities{
    public class Account{
        public string AccountNumber { get; private set; }
        public string CustomerName { get; set; }
        public decimal Balance { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool IsActive { get; set; }

        public Account(string accountNumber, string customerName, decimal initialBalance){
            AccountNumber = accountNumber;
            CustomerName = customerName;
            Balance = initialBalance;
            CreatedDate = DateTime.Now;
            IsActive = true;
        }

        public void Deposit(decimal amount){
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive");

            Balance += amount;
        }

        public void Withdraw(decimal amount){
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive");

            if (Balance < amount)
                throw new InvalidOperationException("Insufficient balance");

            Balance -= amount;
        }

        public bool HasSufficientBalance(decimal amount){
            return Balance >= amount;
        }
    }
}
