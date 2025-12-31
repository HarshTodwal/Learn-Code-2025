using System.Collections.Generic;
using CustomerSystem.Entities;

namespace CustomerSystem.Interfaces
{
    public interface ICustomerSearchRepository
    {
        List<Customer> FindByCountry(string country);
        List<Customer> FindByCompanyName(string companyName);
        List<Customer> FindByContactName(string contactName);
    }
}
