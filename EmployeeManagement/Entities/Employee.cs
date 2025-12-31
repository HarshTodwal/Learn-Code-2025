namespace EmployeeManagement.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public bool IsWorking { get; private set; } = true;

        public bool IsCurrentlyWorking() => IsWorking;

        public void Terminate()
        {
            IsWorking = false;
        }
    }
}
