using EmployeeManagement.Entities;

namespace EmployeeManagement.Interfaces
{
    public interface IEmployeeReporter
    {
        void Export(Employee employee);
    }
}
