using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Core.Helper
{
    public static class ConvertDate
    {
        public static string GetPrsianDate(this DateTime Date)
        {
            //1400 مرداد شنبه
            //var calendar = new PersianCalendar();
            //var result = Date.ToString("yyyy MMM ddd", CultureInfo.GetCultureInfo("fa-Ir"));

            PersianCalendar jc = new PersianCalendar();
            return string.Format("{0:0000}/{1:00}/{2:00}", jc.GetYear(Date), jc.GetMonth(Date), jc.GetDayOfMonth(Date));

        }
        public static DateTime GetgregorianDate(this string persianDate)
        {
            CultureInfo persianCulture = new CultureInfo("fa-IR");
            DateTime persianDateTime = DateTime.ParseExact(persianDate, "yyyy/MM/dd", persianCulture);    // this parses the date as if it were Gregorian
            persianDateTime = persianDateTime.AddHours(23).AddMinutes(59).AddSeconds(59);
            return persianDateTime;

        }
    }
}
