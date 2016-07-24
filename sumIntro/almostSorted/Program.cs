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
            string path = "08";
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

            for (int i = 1; i < A.Length; i++)
            {
                bool left = false, right = false;

                if (i != 0 && A[i - 1] > A[i])
                    left = true;

                if (i != A.Length - 1 && A[i] > A[i + 1])
                    right = true;

                if (right || left)
                    badElements.Add(i);
            }

            if (badElements.Count == 0)
                return "yes";

            if (badElements.Count <= 2 || badElements.Count == 4)
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
            int[] B = new int[A.Length];

            if (badElements.Count == 1)
            {
                badElements.Add(badElements[0]);
                badElements[0]--;
            }

            if (badElements.Count == 2)
            {
                A.CopyTo(B, 0);
                swap(B, badElements[0], badElements[1]);
                if (isSorted(B))
                    return string.Format("yes\nswap {0} {1}", badElements[0] + 1, badElements[1] + 1);
            }
            else
            {
                //0-2
                A.CopyTo(B, 0);
                swap(B, badElements[0], badElements[2]);
                if (isSorted(B))
                    return string.Format("yes\nswap {0} {1}", badElements[0] + 1, badElements[2] + 1);
                //0-3
                A.CopyTo(B, 0);
                swap(B, badElements[0], badElements[3]);
                if (isSorted(B))
                    return string.Format("yes\nswap {0} {1}", badElements[0] + 1, badElements[3] + 1);
                //1-2
                A.CopyTo(B, 0);
                swap(B, badElements[1], badElements[2]);
                if (isSorted(B))
                    return string.Format("yes\nswap {0} {1}", badElements[1] + 1, badElements[2] + 1);
                //1-3
                A.CopyTo(B, 0);
                swap(B, badElements[1], badElements[3]);
                if (isSorted(B))
                    return string.Format("yes\nswap {0} {1}", badElements[1] + 1, badElements[3] + 1);
            }

            return null;
        }

        static void swap(int[] A, int pos1, int pos2)
        {
            int temp = A[pos1];
            A[pos1] = A[pos2];
            A[pos2] = temp;
        }

        static string reverse(List<int> badElements, int[] A)
        {
            Array.Reverse(A, badElements[0], badElements.Count);
            //Array.Sort(A, badElements[0], badElements.Count);
            if (isSorted(A))
            //if (isSortedRerverse(A, badElements[0], badElements[badElements.Count - 1]))
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

        static bool isSortedRerverse(int[] A, int l, int r)
        {
            for (int i = r; i >= l; i--)
            {
                if (A[i - 1] < A[i])
                    return false;
            }
            if (A[l - 1] > A[r])
                return false;
            if (r < A.Length - 1 && A[r] > A[r + 1])
                return false;

            return true;
        }
    }
}
