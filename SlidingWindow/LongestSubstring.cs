using System;
using System.Collections.Generic;

namespace SlidingWindow
{
    public class LongestSubstringK
    {
        public int LongestSubstringKDistinctSum (string str, int k)
        {
            int windowStart = 0;
            int maxLength = 0;
            char[] c = str.ToCharArray();
            Dictionary<char,int> dict = new Dictionary<char, int>();

            // extend the range [windowStart, windowEnd]
            for (int windowEnd = 0; windowEnd < c.Length; windowEnd++)
            {
                char rightChar = c[windowEnd];
                dict[rightChar] = dict.GetValueOrDefault(rightChar, 0) + 1;
         
                // shrink window till we have only k distinct characters in the dictionary
                while(dict.Count > k)
                {
                    char leftChar = c[windowStart];
                    dict[leftChar] = dict[leftChar] - 1;
                    if(dict[leftChar] == 0)
                    {
                        dict.Remove(leftChar);
                    }
                    windowStart++; // move the window to the right
                }
                maxLength = Math.Max(maxLength,windowEnd - windowStart + 1);
            }
            return maxLength;
        }
    }
}
