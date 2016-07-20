using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace almostSorted
{
    class Program
    {
        static void Main(string[] args)
        {
            //int t = int.Parse(Console.ReadLine());
            //int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            string path = "01";
            string[] lines = System.IO.File.ReadAllLines("input" + path + ".txt");

            int t = int.Parse(lines[0]);
            int[] A = Array.ConvertAll(lines[1].Split(' '), int.Parse);

            //System.IO.File.WriteAllText("Output" + path + ".txt", isAlmostSorted(A));

            Console.WriteLine(isAlmostSorted(A));
            Console.Read();
        }

        static string isAlmostSorted(int[] A)
        {
            List<int> badElements = new List<int>();

            for (int i = 0; i < A.Length; i++)
            {
                bool left = false, right = false;

                if ( i != 0 && A[i - 1] > A[i])
                    left = true;

                if (i != A.Length - 1 && A[i] > A[i+1])
                    right = true;

                if (right || left)
                    badElements.Add(i);
            }

            if (badElements.Count == 0)
                return "yes";

            if (badElements.Count == 2 || badElements.Count == 4)
            {
                string swp = swap(badElements, A);
                if (swp != null)
                    return swp;
            }

            string rv = reverse(badElements, A);
            if (rv != null)
                return rv;

            return "no";
        }

        static string swap(List<int> badElements, int[] A)
        {
            if (badElements.Count == 2)
            {
                int temp = A[badElements[0]];
                A[badElements[0]] = A[badElements[1]];
                A[badElements[1]] = temp;
            }
            else
            {
                int temp = A[badElements[1]];
                A[badElements[1]] = A[badElements[3]];
                A[badElements[3]] = temp;
            }

            if (isSorted(A))
                return string.Format("yes\nswap {0} {1}", badElements[0] + 1, badElements[1] + 1);

            return null;
        }

        static string reverse(List<int> badElements, int[] A)
        {

            Array.Sort(A, badElements[0], badElements.Count);
            if (isSorted(A))
                return string.Format("yes\nreverse {0} {1}", badElements[0] + 1, badElements[badElements.Count - 1] + 1);

            return null;
        }

        static bool isSorted(int[] A)
        {
            for (int i = 1; i < A.Length; i++)
            {
                if (A[i - 1] > A[i])
                    return false;
            }

            return true;
        }
    }
}
