using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace codility_solutions
{
    public class NathaTests
    {
        // T - array with test case names. If name ends in numeric, implies a single test group
        // name ends in character imples a test case within a group
        public int solution(string[] T, string[] R)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int groupCount = 0;
            int groupPassCount = 0;
            Hashtable htGroupCount = new Hashtable(); // add from T
            Hashtable htGroupPassCount = new Hashtable(); // add from R

            // if last char is number
            for (int i = 0; i < T.Length; i++)
            {
                string currentString = T[i];

                if ((int)(currentString[currentString.Length - 1]) >= 48 && (int)(currentString[currentString.Length - 1]) <= 57)
                {
                    if (htGroupCount.ContainsKey(currentString))
                    {
                        htGroupCount[currentString] = ((int)htGroupCount[currentString]) + 1;
                    }
                    else
                    {
                        htGroupCount.Add(currentString, 1);
                    }
                }
                else
                {
                    if (htGroupCount.ContainsKey(currentString.Substring(0, currentString.Length - 1)))
                    {
                        htGroupCount[currentString.Substring(0, currentString.Length - 1)] = ((int)htGroupCount[currentString.Substring(0, currentString.Length - 1)]) + 1;
                    }
                    else
                    {
                        htGroupCount.Add(currentString.Substring(0, currentString.Length - 1), 1);
                    }
                }
            }

            for (int i = 0; i < R.Length; i++)
            {
                string resutString = R[i];
                string currentString = T[i];
                if (resutString == "OK")
                {
                    if ((int)(currentString[currentString.Length - 1]) >= 48 && (int)(currentString[currentString.Length - 1]) <= 57)
                    {
                        if (htGroupPassCount.ContainsKey(currentString))
                        {
                            htGroupPassCount[currentString] = ((int)htGroupPassCount[currentString]) + 1;
                        }
                        else
                        {
                            htGroupPassCount.Add(currentString, 1);
                        }
                    }
                    else
                    {
                        if (htGroupPassCount.ContainsKey(currentString.Substring(0, currentString.Length - 1)))
                        {
                            htGroupPassCount[currentString.Substring(0, currentString.Length - 1)] = ((int)htGroupPassCount[currentString.Substring(0, currentString.Length - 1)]) + 1;
                        }
                        else
                        {
                            htGroupPassCount.Add(currentString.Substring(0, currentString.Length - 1), 1);
                        }
                    }
                }
            }

            foreach (DictionaryEntry item in htGroupCount)
            {
                groupCount++;
                if(htGroupPassCount.ContainsKey(item.Key))
                {
                    if((int)htGroupCount[item.Key] == (int)htGroupPassCount[item.Key])
                    {
                        groupPassCount++;
                    }
                }
            }

            return (groupPassCount*100/ groupCount);
        }
    }
}
