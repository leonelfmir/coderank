using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.IO.StreamWriter file = new System.IO.StreamWriter("test.txt");

            int T = int.Parse(Console.ReadLine());
            List<int[]> edges = new List<int[]>();
            for (int i = 0; i < T; i++)
            {
                int[] nm = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
                int n = nm[0];
                int m = nm[1];
                edges.Clear();
                for (int j = 0; j < m; j++)
                {
                    edges.Add(Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse));
                }
                int s = int.Parse(Console.ReadLine());

                int[] res = shortestPath(n, edges, s);

                for(int k = 1; k < res.Length; k++)
                {
                    if (res[k] != 0)
                        //file.Write(res[k] + " ");
                        Console.Write(res[k] + " ");
                }
                Console.WriteLine();
                //file.WriteLine();



            }
            //file.Close();
            //Console.Read();
        }

        static int[] shortestPath(int nodes, List<int[]> edges, int start)
        {
            Dictionary<int, HashSet<int>> D = new Dictionary<int, HashSet<int>>();
            foreach(int[] vl in edges)
            {
                if (!D.ContainsKey(vl[0]))
                    D[vl[0]] = new HashSet<int>();
                if (!D.ContainsKey(vl[1]))
                    D[vl[1]] = new HashSet<int>();

                D[vl[0]].Add(vl[1]);
                D[vl[1]].Add(vl[0]);
            }

            HashSet<int> visited = new HashSet<int>();
            int[] distance = new int[nodes + 1];

            for (int i = 0; i < distance.Length; i++)
                distance[i] = -1;

            int current = start;
            int currentDistance = 0;

            if(!D.ContainsKey(start))
            {
                distance[start] = 0;
                return distance;
            }


            Queue<int> nodeToVisit = new Queue<int>();
            Queue<int> nodeToVisitDistance = new Queue<int>();

            nodeToVisit.Enqueue(start);
            nodeToVisitDistance.Enqueue(0);

            while (nodeToVisit.Count > 0)
            {
                current = nodeToVisit.Dequeue();
                currentDistance = nodeToVisitDistance.Dequeue();

                if (visited.Contains(current))
                    continue;

                visited.Add(current);
                distance[current] = currentDistance;

                foreach(int vl in D[current])
                {
                    if(!visited.Contains(vl) && !nodeToVisit.Contains(vl))
                    {
                        nodeToVisit.Enqueue(vl);
                        nodeToVisitDistance.Enqueue(currentDistance + 6);
                    }
                }

            }

            return distance;

        }
    }
}
