using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace practiceRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = @"ab #1?AZa$ab #1?AZa$";

            string pt = @"r'^([a-z]\w\s\W\d\D[A-Z][a-zA-Z][aeiouAEIOU]\S)\1$'";

            Match m = Regex.Match(s, pt);

        }
    }
}
