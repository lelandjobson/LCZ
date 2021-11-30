using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class LongestIncreasingSubsequence : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            var test1 = new int[] { 5, 6, 7, 8, 1, 2, 3 };
            Assert.AreEqual(4, LongestIncreasing(test1));
            var test2 = new int[] { 10, 9, 2, 5, 3, 7, 1 };
            Assert.AreEqual(3, LongestIncreasing(test2));
        }

        /// <summary>
        /// This is good only for returning the length
        /// of the LIS in a given array. Sub builds up 
        /// increasing subsequences. When a ddecrease is found, the
        /// sub is binary searched for index above the lowest item
        /// in the sub. That number is replaced with the next number.
        /// Although sub might not in the end manifest as a valid
        /// subsequence, its replacement strategy prevents it
        /// from growing until a larger number is found than
        /// its end.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestIncreasing(int[] nums)
        {
            List<int> sub = new List<int>();
            sub.Add(nums.First());

            for(int i =1; i < nums.Length; i++)
            {
                int num = nums[i];
                if(num > sub.Last())
                {
                    sub.Add(num);
                }
                else
                {
                    int j = sub.BinarySearch(num);
                    // Binary search, when a match is not
                    // found, returns the bitwise compliment
                    // of the index.
                    if(j < 0) { j = ~j; }
                    sub[j] = num;
                }
            }

            return sub.Count;
        }
    }
}
