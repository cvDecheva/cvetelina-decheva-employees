using System;

namespace Employees.Common.Entities
{
    public class Period
    {
        public DateTime Start
        {
            get;
            private set;
        }

        public DateTime End
        {
            get;
            private set;
        }

        public Period(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public int GetDays()
        {
            return (int)(End - Start).TotalDays;
        }
    }
}
