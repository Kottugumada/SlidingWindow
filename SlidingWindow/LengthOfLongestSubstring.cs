using System;
using System.Collections.Generic;

namespace SlidingWindow
{
    class LongestSubstring
    {
        /// <summary>
        /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            // O(n)
            int start = 0;
            int end = 0;
            int maxLen = 0;
            char[] c = s.ToCharArray();
            HashSet<char> hs = new HashSet<char>();
            // extend the range [windowStart, windowEnd]
            while (end < c.Length && start < c.Length)
            {
                if (!hs.Contains(c[end]))
                {
                    hs.Add(c[end++]); // wk
                    maxLen = Math.Max(maxLen, end - start);
                }
                else
                {
                    hs.Remove(c[start++]); // w
                }
            }
            return maxLen;
        }
    }
}
