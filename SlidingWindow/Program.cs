using System;

namespace SlidingWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fixed Window Size
            // https://www.educative.io/courses/grokking-the-coding-interview/7D5NNZWQ8Wr
            Console.WriteLine("Given an array, find the average of all contiguous subarrays of size ‘K’ in it.");
            AverageOfContiguousSubarray avg = new AverageOfContiguousSubarray();
            avg.AverageOfSubarrayOfSizeK(5, new int[] { 1, 3, 2, 6, -1, 4, 1, 8, 2 });

            // https://www.educative.io/courses/grokking-the-coding-interview/JPKr0kqLGNP
            Console.WriteLine("Given an array of positive numbers and a positive number ‘k’, find the maximum sum of any contiguous subarray of size ‘k’.");
            MaxSumOfContiguousSubArray maxSum = new MaxSumOfContiguousSubArray();
            Console.Write(maxSum.MaxSumOfSubArrayOfSizeK(3,new int[] { 2, 1, 5, 1, 3, 2 }));

			// https://leetcode.com/problems/maximum-average-subarray-i/
			Console.WriteLine("Given an array consisting of n integers, find the contiguous subarray of given length k that has the maximum average value. And you need to output the maximum average value.");
			MaxAverage maxAvg = new MaxAverage();
			maxAvg.FindMaxAverage(new int[] { 1, 12, -5, -6, 50, 3 }, 4);

            // Window size is not fixed
            // https://www.educative.io/courses/grokking-the-coding-interview/7XMlMEQPnnQ
            // https://leetcode.com/problems/minimum-size-subarray-sum/
            Console.WriteLine("Given an array of positive numbers and a positive number ‘S’, find the length of the smallest contiguous subarray whose sum is greater than or equal to ‘S’. Return 0, if no such subarray exists.");
            SmallestSubArray sm = new SmallestSubArray();
            Console.Write(sm.MinSizeSubArray(7, new int[] { 2, 1, 5, 2, 3, 2 }));

            // https://www.educative.io/courses/grokking-the-coding-interview/YQQwQMWLx80
            Console.WriteLine("Given a string, find the length of the longest substring in it with no more than K distinct characters.");
            LongestSubstringK ls = new LongestSubstringK();
            Console.Write(ls.LongestSubstringKDistinct("araaci", 2));

            // https://leetcode.com/problems/longest-substring-without-repeating-characters/
            Console.WriteLine("Given a string, find the length of the longest substring in it with no more than K distinct characters.");
            LongestSubstring sub = new LongestSubstring();
            Console.Write(sub.LengthOfLongestSubstring("abcabcbb"));

            // https://leetcode.com/problems/fruit-into-baskets/
            // Substring with K distinct, K here is 2
            Console.WriteLine("Fruits into baskets");
            FruitsIntoBaskets fruits = new FruitsIntoBaskets();
            Console.Write(fruits.TotalFruit(new int[] { 1,2,1}));

            Anagrams an = new Anagrams();
            string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            an.GroupAnagrams(strs);
		}
    }
}
