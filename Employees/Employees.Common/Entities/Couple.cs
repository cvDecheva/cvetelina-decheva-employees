using System.Collections.Generic;

namespace Employees.Common.Entities
{
    public class Couple
    {
        public int EmpId1
        {
            get;
            private set;
        }

        public int EmpId2
        {
            get;
            private set;
        }

        public List<Project> Projects
        {
            get;
            private set;
        }

        public int TotalDays
        {
            get;
            private set;
        }

        public Couple(int empId1, int empId2)
        {
            EmpId1 = empId1;
            EmpId2 = empId2;
            Projects = new List<Project>();
            TotalDays = 0;
        }

        public bool IsEqual(int empId1, int empId2)
        {
            return (EmpId1 == empId1 && EmpId2 == empId2) || (EmpId2 == empId1 && EmpId1 == empId2);
        }

        public void AddProject(Project project)
        {
            Projects.Add(project);
            TotalDays += project.Days;
        }
    }
}
