using System;

namespace SlidingWindow
{
    public class MaxAverage
	{
		public double FindMaxAverage(int[] nums, int k)
		{
			// set it to a high min
			double res = double.MinValue;
			if (nums.Length == 0) return res;

			int windowSum = 0;
			int windowStart = 0;
			for (int windowEnd = 0; windowEnd < nums.Length; windowEnd++)
			{
				windowSum = windowSum + nums[windowEnd];
				// stop moving the pointer when you hit the window maxima
				if (windowEnd >= k - 1)
				{
					double avg = windowSum / (double) k;
					res = Math.Max(avg, res);
					// progress the window further by removing the head and adding the tail pointer
					windowSum = windowSum - nums[windowStart];
					windowStart++;
				}
			}
			return Convert.ToDouble(res);
		}
	}
}
