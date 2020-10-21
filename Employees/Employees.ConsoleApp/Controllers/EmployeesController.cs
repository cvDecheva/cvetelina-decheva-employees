using Employees.ConsoleApp.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Employees.ConsoleApp.Controllers
{
    public class EmployeesController
    {
        private List<Couple> _couples = new List<Couple>();

        public EmployeesController(List<Employee> employees)
        {
            CreateCouples(employees);
        }

        private void CreateCouples(List<Employee> employees)
        {
            for(int i = 0; i < employees.Count; i++)
            {
                for(int j = 1; j < employees.Count; j++)
                {
                    if(employees[i].ProjectID == employees[j].ProjectID && employees[i].EmpID != employees[j].EmpID)
                    {
                        Period emp1 = employees[i].Period;
                        Period emp2 = employees[j].Period;

                        if(!(emp1.Start > emp2.End || emp1.End < emp2.Start))
                        {
                            Couple couple = _couples.FirstOrDefault(c => c.IsEqual(employees[i].EmpID, employees[j].EmpID));

                            if(couple == null)
                            {
                                couple = new Couple(employees[i].EmpID, employees[j].EmpID);
                                _couples.Add(couple);
                            }

                            Period period = new Period(emp1.Start >= emp2.Start ? emp1.Start : emp2.Start, emp1.End <= emp2.End ? emp1.End : emp2.End);
                            couple.AddProject(new Project(employees[i].ProjectID, period.GetDays()));
                        }
                    }
                }

                if(employees.Count > 0)
                {
                    employees.RemoveAt(0);
                    i--;
                }
                else
                {
                    break;
                }
            }
        }

        private int GetMaxDaysWorked()
        {
            int maxDays = 0;

            foreach(Couple couple in _couples)
            {
                if(maxDays < couple.TotalDays)
                {
                    maxDays = couple.TotalDays;
                }
            }

            return maxDays;
        }

        public List<Couple> GetCouplesWithMaxDaysWorked()
        {
            return _couples.FindAll(c => c.TotalDays == GetMaxDaysWorked());
        }
    }
}
