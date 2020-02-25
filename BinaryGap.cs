using System;
using System.Collections.Generic;
using System.Text;

/*
    BinaryGap-Find longest sequence of zeros in binary representation of an integer.
 */

namespace codility_solutions
{
    public class BinaryGap
    {
        public int solution(int num)
        {
            int prevRem = -1;
            int currentRem = -1;
            int longestSequence = 0;
            int gapCount = 0;
            bool counterOn = false;

            while (num > 0)
            {
                currentRem = num % 2;

                if (prevRem == 1 && currentRem == 0) // count start 
                    counterOn = true;
                else if (prevRem == 0 && currentRem == 1)  // count end
                {
                    counterOn = false;
                    if (gapCount > longestSequence)
                        longestSequence = gapCount; // set longest sequence count
                    gapCount = 0; // reset gap count
                }

                if (currentRem == 0 && counterOn)
                    gapCount++;

                // in the end
                num = num / 2;
                prevRem = currentRem;
            }

            return longestSequence;
        }
    }
}
