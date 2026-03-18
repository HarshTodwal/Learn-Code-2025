using System;
using Domain;

namespace Services
{
    public class PaperboyService
    {
        public void CollectPayment(Customer customer, double amount)
        {
            if (customer.Pay(amount))
            {
                Console.WriteLine("Payment collected successfully.");
            }
            else
            {
                Console.WriteLine("Insufficient funds. Come back later.");
            }
        }
    }
}