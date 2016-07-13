using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaprekarNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int p = int.Parse(Console.ReadLine());
            int q = int.Parse(Console.ReadLine());
            var res = kprs(p, q);
            Console.WriteLine("{0}",res.Count > 0? string.Join(" ", res): "INVALID RANGE");

            Console.Read();
        }

        static List<int> kprs(int low, int high)
        {
            List<int> L = new List<int>();
            for (; low <= high; low++)
            {
                if (isKpr((double)low))
                    L.Add(low);
            }

            return L;
        }

        static bool isKpr(double x)
        {
            string s = (x * x).ToString();
            double l = double.TryParse(s.Substring(0, s.Length / 2),out l)?l:0;
            double r = double.TryParse(s.Substring(s.Length / 2), out r)? r:0;

            if (r + l == x)
                return true;

            return false;
        }
    }
}
