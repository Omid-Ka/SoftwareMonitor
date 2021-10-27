//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Text.RegularExpressions;


//namespace Core.Helper
//{
//    public static class Helpers
//    {
//        public static int LevenshteinDistance(string s, string t)
//        {
//            int n = s.Length;
//            int m = t.Length;
//            int[,] d = new int[n + 1, m + 1];

//            // Step 1
//            if (n == 0)
//            {
//                return m;
//            }

//            if (m == 0)
//            {
//                return n;
//            }

//            // Step 2
//            for (int i = 0; i <= n; d[i, 0] = i++)
//            {
//            }

//            for (int j = 0; j <= m; d[0, j] = j++)
//            {
//            }

//            // Step 3
//            for (int i = 1; i <= n; i++)
//            {
//                //Step 4
//                for (int j = 1; j <= m; j++)
//                {
//                    // Step 5
//                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

//                    // Step 6
//                    d[i, j] = Math.Min(
//                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
//                        d[i - 1, j - 1] + cost);
//                }
//            }
//            // Step 7
//            return d[n, m];
//        }







//        public static DateTime? ToGregorianDate(this string dateStr)
//        {
//            if (string.IsNullOrEmpty(dateStr)) return null;
//            Match match1 = Regex.Match(dateStr, @"(\d{4})/(\d{2})/(\d{2})");
//            Match match2 = Regex.Match(dateStr, @"(\d{2})/(\d{2})/(\d{2})");
//            Match match3 = Regex.Match(dateStr, @"(\d{4})(\d{2})(\d{2})$");
//            Match match4 = Regex.Match(dateStr, @"(\d{2})(\d{2})(\d{2})$");

//            if (match1.Success)
//            {
//                var persianDate = new PersianDate(int.Parse(match1.Groups[1].Value), int.Parse(match1.Groups[2].Value), int.Parse(match1.Groups[3].Value));
//                return persianDate.ToGregorianDateTime().Date;
//            }
//            if (match2.Success)
//            {
//                var persianDate = new PersianDate(1300 + int.Parse(match2.Groups[1].Value), int.Parse(match2.Groups[2].Value), int.Parse(match2.Groups[3].Value));
//                return persianDate.ToGregorianDateTime().Date;
//            }
//            if (match3.Success)
//            {
//                var persianDate = new PersianDate(int.Parse(match3.Groups[1].Value), int.Parse(match3.Groups[2].Value), int.Parse(match3.Groups[3].Value));
//                return persianDate.ToGregorianDateTime().Date;
//            }
//            if (match4.Success)
//            {
//                var persianDate = new PersianDate(1300 + int.Parse(match4.Groups[1].Value), int.Parse(match4.Groups[2].Value), int.Parse(match4.Groups[3].Value));
//                return persianDate.ToGregorianDateTime().Date;
//            }
//            return null;
//        }


//        public static PersianDate? ToPersianDate(this string dateStr)
//        {
//            if (string.IsNullOrEmpty(dateStr)) return null;
//            Match match1 = Regex.Match(dateStr, @"(\d{4})/(\d{2})/(\d{2})");
//            Match match2 = Regex.Match(dateStr, @"(\d{2})/(\d{2})/(\d{2})");
//            Match match3 = Regex.Match(dateStr, @"(\d{4})(\d{2})(\d{2})$");
//            Match match4 = Regex.Match(dateStr, @"(\d{2})(\d{2})(\d{2})$");

//            if (match1.Success)
//            {
//                var persianDate = new PersianDate(int.Parse(match1.Groups[1].Value), int.Parse(match1.Groups[2].Value), int.Parse(match1.Groups[3].Value));
//                return persianDate;
//            }
//            if (match2.Success)
//            {
//                var persianDate = new PersianDate(1300 + int.Parse(match2.Groups[1].Value), int.Parse(match2.Groups[2].Value), int.Parse(match2.Groups[3].Value));
//                return persianDate;
//            }
//            if (match3.Success)
//            {
//                var persianDate = new PersianDate(int.Parse(match3.Groups[1].Value), int.Parse(match3.Groups[2].Value), int.Parse(match3.Groups[3].Value));
//                return persianDate;
//            }
//            if (match4.Success)
//            {
//                var persianDate = new PersianDate(1300 + int.Parse(match4.Groups[1].Value), int.Parse(match4.Groups[2].Value), int.Parse(match4.Groups[3].Value));
//                return persianDate;
//            }
//            return null;
//        }

//        public static string RemoveSpaces(this string str)
//        {
//            return str.Trim().Replace(" ", "");
//        }


//        public static int GetPersianYear(this DateTime dateTime)
//        {
//            PersianDate p = new PersianDate(dateTime);
//            return p.Year;
//        }
//        public static int GetPersianMonth(this DateTime dateTime)
//        {
//            PersianDate p = new PersianDate(dateTime);
//            return p.Month;
//        }

//        public static string GetPersianMonthName(this int month)
//        {
//            var monthres = "";

//            switch (month)
//            {
//                case 1:
//                    monthres = "فروردین";
//                    break;
//                case 2:
//                    monthres = "اردیبهشت";
//                    break;
//                case 3:
//                    monthres = "خرداد";
//                    break;
//                case 4:
//                    monthres = "تیر";
//                    break;
//                case 5:
//                    monthres = "مرداد";
//                    break;
//                case 6:
//                    monthres = "شهریور";
//                    break;
//                case 7:
//                    monthres = "مهر";
//                    break;
//                case 8:
//                    monthres = "آبان";
//                    break;
//                case 9:
//                    monthres = "آذر";
//                    break;
//                case 10:
//                    monthres = "دی";
//                    break;
//                case 11:
//                    monthres = "بهمن";
//                    break;
//                case 12:
//                    monthres = "اسفند";
//                    break;
//                default:
//                    monthres = "";
//                    break;
//            }

