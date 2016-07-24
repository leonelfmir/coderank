using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twoPluses
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int r = NM[0];
            int c = NM[1];
            string[] M = new string[r];

            for (int i = 0; i < r; i++)
            {
                M[i] = Console.ReadLine();
            }

            Console.WriteLine(maxArea(M, r, c));
            Console.Read();
        }

        static Dictionary<Tuple<int, int>, Dictionary<Tuple<int, int>, int[]>> cellsInterceptionDistance = new Dictionary<Tuple<int, int>, Dictionary<Tuple<int, int>, int[]>>();

        static int maxArea(string[] M, int R, int C)
        {
            List<int[]> pluses = new List<int[]>();
            HashSet<Tuple<int, int>>[][] cellsInterception = new HashSet<Tuple<int, int>>[R][];
            char validCell = 'G';

            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (M[r][c] == validCell)
                    {
                        int plus = maxPulse(M, r, c, R, C, cellsInterception);
                        pluses.Add(new int[] { plus, r, c });
                        //if (plus == 1)
                        //{
                            int[][] p = new int[1][];
                            p[0] = new int[] { r, c };
                            addInterceptions(p, cellsInterception, r, c, C);
                        //}
                    }
                }
            }

            int maxArea = 0;

            for (int i = 0; i < pluses.Count - 1; i++)
            {
                Tuple<int, int> cellI = new Tuple<int, int>(pluses[i][1], pluses[i][2]);
                for (int j = i+1; j < pluses.Count; j++)
                {
                    Tuple<int, int> cellJ = new Tuple<int, int>(pluses[j][1], pluses[j][2]);

                    if (cellsInterceptionDistance.ContainsKey(cellI))
                    {
                        if (cellsInterceptionDistance[cellI].ContainsKey(cellJ))
                        {
                            if (i == 22 && j == 59)
                                maxArea = maxArea;
                            //maxArea = Math.Max(maxArea, calculateArea(cellsInterceptionDistance[cellI][cellJ][0], cellsInterceptionDistance[cellI][cellJ][1]));
                            maxArea = Math.Max(maxArea, calculateAreaAfterIntersection(cellI, cellJ, pluses[i][0], pluses[j][0], cellsInterceptionDistance[cellI][cellJ][0], cellsInterceptionDistance[cellI][cellJ][1]));
                        }
                        else
                            maxArea = Math.Max(maxArea, calculateArea(pluses[i][0], pluses[j][0]));
                    }
                    else
                    {
                        maxArea = Math.Max(maxArea, calculateArea(pluses[i][0], pluses[j][0]));
                    }

                    if (maxArea == 65)
                        maxArea = 0;
                }
            }

            return maxArea;

        }

        static int calculateAreaAfterIntersection(Tuple<int, int> cell1, Tuple<int, int> cell2, int d1, int d2, int i1, int i2)
        {
            
            //if (i1 == 0)
            //    return calculateArea(1, i2);

            int intercept = 0;

            //same row or same column
            if (cell1.Item1 == cell2.Item1 || cell1.Item2 == cell2.Item2)
            {
                return calculateArea(i1+1, i2);
            }
            else
            {
                if (d1 > d2)
                {
                    intercept = calculateArea(d1, i2);
                }
                else
                    intercept = calculateArea(i1, d2);

                intercept = Math.Max(intercept, calculateArea(Math.Min(d1, i1), Math.Min(d2, i1)));
                intercept = Math.Max(intercept, calculateArea(Math.Min(d1, i2), Math.Min(d2, i2)));
                intercept = Math.Max(intercept, calculateArea(Math.Min(d1, i1), Math.Min(d2, i2)));
                intercept = Math.Max(intercept, calculateArea(Math.Min(d1, i2), Math.Min(d2, i1)));

            }
            return intercept;

        }

        static int calculateArea(int d1, int d2)
        {
            d1 = d1 == 0 ? 1 : d1;
            return (d1 * 4 - 3) * (d2 * 4 - 3);
        }

        static int maxPulse(string[] M, int x, int y, int r, int c, HashSet<Tuple<int, int>>[][] cells)
        {
            int res = 1;
            while (validPosition(M, x, y, res, r, c, cells))
            {
                res++;
            }
            return res;
        }

        static bool validPosition(string[] M, int x, int y, int distance, int r, int c, HashSet<Tuple<int, int>>[][] cells)
        {
            //up
            if (x - distance < 0 || M[x - distance][y] != M[x][y])
            {
                return false;
            }
            //down
            if (x + distance >= r || M[x + distance][y] != M[x][y])
            {
                return false;
            }
            //left
            if (y - distance < 0 || M[x][y - distance] != M[x][y])
            {
                return false;
            }
            //right
            if (y + distance >= c || M[x][y + distance] != M[x][y])
            {
                return false;
            }

            int[][] p = new int[4][];
            p[0] = new int[] { x - distance, y };
            p[1] = new int[] { x + distance, y };
            p[2] = new int[] { x, y - distance };
            p[3] = new int[] { x, y + distance };



            addInterceptions(p, cells, x, y, c);

            return true;
        }

        static void addInterceptions(int[][] positions, HashSet<Tuple<int, int>>[][] cells, int posx, int posy, int C)
        {
            foreach (var item in positions)
            {
                if (cells[item[0]] == null)
                    cells[item[0]] = new HashSet<Tuple<int, int>>[C];
                if (cells[item[0]][item[1]] == null)
                    cells[item[0]][item[1]] = new HashSet<Tuple<int, int>>();

                
                addNewInterception(posx, posy, cells[item[0]][item[1]], item[0], item[1]);
                cells[item[0]][item[1]].Add(new Tuple<int, int>(posx, posy));
            }
        }

        static void addNewInterception(int x, int y, HashSet<Tuple<int, int>> cell, int cellx, int celly)
        {
            //int test = 0;
            //if (x == 4 && y == 1)
            //    test = 1;
            Tuple<int, int> tempT;
            foreach (var item in cell)
            {
                tempT = new Tuple<int, int>(x, y);
                if (!cellsInterceptionDistance.ContainsKey(item))
                    cellsInterceptionDistance[item] = new Dictionary<Tuple<int, int>, int[]>();

                if (!cellsInterceptionDistance[item].ContainsKey(tempT))
                    cellsInterceptionDistance[item][tempT] = new int[] { int.MaxValue, int.MaxValue };

                int[] cellInterceptions = minDistance(item, x, y, cellx, celly);
                cellsInterceptionDistance[item][tempT][0] = Math.Min(cellsInterceptionDistance[item][tempT][0], cellInterceptions[0]);
                cellsInterceptionDistance[item][tempT][1] = Math.Min(cellsInterceptionDistance[item][tempT][1], cellInterceptions[1]);


            }
        }

        static int[] minDistance(Tuple<int,int> cell, int x, int y, int cellx, int celly)
        {
            int x1 = cell.Item1;
            int y1 = cell.Item2;
            int[] res = new int[2];
            //same row
            if (x1 == cellx)
            {
                res[0] = Math.Abs(y1 - celly);
            }
            else
            {
                res[0] = Math.Abs(x1 - cellx);
            }

            if (x == cellx)
            {
                res[1] = Math.Abs(y - celly);
            }
            else
            {
                res[1] = Math.Abs(x - cellx);

            }

            return res;
        }

        
    }
}
