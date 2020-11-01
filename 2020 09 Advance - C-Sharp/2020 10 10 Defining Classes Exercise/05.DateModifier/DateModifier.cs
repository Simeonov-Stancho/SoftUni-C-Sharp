using System;
using System.Collections.Generic;
using System.Text;

namespace _05.DateModifier
{
    public class DateModifier
    {
        private string startDate;
        private string endDate;

        public DateModifier(string startDate, string endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public static int CalculatesDiff(DateModifier input)
        {
            var firstdate = Convert.ToDateTime(input.startDate);
            var secondDate = Convert.ToDateTime(input.endDate);

            var difference = Math.Abs(Convert.ToInt32((firstdate - secondDate).TotalDays));

            return difference;
        }
    }
}
