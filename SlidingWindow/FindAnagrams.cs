using System.Collections.Generic;
using System.Linq;

namespace SlidingWindow
{
    public class FindAllAnagrams
    {
        /// <summary>
        /// https://leetcode.com/problems/find-all-anagrams-in-a-string
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<int> FindAnagrams(string s, string p)
        {
            /*
            window size == p.Length
            check if all elements match
            if yes, add to dictionary
            if not move window forward

            */
            IList<int> res = new List<int>();
            int[] pCount = new int[26];
            for (int i = 0; i < p.Length; i++)
            {
                pCount[p[i] - 'a']++;
            }

            int[] sCount = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                sCount[s[i] - 'a']++;

                if (i >= p.Length)
                {
                    sCount[s[i - p.Length] - 'a']--;
                }

                if (pCount.SequenceEqual(sCount))
                {
                    res.Add(i - p.Length + 1);
                }
            }
            return res;
        }
    }
}
