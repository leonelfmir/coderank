using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Lisa just got a new math workbook. A workbook contains exercise problems, grouped into chapters.

There are  chapters in Lisa's workbook, numbered from  to .
The -th chapter has  problems, numbered from  to .
Each page can hold up to  problems. There are no empty pages or unnecessary spaces, so only the last page of a chapter may contain fewer
than  problems.
Each new chapter starts on a new page, so a page will never contain problems from more than one chapter.
The page number indexing starts at 1.

    Lisa believes a problem to be special if its index (within a chapter) is the same as the page number where it's located. 
    Given the details for Lisa's workbook, can you count its number of special problems?
 */

namespace WorkBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nk = Console.ReadLine().Split(' ');
            int n = int.Parse(nk[0]);
            int k = int.Parse(nk[1]);
            string[] ts = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(ts, Int32.Parse);

            //int n = 5;
            //int k = 3;
            //int[] arr = { 4, 2, 6, 1, 10 };

            Console.WriteLine(specialProblems(arr, k, n));
            Console.Read();
            
        }

        static int specialProblems(int[] A, int k, int n)
        {
            int res = 0;
            
            int pag = 0;

            for (int chap = 0; chap < n; chap++)
            {
                int prob = 1;
                while (prob <= A[chap])
                {
                    pag++;

                    if (pag >= prob && pag <= Math.Min(prob + k - 1, A[chap]))
                        res++;

                    prob += k;

                }
            }

            return res;
        }
        //int pages = 0;
        //int pag = 1;
        //pages = A[chap] / k;
        //for(; prob < pages *k; prob+=k)
        //{
        //    if (pag >= prob + 1 && pag <= prob + k)
        //        res++;
        //    pag++;
        //}

        //int mod = A[chap] % k;
        //if (mod > 0)
        //{
        //    if (pag >= prob + 1 && pag <= prob + mod)
        //        res++;
        //    pag++;
        //}
        //}

        //return res;
        //}
    }
}
