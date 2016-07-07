using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AorB2
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                int k = Convert.ToInt32(Console.ReadLine());
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                string c = Console.ReadLine();

                abc(k, a, b, c);

            }
            Console.Read();
        }

        static void abc(int k, string a, string b, string c)
        {
            string bsa = String.Join(String.Empty,
              a.Select(
                x => Convert.ToString(Convert.ToInt32(x.ToString(), 16), 2).PadLeft(4, '0')
              )
            );

            string bsb = String.Join(String.Empty,
              b.Select(
                x => Convert.ToString(Convert.ToInt32(x.ToString(), 16), 2).PadLeft(4, '0')
              )
            );

            string bsc = String.Join(String.Empty,
              c.Select(
                x => Convert.ToString(Convert.ToInt32(x.ToString(), 16), 2).PadLeft(4, '0')
              )
            );

            //get maximum
            int max = Math.Max(bsa.Length, Math.Max(bsb.Length, bsc.Length));
            char[] ca = bsa.PadLeft(max, '0').ToCharArray();
            char[] cb = bsb.PadLeft(max, '0').ToCharArray();
            char[] cc = bsc.PadLeft(max, '0').ToCharArray();

            int changes = minimumchanges(ref ca, ref cb, cc);

            if (changes > k)
            {
                Console.WriteLine("-1");
                return;
            }

            if (changes < k)
                minimize(ref ca, ref cb, k - changes);

            string res = string.Format("{0}\n{1}", convertBinToHex(ca), convertBinToHex(cb));
            Console.WriteLine(res);

        }

        static int minimumchanges(ref char[] a, ref char[] b, char[] c)
        {
            int k = 0;
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == '0')
                {
                    if (a[i] == '1')
                    {
                        a[i] = '0';
                        k++;
                    }
                    if (b[i] == '1')
                    {
                        b[i] = '0';
                        k++;
                    }
                }
                else
                {
                    if (a[i] == '0' && b[i] == '0')
                    {
                        b[i] = '1';
                        k++;
                    }
                }
            }
            return k;
        }

        static void minimize(ref char[] a, ref char[] b, int k)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (k == 0)
                    return;
                if (a[i] == '1' && b[i] == '1')
                {
                    a[i] = '0';
                    k--;
                }
                if (a[i] == '1' && b[i] == '0' && k > 1)
                {
                    a[i] = '0';
                    b[i] = '1';
                    k -= 2;
                }

            }
        }

        static string convertBinToHex(char[] ch)
        {
            StringBuilder A = new StringBuilder();
            StringBuilder As = new StringBuilder();

            int ln = 4;
            int cn = 0;
            for (int i = 0; i < ch.Length; i++)
            {
                cn++;
                As.Append(ch[i]);
                if (cn % ln == 0)
                {
                    A.AppendFormat("{0:X}", Convert.ToByte(As.ToString(), 2));
                    As.Clear();
                }
            }

            return A.ToString().TrimStart('0');
        }

        //static void printarr(char[] arr)
        //{
        //    foreach (var c in arr)
        //    {
        //        Console.Write(c + " ");
        //    }
        //    Console.WriteLine();
        //}
    }
}
