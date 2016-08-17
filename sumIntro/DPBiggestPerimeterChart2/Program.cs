using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPBiggestPerimeterChart2
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
            int[,][] Gp = new int[R, C][];// left, up, perimeter
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
            int maxPossible = 0;
            //int[] test;
            //int rl = 0;
            for (int r = 1; r < R; r++)
            {
                for (int c = 1; c < C; c++)
                {
                    if (Gp[r, c][1] > 0)
                    {
                        if (r == 35 && c == 70)
                            r = r;

                        maxPossible = Gp[r, c][1] + Gp[r, c][0];
                        if (maxPossible <= res)
                            continue;

                        max = 0;
                        for (int k = Gp[r, c][1]; k > 0 ; k--)//columnh height
                        {
                            int minr = Math.Min(Gp[r - k, c][0], Gp[r, c][0]);

                            maxPossible = Gp[r, c][0] + k;
                            if (maxPossible <= res)
                                break;

                            maxPossible =  minr + k;
                            if (maxPossible <= res)
                                continue;

                            tempMin = 0;
                            for(int rl = minr; rl > 0; rl--)//row left
                            {
                                if (Gp[r, c - rl][1] >= k)
                                {
                                    tempMin = rl;
                                    break;
                                }
                            }

                            if (tempMin > 0)
                            {
                                tempSum = k + tempMin;
                                if (tempSum > max)
                                {
                                    max = tempSum;
                                    //if (tempSum == 6)
                                    //    test = new int[] { r, c, k, tempMin };
                                }
                            }
                        }

                        Gp[r, c][2] = max;
                    }

                    res = Math.Max(Gp[r, c][2], res);
                    //if (res == 20)
                    //    continue;

                }
            }

            string s = printChar(G, Gp, R, C);
            return res == 0 ? "impossible" : (res * 2).ToString();
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
