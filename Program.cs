using Domain;
using Services;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer("Alex", "Smith", 100);
            var paperboyService = new PaperboyService();

            paperboyService.CollectPayment(customer, 50);
            paperboyService.CollectPayment(customer, 60);

            Console.ReadLine();
        }
    }
}