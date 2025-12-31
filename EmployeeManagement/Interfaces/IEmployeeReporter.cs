using EmployeeManagement.Entities;

namespace EmployeeManagement.Interfaces
{
    public interface IEmployeeRepository
    {
        void Save(Employee employee);
    }
}
