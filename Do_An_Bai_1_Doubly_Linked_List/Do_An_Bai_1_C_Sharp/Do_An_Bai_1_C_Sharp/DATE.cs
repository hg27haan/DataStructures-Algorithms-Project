using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_An_Bai_1_C_Sharp
{
    public class DATE
    {
        private int Month; // 1-12
        private int Day; // 1-31 based on month
        private int Year; // any year // constructor confirms proper value for month;

        public int month { get => Month; set => Month = value; }
        public int day { get => Day; set => Day = value; }
        public int year { get => Year; set => Year = value; }

        // call method Check Day to confirm proper value for day
        public DATE(int theMonth, int theDay, int theYear)
        {
            // validate month
            if (theMonth > 0 && theMonth <= 12) Month = theMonth;
            else
            {
                Month = 1;
                Console.WriteLine("Thang {0} khong hop le. Tam thoi dua ve 1", theMonth);
            }
            Year = theYear;
            Day = CheckDay(theDay);
            // could validate year
            // validate day
        }
        private int CheckDay(int testDay)
        {
            int[] daysPerMonth =
          {0, 31,28,31,30,31,30,31,31,30,31,30,31 };
            // check if day in range for month
            if (testDay > 0 && testDay <= daysPerMonth[Month]) return testDay;
            // check for leap year
            if (Month == 2 && testDay == 29 && (Year % 400 == 0 || (Year % 4 == 0 && Year % 100 != 0)))
                return testDay;
            Console.WriteLine("Ngay {0} khong hop le. Tam thoi dua ve 1.", testDay);
            return 1; // leave object in consistent state
        }
        // return date string as month/day/year public string ToDateString()
        public string ToDateString()
        {
            return Month + "/" + Day + "/" + Year;
        }
    }
}
