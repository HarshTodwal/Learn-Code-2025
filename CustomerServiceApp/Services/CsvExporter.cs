using System.Collections.Generic;
using CustomerSearchProject.Entities;

namespace CustomerSearchProject.Interfaces
{
    public interface ICustomerExporter
    {
        string Export(List<Customer> customers);
    }
}
