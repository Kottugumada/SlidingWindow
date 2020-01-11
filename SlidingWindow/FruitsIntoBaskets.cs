using System;
using System.Collections.Generic;

namespace SlidingWindow
{
    public class FruitsIntoBaskets
    {
        public int TotalFruit(int[] tree)
        {
            int windowStart = 0;
            int maxLength = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();

            // extend the range [windowStart, windowEnd]
            for (int windowEnd = 0; windowEnd < tree.Length; windowEnd++)
            {
                int right = tree[windowEnd];
                dict[right] = dict.GetValueOrDefault(right, 0) + 1;

                // shrink window till we have only k distinct characters in the dictionary
                while (dict.Count > 2)
                {
                    int left = tree[windowStart];
                    dict[left] = dict[left] - 1;
                    if (dict[left] == 0)
                    {
                        dict.Remove(left);
                    }
                    windowStart++; // move the window to the right
                }
                maxLength = Math.Max(maxLength, windowEnd - windowStart + 1);
            }
            return maxLength;
        }
    }
}
