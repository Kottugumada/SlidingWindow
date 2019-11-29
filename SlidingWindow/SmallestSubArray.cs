using System;

namespace SlidingWindow
{
    // Time Complexity O(N)
    // Space Complexity O(1)
    public class SmallestSubArray
    {
        public int MinSizeSubArray(int s, int[] arr)
        {
            int minLength = Int32.MaxValue;
            int windowSum = 0;
            int windowStart = 0;
            for(int windowEnd = 0;windowEnd< arr.Length; windowEnd++)
            {
                windowSum = windowSum + arr[windowEnd];
                while(windowSum >= s)
                {
                    minLength = Math.Min(minLength,windowEnd-windowStart+1);
                    windowSum = windowSum - arr[windowStart];
                    windowStart++;
                }
            }
            return minLength == Int32.MaxValue ? 0 : minLength;
        }
    }
}
