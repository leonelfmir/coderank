﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipBits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2147483647;
            
            Console.WriteLine((uint)n ^ uint.MaxValue);

            Console.Read();
        }
    }
}
