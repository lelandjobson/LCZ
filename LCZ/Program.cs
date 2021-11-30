using LeetCode.Problems;
using LeetCode.Structures;
using NUnit.Framework;
using System;

namespace LeetCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my leetcoding zone!");

            //var test = new Largest_Component_Size_Common_Factor();
            //var test = new IsPerfectSquare();
            //var test = new Largest_Palindrome();
            //var test = new LongestIncreasingSubsequence();
            //var test = new IntervalIntersection();
            //var test = new Josephus();
            //var test = new ZigZagConversion();
            //var test = new Partition_Equal_Subset_Sum();
            //var test = new Cherry_Pickup_II();
            //var test = new Playground();
            //var test = new Graph_Cycle_Detection();
            //var test = new Largest_Rectangle_Area();

            var test = new Maximal_Rectangle();


            test.Execute();
            Console.ReadKey();
        }
    }
}
