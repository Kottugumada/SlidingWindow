// AverageOfContiguousSubarray
namespace SlidingWindow
{
    // Time Complexity O(N)
    public class AverageOfContiguousSubarray
    {
        public float[] AverageOfSubarrayOfSizeK(int K, int[] arr)
        {
            float[] result = new float[arr.Length - K + 1];
            float windowSum = 0;
            int windowStart = 0;
            for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
            {
                windowSum = windowSum + arr[windowEnd]; // add the next element
                // if the required window size is hit, don't slide
                // start calculating avg
                if (windowEnd >= K - 1)
                {
                    result[windowStart] = windowSum / K;
                    windowSum = windowSum - arr[windowStart]; // subtract the previous element
                    windowStart++; // slide ahead
                }
            }
            return result;
        }
    }
}