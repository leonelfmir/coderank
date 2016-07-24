using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biggerIsBetter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(biggerString("dkhc"));
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                string s = Console.ReadLine();
                Console.WriteLine(biggerString(s));
            }
        }
        
        //static string biggerString(string s)
        //{
        //    int dict = 26;
        //    int[] ch = new int[dict];

        //    foreach (var item in s)
        //    {
        //        ch[item - 'a']++;
        //    }

        //    StringBuilder sb = new StringBuilder();
        //    for (int i =dict - 1; i >= 0; i--)
        //    {
        //        if(ch[i] > 0)
        //        {
        //            sb.Append(new string((char)(i + 'a'), ch[i]));
        //        }
        //    }

        //    return sb.ToString() == s ? "no answer" : sb.ToString();

        //}

        static string biggerString(string s)
        {
            string ss = null;

            for (int i = s.Length - 2; i >=0 ; i--)
            {
                if(s[i] < s[i+1])
                {
                    ss = sorString(s.Substring(i));
                    ss = string.Concat(s.Substring(0, i), ss);
                    break;
                }
            }

            return ss ?? "no answer";
        }

        static string sorString(string s)
        {
            int min = 256;
            int pos = 0;
            for (int i = 1; i < s.Length; i++)
            {
                int temp = s[i] - s[0];
                if(temp > 0 && temp < min)
                {
                    min = temp;
                    pos = i;
                }
            }

            char[] sc = s.ToCharArray();
            char tempc = sc[pos];
            sc[pos] = s[0];
            sc[0] = tempc;

            Array.Sort(sc, 1, sc.Length - 1);

            return new string(sc);

        }

        //static bool isSorted(string A)
        //{
        //    for (int i = 1; i < A.Length; i++)
        //    {
        //        if (A[i] < A[i - 1])
        //            return false;
        //    }

        //    return true;
        //}

        //static bool isSortedReverse(string A)
        //{
        //    for (int i = 1; i < A.Length; i++)
        //    {
        //        if (A[i] > A[i - 1])
        //            return false;
        //    }

        //    return true;
        //}
    }
}
