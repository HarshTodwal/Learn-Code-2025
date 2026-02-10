using BankingSystem.Entities;
using BankingSystem.Interfaces;

namespace BankingSystem.Repositories{
    public class LoanRepository : ILoanRepository{
        private readonly List<Loan> _loans;

        public LoanRepository(){
            _loans = new List<Loan>();
        }

        public void Add(Loan loan){
            if (loan == null)
                throw new ArgumentNullException(nameof(loan));

            if (Exists(loan.LoanNumber))
                throw new InvalidOperationException($"Loan {loan.LoanNumber} already exists");

            _loans.Add(loan);
        }

        public Loan? GetByLoanNumber(string loanNumber){
            return _loans.FirstOrDefault(l => l.LoanNumber == loanNumber);
        }

        public List<Loan> GetByAccountNumber(string accountNumber){
            return _loans
                .Where(l => l.AccountNumber == accountNumber)
                .ToList();
        }

        public List<Loan> GetAll(){
            return new List<Loan>(_loans);
        }

        public bool Exists(string loanNumber){
            return _loans.Any(l => l.LoanNumber == loanNumber);
        }
    }
}
