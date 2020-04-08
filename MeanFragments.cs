using System;
using System.Collections.Generic;
using System.Text;

namespace codility_solutions
{
    public class MeanFragments
    {
        public int solution(int[] A, int S)
        {
            int meanFragmentCount = 0;
            for (int c = 1; c <= A.Length; c++)
            {
                for (int i = 0; i < A.Length - (c - 1); i++)
                {
                    if (mean(A, i, c) == (double) S)
                    {
                        meanFragmentCount++;
                    }
                }
            }
            return meanFragmentCount;
        }
        public double mean(int[] A, int startIndex, int length)
        {
            int sum = 0;
            for (int i = startIndex; i < startIndex + length; i++)
            {
                sum += A[i];
            }
            return (double) sum / length;
        }
    }
}
