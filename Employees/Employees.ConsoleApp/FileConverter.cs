using System;
using System.Collections.Generic;
using System.IO;

namespace Employees.ConsoleApp
{
    public class FileConverter
    {
        private static bool TryConvertDate(string date, out DateTime convertedDate)
        {
            if(DateTime.TryParse(date, out convertedDate))
            {
                return true;
            }
            else if(date.ToLower() == "null")
            {
                convertedDate = DateTime.Now;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Employee> ConvertToEmployees(string filePath)
        {
            string[] fileRows = File.ReadAllLines(filePath);
            List<Employee> employees = new List<Employee>();

            foreach(string row in fileRows)
            {
                string rowWithoutWhiteSpaces = string.Join("", row.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                string[] splittedRow = rowWithoutWhiteSpaces.Split(',');

                if(splittedRow.Length == 4)
                {
                    int empId;
                    int projectId;
                    DateTime dateFrom;
                    DateTime dateTo;

                    if(Int32.TryParse(splittedRow[0], out empId) && Int32.TryParse(splittedRow[1], out projectId) &&
                        TryConvertDate(splittedRow[2], out dateFrom) && TryConvertDate(splittedRow[3], out dateTo))
                    {
                        employees.Add(new Employee(empId, projectId, dateFrom, dateTo));
                    }
                }
            }

            return employees;
        }
    }
}
