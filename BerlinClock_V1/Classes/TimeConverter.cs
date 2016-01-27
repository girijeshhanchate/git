using System;
using BerlinClock.Helpers;

namespace BerlinClock.Classes
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            if (aTime != null && aTime.Trim().Equals("24:00:00", StringComparison.CurrentCultureIgnoreCase))
                return string.Format("Y\r\nRRRR\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO");

            char firstSeries;
            string secondSeries;
            string thirdSeries;
            string fourthSeries;
            string fifthSeries;
            try
            {
                var time = Convert.ToDateTime(aTime ?? string.Empty);

                firstSeries = time.Second.BuildFirstSeries();
                secondSeries = time.Hour.BuildSecondSeries();
                thirdSeries = time.Hour.BuildThirdSeries();
                fourthSeries = time.Minute.BuildFourthSeries();
                fifthSeries = time.Minute.BuildFifthSeries();
            }
            catch (FormatException)
            {
                return string.Format("Y\nRRRR\nRRRR\nOOOOOOOOOOO\nOOOO");
            }

            return string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}",
                firstSeries, secondSeries, thirdSeries, fourthSeries, fifthSeries);
        }
    }
}


