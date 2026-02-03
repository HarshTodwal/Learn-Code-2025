using BankingSystem.Interfaces;
using BankingSystem.Repositories;
using BankingSystem.Services;
using BankingSystem.UI;
using BankingSystem.Utilities;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var idGenerator = new IdGenerator();
            
            var accountRepository = new AccountRepository();
            var transactionRepository = new TransactionRepository();
            var loanRepository = new LoanRepository();
            
            var accountService = new AccountService(accountRepository, idGenerator);
            var transactionService = new TransactionService(accountRepository, transactionRepository, idGenerator);
            var loanService = new LoanService(loanRepository, accountRepository, idGenerator);
            
            var menuHandler = new MenuHandler(accountService, transactionService, loanService);
            
            menuHandler.ShowMainMenu();
        }
    }
}
