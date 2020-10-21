namespace Employees.ConsoleApp.Entities
{
    public class Employee
    {
        public int EmpID
        {
            get;
            private set;
        }

        public int ProjectID
        {
            get;
            private set;
        }

        public Period Period
        {
            get;
            private set;
        }

        public Employee(int empId, int projectId, Period period)
        {
            EmpID = empId;
            ProjectID = projectId;
            Period = period;
        }
    }
}
