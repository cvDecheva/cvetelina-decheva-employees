using System;
using System.Globalization;

namespace Employees.ConsoleApp.Coverters
{
    public class DateTimeConverter
    {
        public static bool ConvertStringToDate(string date, out DateTime convertedDate)
        {
            if(date.ToLower() == "null")
            {
                convertedDate = DateTime.Now;
                return true;
            }
            else if(DateTime.TryParse(date, out convertedDate))
            {
                return true;
            }
            else if(DateTime.TryParseExact(date, "dd/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out convertedDate))
            {
                return true;
            }
            else if(DateTime.TryParseExact(date, "yyyyMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out convertedDate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
