using System.Collections.Generic;

namespace SlidingWindow
{
    public class Anagrams
    {
        /// <summary>
        /// https://leetcode.com/problems/find-all-anagrams-in-a-string/description/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<int> FindAnagrams_1(string s, string p)
        {
            IList<int> res = new List<int>();
            if (s.Length == 0 || p.Length == 0 || s.Length < p.Length) return new List<int>();

            // keep track of how many times each character appears
            int[] chars = new int[26];
            foreach (char c in p.ToCharArray())
            {
                chars[c - 'a']++;
            }


            // diff is length of currently found substring/anagram
            int start = 0, end = 0, len = p.Length, diff = len;
            char temp;

            // first window of length 0
            for (end = 0; end < len; end++)
            {
                temp = s[end];

                //decrement, because it has been found
                chars[temp - 'a']--;

                // still positive indicates tha the substring/anagram still uses it so we decremet the diff
                if (chars[temp - 'a'] >= 0)
                    diff--;
            }

            // if string s began with an anagram string p
            if (diff == 0) res.Add(0);

            // now we work on sliding the window, that is, removing the first character and adding the last character
            while (end < s.Length)
            {
                temp = s[start];

                // if temp is present that means that the anagram is not complete and that we are farther away from completion
                // and we would need to increment the diff
                if (chars[temp - 'a'] >= 0)
                    diff++;

                // the character is no longer in the window increment hash
                chars[temp - 'a']++;

                // increment start and shift the window by one character
                start++;

                // temp now represents the character at the end that needs to be added
                temp = s[end];

                // decrement since it is now already present in the window
                chars[temp - 'a']--;

                // if not negative, it means it is part of the anagram
                if (chars[temp - 'a'] >= 0)
                    diff--;

                // if diff is 0 it means it is last of the iterations on p.Length
                // diff was decremented (since it is part of the anagram) and not decremented since it is there
                if (diff == 0)
                    res.Add(start);

                // next iteration
                end++;
            }

            return res;
        }
        public class Solution
        {
            /// <summary>
            /// https://leetcode.com/problems/find-all-anagrams-in-a-string/description/
            /// https://www.geeksforgeeks.org/anagram-substring-search-search-permutations/
            /// We can achieve O(n) time complexity under the assumption that alphabet size is fixed which is typically true 
            /// as we have maximum 256 possible characters in ASCII. The idea is to use two count arrays:
            ///  1) The first count array store frequencies of characters in pattern.
            ///  2) The second count array stores frequencies of characters in current window of text.
            /// </summary>
            /// <param name="arr1"></param>
            /// <param name="arr2"></param>
            /// <returns></returns>
            private bool Compare(char[] arr1, char[] arr2)
            {
                for (int r = 0; r < 256; r++)
                {
                    if (arr1[r] != arr2[r])
                    {
                        return false;
                    }
                }
                return true;
            }

            public IList<int> FindAnagrams_2(string s, string p)
            {
                IList<int> res = new List<int>();
                if (s.Length == 0 || p.Length == 0 || s.Length < p.Length) return new List<int>();
                int m = p.Length; // pattern
                int n = s.Length; // string

                char[] countP = new char[256];
                char[] countTW = new char[256];

                // first window
                for (int j = 0; j < m; j++)
                {
                    countP[p[j]]++;
                    countTW[s[j]]++;
                }

                // move window
                // traverse through the remaining characters of the pattern
                for (int q = m; q < n; q++)
                {
                    // compare current window with the pattern
                    // If the two count arrays are identical, we found an occurrence
                    if (Compare(countP, countTW))
                        res.Add(q - m);

                    // add character to the current window
                    countTW[s[q]]++;

                    // remove the first character of the previous window
                    countTW[s[q - m]]--;
                }
                //The last window is not checked by above loop, so explicitly check it.
                // check for the last window of text
                if (Compare(countP, countTW))
                    res.Add(n - m);

                return res;
            }
        }
    }
}
