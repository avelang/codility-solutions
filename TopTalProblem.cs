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
                    Max_Num = Math.Max(Board[i][j], Max_Num);
                    max_i = i; max_j = j;
                }
            }

            int out_row, out_col;
            while (count > 0)
            {
                Max_Num = Max_Num * 10 + LargestNeighbor(out out_row, out out_col, max_i, max_j, Board, rowLength, colLength);
                max_i = out_row; 
                max_j = out_col;

                count--;
            }

            return Max_Num;
        }

        // TO-DO : Add logic to check if the index is "visited" - i.e. path exists and not visited.
        public int LargestNeighbor(out int out_row, out int out_column, int row, int column, int[][] TestBoard, int colLength, int rowLength) {
            int maxNum = -1;
            out_row = -1;
            out_column = -1;
            Hashtable visited = new Hashtable();
            visited.Add(String.Format("{0}_{1}", row, column), true);
            if (column < colLength - 1) // if right path exists, move right
                if (TestBoard[row][column+1] > maxNum)
                {
                    maxNum = TestBoard[row][column+1];
                    visited.Add(String.Format("{0}_{1}", row, column+1), true);
                    out_row = row;
                    out_column = column+1;
                }
            if (row < rowLength - 1) // if bottom path exists, move down
                if (TestBoard[row+1][column] > maxNum)
                {
                    maxNum = TestBoard[row+1][column];
                    visited.Add(String.Format("{0}_{1}", row+1, column), true);
                    out_row = row+1;
                    out_column = column;
                }
            if (column > 0) // if left path exists, move left
                if (TestBoard[row][column - 1] > maxNum)
                {
                    maxNum = TestBoard[row][column-1];
                    visited.Add(String.Format("{0}_{1}", row, column-1), true);
                    out_row = row;
                    out_column = column-1;
                }
            if (row > 0) // if top path exists, move up
                if (TestBoard[row-1][column] > maxNum)
                {
                    maxNum = TestBoard[row-1][column];
                    visited.Add(String.Format("{0}_{1}", row-1, column), true);
                    out_row = row -1;
                    out_column = column;
                }
            return maxNum;
        }

    }
}

