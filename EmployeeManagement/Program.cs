using EmployeeManagement.Entities;
using EmployeeManagement.Services;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Reporting;

class Program
{
    static void Main()
    {
        var employee = new Employee
        {
            Id = 1,
            Name = "Alex",
            Department = "IT"
        };

        var repository = new SqlEmployeeRepository();
        repository.Save(employee);

        var xmlReporter = new XmlEmployeeReporter();
        xmlReporter.Export(employee);

        var csvReporter = new CsvEmployeeReporter();
        csvReporter.Export(employee);

        var service = new EmployeeService();
        service.TerminateEmployee(employee);

        System.Console.WriteLine(
            $"Is Working: {employee.IsCurrentlyWorking()}"
        );
    }
}
