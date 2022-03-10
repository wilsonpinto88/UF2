using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parquímetro
{
    static class Time
    {
        public static string GetDate(DateTime time)
        {
            int day = time.Day;
            int month = time.Month;
            int year = time.Year;

            // String interpolation, avoid using the "+" sign
            return $"{day}/{month}/{year}";

        }

        public static string GetHours(DateTime time)
        {
            int hours = time.Hour;
            // minutes has to be a string, because we have to add a zero if minutes are between 0 and 9 -> Ternary operator 
            string minutes = time.Minute < 10 ? $"0{time.Minute}" : time.Minute.ToString();

            return $"{hours}:{minutes}";
        }
    }
}
