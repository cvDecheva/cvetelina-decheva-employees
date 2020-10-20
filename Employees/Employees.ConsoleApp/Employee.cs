using System;

namespace Employees.ConsoleApp
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

        public DateTime DateFrom
        {
            get;
            private set;
        }

        public DateTime DateTo
        {
            get;
            private set;
        }

        public Employee(int empId, int projectId, DateTime dateFrom, DateTime dateTo)
        {
            EmpID = empId;
            ProjectID = projectId;
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        public override string ToString()
        {
            return String.Format("|{0,-6}|{1,-10}|{2,-25}|{3,-25}|", EmpID, ProjectID, DateFrom, DateTo);
        }
    }
}
