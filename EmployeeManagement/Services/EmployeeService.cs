using EmployeeManagement.Entities;

namespace EmployeeManagement.Services
{
    public class EmployeeService
    {
        public void TerminateEmployee(Employee employee)
        {
            employee.Terminate();
        }
    }
}
