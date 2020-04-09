using System;
using System.Collections.Generic;
using System.Text;

namespace codility_solutions
{
    public class TraveAgency
    {
        // problem : smallest substring that contains all the distinct elements in a string

        public List<string> solution(string s)
        {
            // find & collect all the distinct elements in s 
            Dictionary<char, int> elements = new Dictionary<char, int>(); // for better performance than hashtable. Look-up HashSet
            for (int i = 0; i < s.Length; i++)
            {
                if (!elements.ContainsKey(s[i]))
                {
                    elements.Add(s[i],1);
                }
            }
            int elementCount = elements.Count;
            List<string> strings = new List<string>() { };
            int minLength = s.Length + 1;

            // consider all substrings >= length/count of distinct elements in s
            for (int i = elementCount; i <= s.Length; i++)
            {
                for (int j = 0; j + i <= s.Length; j++)
                {
                    if (CheckForElements(s.Substring(j, i),elements))
                    {
                        if(i<=minLength)
                        {
                            minLength = i;
                            strings.Add(s.Substring(j, i));
                        }
                    };
                }
            }
            return strings;
        }
        
        // check if all distinct elements are present in the string
        public bool CheckForElements(string s, Dictionary<char, int> elements)
        {
            foreach (var item in elements)
            {
                if (!s.Contains(item.Key.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
