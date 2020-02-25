using System;
/*
Task description
This is a demo task.

Write a function:

class Solution { public int solution(int[] A); }

that, given an array A of N integers, returns the smallest positive integer(greater than 0) that does not occur in A.

For example, given A = [1, 3, 6, 4, 1, 2], the function should return 5.

Given A = [1, 2, 3], the function should return 4.

Given A = [−1, −3], the function should return 1.

Write an efficient algorithm for the following assumptions:

N is an integer within the range[1..100, 000];
each element of array A is an integer within the range[−1, 000, 000..1, 000, 000].
*/
namespace codility_solutions
{
    public class SmallestPositiveInteger
    {
        public int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int smallestPosInteger = 0;
            Array.Sort(A);

            if ((A[0] > 1))
            {
                return smallestPosInteger = A[0] - 1;
            }
            else if ((A[A.Length - 1] <= 0))
            {
                return smallestPosInteger = 1;
            }
            else
            {
                for (int i = 0; i < A.Length - 1; i++)
                {
                    if ((A[i + 1] - A[i] > 1))
                    {
                        if ((A[i] >= 0))
                        {
                            smallestPosInteger = A[i] + 1;
                        }
                        else
                        {
                            smallestPosInteger = 1;
                        }
                        break;
                    }
                }
                if (smallestPosInteger == 0)
                {
                    smallestPosInteger = A[A.Length - 1] + 1;
                }
                return smallestPosInteger;
            }

        }
    }
}
