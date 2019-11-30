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

            // Window size is not fixed
            // https://www.educative.io/courses/grokking-the-coding-interview/7XMlMEQPnnQ
            Console.WriteLine("Given an array of positive numbers and a positive number ‘S’, find the length of the smallest contiguous subarray whose sum is greater than or equal to ‘S’. Return 0, if no such subarray exists.");
            SmallestSubArray sm = new SmallestSubArray();
            Console.Write(sm.MinSizeSubArray(7, new int[] { 2, 1, 5, 2, 3, 2 }));

            // https://www.educative.io/courses/grokking-the-coding-interview/YQQwQMWLx80
            Console.WriteLine("Given a string, find the length of the longest substring in it with no more than K distinct characters.");
            LongestSubstring ls = new LongestSubstring();
            Console.Write(ls.LongestSubstringKDistinct("araaci", 2));
            
            Anagrams an = new Anagrams();
            string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            an.GroupAnagrams(strs);
        }
    }
}
