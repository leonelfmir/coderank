using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            //string time = Console.ReadLine();
            string time = "12:59:59AM";

            //int h = int.Parse(time.Substring(0, 2));
            //string mil = "";

            //if (time[time.Length - 2] == 'P')
            //{
            //    if (h == 12)
            //        mil = h.ToString();
            //    else
            //        mil = (h + 12).ToString();

            //    time = String.Concat(mil, time.Substring(2, time.Length - 4));
            //}
            //else
            //{
            //    if (h == 12)
            //        time = String.Concat("00", time.Substring(2, time.Length - 4));
            //}

            //string[] res = time.Split(':');

            var tt = Convert.ToDateTime(time);
            string rres = tt.ToString("HH:mm:ss", CultureInfo.CurrentCulture);
            Console.WriteLine(rres);

            Console.Read();

            int[] A = { 1, 2 };
            int c = A.Count(x => x <= 0);
        }
    }
}
