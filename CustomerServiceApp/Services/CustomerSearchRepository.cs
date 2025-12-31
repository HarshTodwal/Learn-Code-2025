using System.Collections.Generic;
using System.Linq;
using CustomerSystem.Entities;
using CustomerSystem.Interfaces;

namespace CustomerSystem.Services
{
    public class CustomerSearchRepository : ICustomerSearchRepository
    {
        private IQueryable<Customer> GetBaseQuery()
        {
            return db.Customers.OrderBy(c => c.Id);
        }

        public List<Customer> FindByCountry(string country)
        {
            return GetBaseQuery()
                .Where(c => c.Country.Contains(country))
                .ToList();
        }

        public List<Customer> FindByCompanyName(string companyName)
        {
            return GetBaseQuery()
                .Where(c => c.CompanyName.Contains(companyName))
                .ToList();
        }

        public List<Customer> FindByContactName(string contactName)
        {
            return GetBaseQuery()
                .Where(c => c.ContactName.Contains(contactName))
                .ToList();
        }
    }
}
