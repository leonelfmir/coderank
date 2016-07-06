using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LonelyInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            

        }

        static int lonelyinteger(int[] a)
        {
            HashSet<int> h = new HashSet<int>();
            foreach(int vl in a)
            {
                if (h.Contains(vl))
                    h.Remove(vl);
                else
                    h.Add(vl);
            }

            return h.First();
        }
    }
}
