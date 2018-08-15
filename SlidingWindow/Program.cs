using System;
using System.Collections.Generic;

namespace SlidingWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Anagrams an = new Anagrams();
            string[] strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            an.GroupAnagrams(strs);
        }
    }
}
