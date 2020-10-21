using Employees.ConsoleApp.Coverters;
using Employees.ConsoleApp.Entities;
using Employees.ConsoleApp.Controllers;
using System;
using System.Collections.Generic;
using System.IO;

namespace Employees.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Directory.GetCurrentDirectory() + "\\test.txt";

            if(File.Exists(filePath))
            {
                List<Employee> employees = FileConverter.ConvertToEmployees(filePath);               
                EmployeesController employeesController = new EmployeesController(employees);
                List<Couple> couplesWithMaxDays = employeesController.GetCouplesWithMaxDaysWorked();

                foreach(Couple couple in couplesWithMaxDays)
                {
                    DrawHeader();

                    bool areEmpIdsDrawn = false;

                    foreach(Project project in couple.Projects)
                    {
                        Console.WriteLine(String.Format("|{0,-15}|{1,-15}|{2,-11}|{3,-12}|",
                            !areEmpIdsDrawn ? couple.EmpId1.ToString() : "", !areEmpIdsDrawn ? couple.EmpId2.ToString() : "",
                            project.ProjectID, project.Days));
                        areEmpIdsDrawn = true;
                    }

                    DrawLine();
                }
            }
            else
            {
                Console.WriteLine("The file does not exist or does not have sufficient permissions to read it!");
            }
        }

        private static void DrawHeader()
        {
            DrawLine();
            Console.WriteLine(String.Format("|{0,-15}|{1,-15}|{2,-11}|{3,-12}|", "Employee ID #1", "Employee ID #2", "Project ID", "Days worked"));
            DrawLine();
        }

        private static void DrawLine()
        {
            Console.WriteLine(new String('-', 58));
        }
    }
}
