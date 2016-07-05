using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEautifuk_Binary_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string B = "0100101010";

            string toReplace = "010";
            int res = 0;
            for (int i = 2; i < B.Length;i++)
            {
                if(B.Substring(i-2,3) == toReplace)
                {
                    res++;
                    i += 2;
                }
            }

            Console.WriteLine(res);
            Console.Read();
        }
    }
}
