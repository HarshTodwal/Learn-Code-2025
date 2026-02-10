namespace BankingSystem.Entities{
    public class LoanRequest{
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal InterestRate { get; set; }
        public int DurationInMonths { get; set; }
    }
}
