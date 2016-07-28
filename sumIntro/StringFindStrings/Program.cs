using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringFindStrings
{
    class Program
    {
        /* Head ends here */
        static void findStrings(String[] a, int[] querry)
        {
            HashSet<string> hs = new HashSet<string>();
            Dictionary<string, HashSet<string>> D = new Dictionary<string, HashSet<string>>();
            foreach (string item in a)
            {
                hs.UnionWith(getSubstrings(item.Trim(), D));
            }

            var res = hs.OrderBy(x => x);

            foreach (var item in querry)
            {
                if (item -1< res.Count())
                    Console.WriteLine(res.ElementAt(item-1));
                else
                    Console.WriteLine("INVALID");
            }
        }

        static HashSet<string> getSubstrings(string s, Dictionary<string, HashSet<string>> D)
        {
            
            if (D.ContainsKey(s))
                return D[s];

            D[s] = new HashSet<string>();
            D[s].Add(s);

            if (s.Length > 1)
            {
                D[s].UnionWith(getSubstrings(s.Substring(0, s.Length - 1), D));
                D[s].UnionWith(getSubstrings(s.Substring(1, s.Length - 1), D));

            }

            return D[s];
        }

        /* Tail starts here */
        static void Main(String[] args)
        {
            int _cases = Convert.ToInt32(Console.ReadLine());
            String[] _a = new String[_cases];
            for (int _a_i = 0; _a_i < _cases; _a_i++)
            {
                _a[_a_i] = Console.ReadLine();
            }

            int _query = Convert.ToInt32(Console.ReadLine());
            int[] query = new int[_query];

            for (int _a_i = 0; _a_i < _query; _a_i++)
            {
                query[_a_i] = Convert.ToInt32(Console.ReadLine());
            }

            findStrings(_a, query);
        }
    }
}
