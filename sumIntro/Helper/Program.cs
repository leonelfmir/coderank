using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "11111111";

            StringBuilder A = new StringBuilder();
            StringBuilder As = new StringBuilder();

            int ln = 4;
            int cn = 0;
            for(int i = 0; i < a.Length; i++)
            {
                cn++;
                As.Append(a[i]);
                if (cn % ln == 0)
                {
                    A.AppendFormat("{0:X}", Convert.ToByte(As.ToString(), 2));
                    As.Clear();
                }
            }

            Console.WriteLine(A.ToString());

            Console.Read();
        }

        static void printb(Int64 b, string nm)
        {
            Console.WriteLine("{0} = {1}", nm, Convert.ToString(b, 2).PadLeft(66, '0'));
        }
    }
}
