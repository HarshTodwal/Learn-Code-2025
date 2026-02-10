namespace BankingSystem.Utilities{
    public interface IIdGenerator{
        string GenerateAccountNumber();
        string GenerateLoanNumber();
        string GenerateTransactionId();
    }

    public class IdGenerator : IIdGenerator{
        private int _accountCounter = 0;
        private int _loanCounter = 0;
        private int _transactionCounter = 0;

        public string GenerateAccountNumber(){
            _accountCounter++;
            return $"AC{_accountCounter:D2}";
        }

        public string GenerateLoanNumber(){
            _loanCounter++;
            return $"LO{_loanCounter:D2}";
        }

        public string GenerateTransactionId(){
            _transactionCounter++;
            return $"TXN{_transactionCounter:D6}";
        }
    }
}
