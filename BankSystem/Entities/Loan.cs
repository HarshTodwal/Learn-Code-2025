namespace BankingSystem.Entities{
    public class LoanCreationData{
        public string LoanNumber { get; set; }
        public string AccountNumber { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int DurationInMonths { get; set; }
    }

    public class Loan{
        public string LoanNumber { get; private set; }
        public string AccountNumber { get; private set; }
        public decimal PrincipalAmount { get; private set; }
        public decimal InterestRate { get; private set; }
        public int DurationInMonths { get; private set; }
        public decimal OutstandingAmount { get; private set; }
        public DateTime IssueDate { get; private set; }
        public bool IsActive { get; private set; }

        public Loan(LoanCreationData data){
            LoanNumber = data.LoanNumber;
            AccountNumber = data.AccountNumber;
            PrincipalAmount = data.PrincipalAmount;
            InterestRate = data.InterestRate;
            DurationInMonths = data.DurationInMonths;
            IssueDate = DateTime.Now;
            IsActive = true;
            OutstandingAmount = CalculateTotalAmount();
        }

        public decimal CalculateMonthlyPayment(){
            return OutstandingAmount / DurationInMonths;
        }

        public void MakePayment(decimal amount){
            if (amount <= 0)
                throw new ArgumentException("Payment amount must be positive");

            if (amount > OutstandingAmount)
                throw new ArgumentException("Payment exceeds outstanding amount");

            OutstandingAmount -= amount;

            if (OutstandingAmount == 0)
                IsActive = false;
        }

        public bool IsFullyPaid(){
            return OutstandingAmount == 0;
        }

        private decimal CalculateTotalAmount(){
            decimal interest = PrincipalAmount * (InterestRate / 100) * (DurationInMonths / 12m);
            return PrincipalAmount + interest;
        }
    }
}
