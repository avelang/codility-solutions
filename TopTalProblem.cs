using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

namespace codility_solutions
{
    public class Solution
    {
        public int solution(int[][] Board)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int[] numArray = new int[] { };
            int count = 0;
            int rowLength = Board.Length; // rows
            int colLength = Board[0].Length; // columns

            for (int i = 0, j = 0; i < rowLength && j < colLength; i++, j++)
            {
                // Create number and add to array
                int num = CreateNumber(0, i, j, 1, Board, colLength, rowLength);
                numArray[count] = num;
                count++;
            }

            Array.Sort(numArray);
            return numArray[numArray.Length - 1];
        }

        public int CreateNumber(int number, int row, int column, int digit, int[][] TestBoard, int colLength, int rowLength)
        {

            int numToSend = 10 * number + TestBoard[row][column];
            if (digit == 4) // the current cell is the last digit, add the number to array
            {
                return numToSend;

            }
            else if (column < colLength - 1)// if right path exists, move right
            {
                return CreateNumber(numToSend, row, column++, digit++, TestBoard, colLength, rowLength);
            }
            else if (column > 0)// if left path exists, move left
            {
                return CreateNumber(numToSend, row, column--, digit++, TestBoard, colLength, rowLength);
            }
            else if (row < rowLength - 1)// if bottom path exists, move down
            {
                return CreateNumber(numToSend, row++, column, digit++, TestBoard, colLength, rowLength);
            }
            else if (row > 0)// if top path exists, move up
            {
                return CreateNumber(numToSend, row--, column, digit++, TestBoard, colLength, rowLength);
            }
            else
            {
                return numToSend;
            }
        }
    }
}

