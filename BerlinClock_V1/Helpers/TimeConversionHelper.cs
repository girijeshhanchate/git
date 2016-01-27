using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Helpers
{
    public static class TimeConversionHelper
    {
        //yellow lamp that blinks on/off every two seconds. Reminder 0 means Y else O
        public static char BuildFirstSeries(this int second)
        {
            return (second % 2) == 0 ? 'Y' : 'O';
        }


        //Indicate hours of a day, Every lamp represents 5 hours
        public static string BuildSecondSeries(this int hour)
        {
            //e.x. 23/5=4;  11/5=2
            return BuildSeriesForHours(hour / 5);
        }

        //every lamp represents 1 hour
        public static string BuildThirdSeries(this int hour)
        {
            //e.g 23-(23/5)*5=3; 13-(13/5)*5=3
            return BuildSeriesForHours(hour - (hour / 5) * 5);
        }

        //In the first row every lamp represents 5 minutes. 
        //In this first row the 3rd, 6th and 9th lamp are red and indicate the first quarter
        public static string BuildFourthSeries(this int min)
        {
            var spots = min / 5;
            var builder = new StringBuilder();

            for (var i = 0; i < 11; i++)
            {
                if (i < spots)
                {
                    if (i == 2 || i == 5 || i == 8)
                    {
                        builder.Append('R');
                    }
                    else
                    {
                        builder.Append('Y');
                    }
                }
                else
                {
                    builder.Append('O');
                }
            }

            return builder.ToString();
        }

        //every lamp represents 1 minute
        public static string BuildFifthSeries(this int min)
        {
            var spots = min - (min / 5) * 5;
            var builder = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                builder.Append(i < spots ? 'Y' : 'O');
            }

            return builder.ToString();
        }

        //If 5 hrs - R else O
        public static string BuildSeriesForHours(this int spots)
        {
            var builder = new StringBuilder();

            for (var i = 0; i < 4; i++)
            {
                builder.Append(i < spots ? 'R' : 'O');
            }

            return builder.ToString();
        }
    }
}
