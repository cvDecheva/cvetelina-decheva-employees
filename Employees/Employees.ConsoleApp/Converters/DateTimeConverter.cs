using System;
using System.Globalization;

namespace Employees.ConsoleApp.Coverters
{
    public class DateTimeConverter
    {
        private static readonly string[] dateTimeFormats = new string[]
        {
            "yyyy-MM-dd",
            "dd/MM/yyyy",
            "d/MM/yyyy",
            "dd.MM.yyyy",
            "d/MM/yyyy",
            "yyyy-M-d",
            "d.M.yyyy",
            "dd-MM-yyyy",
            "MM/dd/yyyy",
            "d.MM.yyyy",
            "d/M/yyyy",
            "yyyy年M月d日",
            "MM-dd-yyyy",
            "dd.MM.yyyy.",
            "yyyy.MM.dd.",
            "३/६/१२",
            "yyyy/MM/dd",
            "H24.MM.dd",
            "yyyy. M. d",
            "yyyy.M.d",
            "yyyy.d.M",
            "d.M.yyyy.",
            "d-M-yyyy",
            "M/d/yyyy",
            "d/M/2555",
            "๓/๖/๒๕๕๕",
            "yyyy/M/d",
            "dd/M/yyyy",
            "yyyyMdd"
        };

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
            else
            {
                foreach(string format in dateTimeFormats)
                {
                    if(DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out convertedDate))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
