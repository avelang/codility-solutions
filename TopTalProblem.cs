using System;
using System.Collections;
/*
 Problem : In a 2-D array of integers, identity the biggest number possible by traversing a path of 
 4 neighbouring cells. Two cells sharing a common edge are neighbours.
 eg : [1,2],[3,4] -> should output 4312
      [4,3],[1,2] -> should output 4321

    // Implement this solution - Find the largest number first, subsequently keep finding the largest neighbours till you have 4 numbers
    // 1. Find largest number in the 2-D array -> 
            Either (1) Scan all numbers, or 
                   (2) Use a Peak finding algorithm (refer MIT course ware).
    // 2. For 3 times subsequently, find the largest neighbour.
            // Get all neighbours, clockwise, max 8 neighbours
            // use a clockwise scan algorithm
 */

namespace codility_solutions
{
    public class Solution
    {
        public int solution(int[][] Board)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int count =3;
            int rowLength = Board.Length; // rows
            int colLength = Board[0].Length; // columns
            int Max_Num = 0;
            int max_i = -1, max_j = -1;


            // The logic here is to go through each index & find the max number
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if(Board[i][j] > Max_Num)
                    {
                        Max_Num = Board[i][j];
                        max_i = i;
                        max_j = j;
                    }
                }
            }

            int out_row, out_col;
            Hashtable visited = new Hashtable();
            visited.Add(String.Format("{0}_{1}", max_i, max_j), true);
            Hashtable out_visited = new Hashtable();
            while (count > 0)
            {
                Max_Num = Max_Num * 10 + LargestNeighbor(out out_row, out out_col, out out_visited, max_i, max_j, Board, rowLength, colLength, visited);
                max_i = out_row; 
                max_j = out_col;
                visited = out_visited;

                count--;
            }

            return Max_Num;
        }

        public int LargestNeighbor(out int out_row, out int out_column, out Hashtable out_visited,
                    int row, int column, int[][] TestBoard, int colLength, int rowLength, Hashtable visited) {
            int maxNum = -1;
            out_row = -1;
            out_column = -1;

            // if right path exists & not visited, move right
            if ((column < colLength - 1) && (!visited.Contains(String.Format("{0}_{1}", row, column+1)))) 
                if (TestBoard[row][column+1] > maxNum)
                {
                    maxNum = TestBoard[row][column+1];
                    visited.Add(String.Format("{0}_{1}", row, column+1), true);
                    out_row = row;
                    out_column = column+1;
                }
            // if bottom path exists & not visited, move down
            if ((row < rowLength - 1) && (!visited.Contains(String.Format("{0}_{1}", row+1, column)))) 
                if (TestBoard[row+1][column] > maxNum)
                {
                    maxNum = TestBoard[row+1][column];
                    visited.Add(String.Format("{0}_{1}", row+1, column), true);
                    out_row = row+1;
                    out_column = column;
                }
            // if left path exists & not visited, move left
            if ((column > 0) && (!visited.Contains(String.Format("{0}_{1}", row, column-1))))
                if (TestBoard[row][column - 1] > maxNum)
                {
                    maxNum = TestBoard[row][column-1];
                    visited.Add(String.Format("{0}_{1}", row, column-1), true);
                    out_row = row;
                    out_column = column-1;
                }
            // if top path exists & not visited, move up
            if ((row > 0) && (!visited.Contains(String.Format("{0}_{1}", row-1, column))))
                if (TestBoard[row-1][column] > maxNum)
                {
                    maxNum = TestBoard[row-1][column];
                    visited.Add(String.Format("{0}_{1}", row-1, column), true);
                    out_row = row -1;
                    out_column = column;
                }
            out_visited = visited;
            return maxNum;
        }

        public int[] rotLeft(int[] a, int d)
        {
            // declare new array
            int[] b = new int[a.Length];
            // for indexes o to len-1     
            for (int i = 0; i < b.Length; i++)
            {
                if (b.Length - i - 1 < d)
                    b[i] = a[i-(b.Length-d)];
                else
                    b[i] = a[i + d];
            }
            return b;
        }

        // 1,2,5,3,7,8,6,4
        // 1,2,3,4,5,6,7,8
        // 0,0,-2,1,-2,-2,1,4
        public void minimumBribes(int[] q)
        {
            int bribes = 0;
            bool isChaos = false;
            for (int i = 0; i < q.Length-1; i++)
            {
                if(q[i]>(i+1)) // this means the number got shifted from its index
                {
                    if ((q[i] - q[i + 1]) > 2)
                    {
                        isChaos = true;
                        break;
                    }
                    else
                    {
                        bribes += (q[i] - (i + 1));
                    } 
                }
            }
            if(isChaos)
            {
                Console.WriteLine("Too chaotic");
            }
            else
            {
                Console.WriteLine(bribes);
            }
        }
    }
}

