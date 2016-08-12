using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPBiggestPerimeterChart
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] RC = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int R = RC[0];
            int C = RC[1];
            string[] G = new string[R];
            for (int i = 0; i < R; i++)
            {
                G[i] = Console.ReadLine();
            }

            Console.WriteLine(sol(R, C, G));
            Console.Read();
        }

             static string sol(int R, int C, string[] G)
        {
            int[,][] Gp = new int[R, C][];
            int sum = 0;
            //getting rows
            for (int r = 0; r < R; r++)
            {
                sum = 0;
                for (int c = 0; c < C; c++)
                {
                    if (G[r][c] == 'x')
                    {
                        sum = -1;
                    }

                    Gp[r, c] = new int[] { sum, 0, 0 };
                    sum++;
                }
            }

            //getting columns
            for (int c = 0; c < C; c++)
            {
                sum = 0;
                for (int r = 0; r < R; r++)
                {
                    if (G[r][c] == 'x')
                    {
                        sum = -1;
                    }

                    Gp[r, c][1] = sum;
                    sum++;
                }
            }

            int max = 0;
            int tempSum = 0;
            int tempMin = 0;
            int res = 0;
            int[] test;
            for (int r = 1; r < R; r++)
            {
                for (int c = 1; c < C; c++)
                {
                    if (Gp[r, c][1] > 0)
                    {
                        max = 0;
                        //tempMin = Gp[r, c][1];
                        //if (r == 22 && c == 197)
                        if (r == 15 && c == 8)
                            r = r;
                        HashSet<int> used = new HashSet<int>();
                        for (int k = 1; k <= Gp[r, c][0]; k++)
                        {
                            used.Add(Gp[r, c - k][1]+1);
                            tempMin = Math.Min(Gp[r, c - k][1], Gp[r, c][1]);
                            for(int hh = tempMin; hh <= Gp[r, c][1]; hh++)
                            {
                                if (G[r - hh][c - k] == 'x')
                                    used.Add(hh);
                            }

                            while(tempMin > 0 && used.Contains(tempMin))
                            {
                                tempMin--;
                            }

                            if (tempMin > 0)
                            {
                                tempSum = k + tempMin;
                                if (tempSum > max)
                                {
                                    max = tempSum;
                                    if(tempSum == 20)
                                        test = new int[] { r, c, k, tempMin};
                                }
                            }
                        }

                        Gp[r, c][2] = max;
                    }

                    res = Math.Max(Gp[r, c][2], res);
                    if (res == 20)
                        continue;
                    
                }
            }

            string s = printChar(G, Gp, R, C);
            return res == 0? "impossible": (res * 2).ToString();
        }

        static string printChar(string[] G, int[,][] Gp, int R, int C)
        {
            StringBuilder s = new StringBuilder();
            for (int r = 0; r < R; r++)
            {
                s.Append("\n");
                for (int c = 0; c < C; c++)
                {
                    if (G[r][c] == 'x')
                        s.Append("x".PadLeft(5));
                    else
                        s.Append(Gp[r, c][2].ToString().PadLeft(5));
                }
            }
            System.IO.File.WriteAllText("Output" + ".txt", s.ToString());

            return s.ToString();
        }
    }
}
