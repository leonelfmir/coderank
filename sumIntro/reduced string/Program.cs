using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reduced_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "cbaabbbc";

            bool[] sp = new bool[s.Length];

            int l = 0;
            int r = 1;

            while(r < s.Length)
            {
                if(s[r] != s[l])
                {
                    l = r;
                    r++;
                }
                else
                {
                    sp[l] = true;
                    sp[r] = true;
                    while(l >= 0)
                    {
                        if (sp[l] == false)
                            break;
                        l--;
                    }

                    r++;

                    if (l < 0)
                    {
                        l = r;
                        r++;
                    }
                }
            }

            StringBuilder res = new StringBuilder();
            
            for(int i = 0; i < sp.Length; i++)
            {
                if (sp[i] == false)
                    res.Append(s[i]);
            }

            if (res.Length == 0)
                res.Append("Empty String");

            Console.WriteLine(res);
            Console.Read();
        }
    }
}
