using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kangaroo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tokens_x1 = "0 3 4 2".Split(' ');
            int x1 = Convert.ToInt32(tokens_x1[0]);
            int v1 = Convert.ToInt32(tokens_x1[1]);
            int x2 = Convert.ToInt32(tokens_x1[2]);
            int v2 = Convert.ToInt32(tokens_x1[3]);

            int slowV = 0, fastV = 0, slowX = 0, fastX = 0;
            string res = "NO";
            if(v1 > v2)
            {
                fastV = v1;
                fastX = x1;
                slowV = v2;
                slowX = x2;
            }
            else
            {
                fastV = v2;
                fastX = x2;
                slowV = v1;
                slowX = x1;
            }

            while(fastX < slowX)
            {
                fastX += fastV;
                slowX += slowV;
            }

            if(fastX == slowX)
            {
                res = "YES";
            }

            Console.WriteLine(res);
            Console.Read();
        }
    }
}
