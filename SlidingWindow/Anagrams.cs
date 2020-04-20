using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// <summary>
        /// https://leetcode.com/problems/valid-anagram/description/
        /// Time: O(nlogn)
        /// Space: O(1) or O(n) if ToCharArray creates extra space
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram_1(string s, string t)
        {
            char[] sChar = s.ToCharArray();
            Array.Sort(sChar);
            char[] tChar = t.ToCharArray();
            Array.Sort(tChar);
            return sChar.SequenceEqual(tChar);
        }
        /// <summary>
        /// time COmplexity: O(n)
        /// space complexity: O(1)
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram_2(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            int[] counter = new int[26];
            for (int j = 0; j < s.Length; j++)
            {
                counter[s[j] - 'a']++; // if s[j] is present 2 times counter[s[j] - 'a']++ becomes 1
                counter[t[j] - 'a']--; // if t[j] is present 3 times counter[t[j] - 'a']++ becomes 2
            }
            foreach (int count in counter)
            {
                if (count !=0)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// https://leetcode.com/problems/group-anagrams/description/
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs == null || strs.Length == 0)
                return new List<IList<string>>();
            Dictionary<string, List<string>> res = new Dictionary<string, List<string>>();
            int[] counter = new int[26];
            foreach (string s in strs)
            {
                Array.Fill(counter,0);
                for (int j = 0; j < s.ToCharArray().Length; j++)
                {
                    counter[s[j] - 'a']++; // if exists then increment
                }
                StringBuilder sb = new StringBuilder("");
                for (int m = 0; m < 26; m++)
                {
                    sb.Append("#");
                    sb.Append(counter[m]);
                }
                string key = sb.ToString();
                if (!res.ContainsKey(key))
                {
                    res[key] = new List<string>();
                }
                res[key].Add(s);
            }
            return new List<IList<string>> (res.Values);
        }
    public List<int> FindAnagrams_Hashmap(string s, string p)
    {

    int ns = s.Length, np = p.Length;
    if (ns < np) return new List<int>();

    Dictionary<char, int> pMap = new Dictionary<char,int>();
    Dictionary<char, int> sMap = new Dictionary<char, int>();
        // build reference hashmap using string p
        for(int i =0;i<p.Length;i++)
        {
            if (pMap.ContainsKey(p[i]))
            {
                pMap[p[i]] = pMap.GetValueOrDefault(p[i], 0) + 1;
            }
            else
            {
                pMap.Add(p[i], 1);
            }
        }

        List<int> output = new List<int>();
        // sliding window on the string s
        for (int i = 0; i < ns; ++i)
        {
            // add one more letter 
            // on the right side of the window
            char ch = s[i];
            if (sMap.ContainsKey(ch))
            {
                sMap[ch] = pMap.GetValueOrDefault(ch, 0) + 1;
            }
            else
            {
                sMap.Add(ch, 1);
            }
                // remove one letter 
                // from the left side of the window
                if (i >= np)
            {
                ch = s[i - np];
                if (sMap[ch] == 1)
                {
                    sMap.Remove(ch);
                }
                else
                {
                    sMap.Add(ch, sMap[ch] - 1);
                }
            }
            // compare hashmap in the sliding window
            // with the reference hashmap
            if (pMap.Equals(sMap))
            {
                output.Add(i - np + 1);
            }
        }
        return output;
    }
    }
}
