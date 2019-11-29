using System;

namespace SlidingWindow
{
    //  Time Complexity of O(N)
    //  Space Complexity of O(1)
    public class MaxSumOfContiguousSubArray
    {
        public int MaxSumOfSubArrayOfSizeK(int k, int[] arr)
        {
            int windowStart = 0;
            int maxSum = Int32.MinValue;
            // int[] sums = new int[arr.Length];
            int windowSum = 0;
            for (int windowEnd = 0; windowEnd < arr.Length;windowEnd++)
            {
                windowSum = windowSum + arr[windowEnd];
                if (windowEnd >= k-1)
                {
                    maxSum = Math.Max(windowSum, maxSum);
                    // sums[windowEnd] = windowSum;
                    windowSum = windowSum - arr[windowStart];
                    windowStart++;
                }
            }
            // Array.Sort(sums); //O(nlog N) best and O(n*n) worst
            // return sums[arr.Length -1];
            return maxSum;
        }
    }
}
