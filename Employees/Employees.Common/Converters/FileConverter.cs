using Employees.Common.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Employees.Common.Coverters
{
    public class FileConverter
    {
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

                    if(int.TryParse(splittedRow[0], out empId) && int.TryParse(splittedRow[1], out projectId) &&
                        DateTimeConverter.ConvertStringToDate(splittedRow[2], out dateFrom) && 
                        DateTimeConverter.ConvertStringToDate(splittedRow[3], out dateTo) && 
                        dateFrom <= dateTo)
                    {
                        employees.Add(new Employee(empId, projectId, new Period(dateFrom, dateTo)));
                    }
                }
            }

            return employees;
        }
    }
}