//            return monthres;
//        }

//        public static string ToPersianDateTime(this DateTime? dateTime)
//        {
//            if (dateTime == null) return "";
//            PersianDate p = new PersianDate(dateTime.Value);
//            return p.ToShortDateString() + " | " + dateTime.Value.ToString("T");
//        }

//        public static string ToPersianDateTime(this DateTime dateTime)
//        {
//            if (dateTime == null) return "";
//            PersianDate p = new PersianDate(dateTime);
//            return p.ToShortDateString() + " | " + dateTime.ToString("T");
//        }

//        public static string ToPersianDate(this DateTime dateTime)
//        {
//            if (dateTime == null) return "";
//            PersianDate p = new PersianDate(dateTime);
//            return p.ToShortDateString();
//        }


//        public static Int64 ConvertToInt64OrDefault(Object obj)
//        {

//            Int64 o = 0;
//            var input = obj.ToString();
//            if (string.IsNullOrWhiteSpace(input))
//                return 0;

//            Int64.TryParse(input, out o);

//            return o;
//        }

//        public static Int32 ConvertToInt32OrDefault(Object obj)
//        {

//            Int32 o = 0;
//            var input = obj.ToString();
//            if (string.IsNullOrWhiteSpace(input))
//                return 0;

//            Int32.TryParse(input, out o);

//            return o;
//        }

//        public static double ToDouble(string time)
//        {
//            var splitData = time.Split(':');
//            double result = 0;
//            if (splitData.Any())
//                result = (double.Parse(splitData[0]) + (double.Parse(splitData[1]) / (60.0)));
//            return Math.Round(result, 4);

//        }

//        public static string ToHour(double data)
//        {
//            var hour = (int)Math.Truncate(data);
//            var minute = (int)(Math.Ceiling((data - hour) * 60));
//            return hour.ToString().PadLeft(3, '0') + minute.ToString().PadLeft(2, '0');
//        }
//        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
//        {
//            try
//            {
//                List<T> list = new List<T>();
//                var tableEnumerable = table.AsEnumerable();
//                var props = typeof(T).GetProperties();
//                foreach (var row in tableEnumerable)
//                {
//                    T obj = new T();

//                    foreach (var prop in props)
//                    {
//                        try
//                        {
//                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
//                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
//                        }
//                        catch (Exception)
//                        {
//                            continue;
//                        }
//                    }

//                    list.Add(obj);
//                }

//                return list;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        public static List<T> DataTableToList2<T>(this DataTable table) where T : class, new()
//        {
//            try
//            {
//                List<T> list = new List<T>();

//                foreach (var row in table.AsEnumerable())
//                {
//                    T obj = new T();

//                    foreach (var prop in obj.GetType().GetProperties())
//                    {
//                        try
//                        {
//                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
//                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
//                        }
//                        catch
//                        {
//                            continue;
//                        }
//                    }

//                    list.Add(obj);
//                }

//                return list;
//            }
//            catch
//            {
//                return null;
//            }
//        }

//        #region num2Str
//        private static string[] yakan = new string[10] { "صفر", "یک", "دو", "سه", "چهار", "پنج", "شش", "هفت", "هشت", "نه" };
//        private static string[] dahgan = new string[10] { "", "", "بیست", "سی", "چهل", "پنجاه", "شصت", "هفتاد", "هشتاد", "نود" };
//        private static string[] dahyek = new string[10] { "ده", "یازده", "دوازده", "سیزده", "چهارده", "پانزده", "شانزده", "هفده", "هجده", "نوزده" };
//        private static string[] sadgan = new string[10] { "", "یکصد", "دویست", "سیصد", "چهارصد", "پانصد", "ششصد", "هفتصد", "هشتصد", "نهصد" };
//        private static string[] basex = new string[5] { "", "هزار", "میلیون", "میلیارد", "تریلیون" };
//        private static string getnum3(int num3)
//        {
//            string s = "";
//            int d3, d12;
//            d12 = num3 % 100;
//            d3 = num3 / 100;
//            if (d3 != 0)
//                s = sadgan[d3] + " و ";
//            if ((d12 >= 10) && (d12 <= 19))
//            {
//                s = s + dahyek[d12 - 10];
//            }
//            else
//            {
//                int d2 = d12 / 10;
//                if (d2 != 0)
//                    s = s + dahgan[d2] + " و ";
//                int d1 = d12 % 10;
//                if (d1 != 0)
//                    s = s + yakan[d1] + " و ";
//                s = s.Substring(0, s.Length - 3);
//            };
//            return s;
//        }

//        public static string NumberToLetters(this int num)
//        {
//            return NumberToLetters((long)num);
//        }

//        public static string NumberToLetters(this long num)
//        {
//            string snum = num.ToString();

//            string stotal = "";
//            if (snum == "0")
//            {
//                return yakan[0];
//            }
//            else
//            {
//                snum = snum.PadLeft(((snum.Length - 1) / 3 + 1) * 3, '0');
//                int L = snum.Length / 3 - 1;
//                for (int i = 0; i <= L; i++)
//                {
//                    int b = int.Parse(snum.Substring(i * 3, 3));
//                    if (b != 0)
//                        stotal = stotal + getnum3(b) + " " + basex[L - i] + " و ";
//                }
//                stotal = stotal.Substring(0, stotal.Length - 3);
//            }
//            return stotal;
//        }

//        #endregion

//    }
//}
