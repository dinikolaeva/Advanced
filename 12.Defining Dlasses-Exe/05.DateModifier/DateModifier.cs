using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {  
        public static int GetDifference(string startDate, string endDate)
        {
            DateTime start = DateTime.ParseExact($"{startDate}", "yyyy MM dd",
                                      System.Globalization.CultureInfo.InvariantCulture);
            DateTime end = DateTime.ParseExact($"{endDate}", "yyyy MM dd",
                                      System.Globalization.CultureInfo.InvariantCulture);

            var difference = Math.Abs((end - start).Days);

            return difference;
        }

        private string date;

        public string Date
        {
            get { return this.date; }
            set { this.date = value; }
        }
    }
}
