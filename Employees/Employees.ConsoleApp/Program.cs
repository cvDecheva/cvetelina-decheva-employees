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
                DrawHeader();

                List<Employee> employees = FileConverter.ConvertToEmployees(filePath);

                foreach(Employee employee in employees)
                {
                    Console.WriteLine(employee.ToString());
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
            Console.WriteLine(String.Format("|{0,-6}|{1,-10}|{2,-25}|{3,-25}|", "EmpId", "ProjectId", "DateFrom", "DateTo"));
            DrawLine();
        }

        private static void DrawLine()
        {
            Console.WriteLine(new String('-', 71));
        }
    }
}
