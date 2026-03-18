namespace Domain
{
    public class Customer
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly Wallet _wallet;

        public Customer(string firstName, string lastName, double initialBalance)
        {
            _firstName = firstName;
            _lastName = lastName;
            _wallet = new Wallet(initialBalance);
        }

        public bool Pay(double amount)
        {
            return _wallet.TryDeduct(amount);
        }

        public string GetFullName()
        {
            return $"{_firstName} {_lastName}";
        }
    }
}