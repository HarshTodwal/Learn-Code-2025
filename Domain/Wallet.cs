namespace Domain
{
    public class Wallet
    {
        private double _balance;

        public Wallet(double initialBalance)
        {
            _balance = initialBalance;
        }

        public bool TryDeduct(double amount)
        {
            if (amount <= 0) return false;

            if (_balance >= amount)
            {
                _balance -= amount;
                return true;
            }

            return false;
        }
    }
}