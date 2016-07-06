using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] A = { "Alex", "Michael", "Harry", "Dave", "Michael", "Victor", "Harry", "Alex", "Mary" };

            Dictionary<string, int> D = new Dictionary<string, int>();

            foreach(string vl in A)
            {
                if (!D.ContainsKey(vl))
                    D[vl] = 0;
                D[vl]++;
            }

            int max = 0;
            string maxs = "";
            foreach(KeyValuePair<string, int> kv in D)
            {
                if (kv.Value > max)
                {
                    max = kv.Value;
                    maxs = kv.Key;
                }
                else if (kv.Value == max)
                {
                    if (kv.Key.CompareTo(maxs) == 1)
                    {
                        maxs = kv.Key;
                    }
                }
                
            }

            Console.WriteLine(maxs);
            Console.ReadLine();
        }
    }
}
