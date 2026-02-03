namespace BankingSystem.Entities
{
    public class Loan
    {
        public string LoanNumber { get; private set; }
        public string AccountNumber { get; private set; }
        public decimal PrincipalAmount { get; private set; }
        public decimal InterestRate { get; private set; }
        public int DurationInMonths { get; private set; }
        public decimal OutstandingAmount { get; private set; }
        public DateTime IssueDate { get; private set; }
        public bool IsActive { get; private set; }

        public Loan(string loanNumber, string accountNumber, decimal principalAmount, 
                    decimal interestRate, int durationInMonths)
        {
            LoanNumber = loanNumber;
            AccountNumber = accountNumber;
            PrincipalAmount = principalAmount;
            InterestRate = interestRate;
            DurationInMonths = durationInMonths;
            OutstandingAmount = CalculateTotalAmount();
            IssueDate = DateTime.Now;
            IsActive = true;
        }

        private decimal CalculateTotalAmount()
        {
            decimal interest = PrincipalAmount * (InterestRate / 100) * (DurationInMonths / 12m);
            return PrincipalAmount + interest;
        }

        public decimal CalculateMonthlyPayment()
        {
            return OutstandingAmount / DurationInMonths;
        }

        public void MakePayment(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Payment amount must be positive");

            if (amount > OutstandingAmount)
                throw new ArgumentException("Payment exceeds outstanding amount");

            OutstandingAmount -= amount;

            if (OutstandingAmount == 0)
                IsActive = false;
        }

        public bool IsFullyPaid()
        {
            return OutstandingAmount == 0;
        }
    }
}
