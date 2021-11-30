using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Partition_Equal_Subset_Sum : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            var testcase = new int[] { 1, 5, 11, 5, 6, 3, 3, 7, 8, 1 };
            Assert.IsTrue(CanPartition(testcase));
        }

        public bool CanPartition(int[] nums)
        {
            if (nums == null || nums.Length == 0) { return false; }
            int totalSum = nums.Sum();
            if (totalSum % 2 != 0) { return false; }

            int subSetSum = totalSum / 2;
            int n = nums.Length;

            bool?[,] memo = new bool?[n + 1,subSetSum + 1];

            bool isPossible = Dfs(nums, n - 1, subSetSum, memo);
            return isPossible;
        }

        public bool Dfs(int[] nums, int n, int subSetSum, bool?[,] memo)
        {
            if (subSetSum == 0) { return true; }
            if (n == 0 || subSetSum < 0) { return false; }

            if (memo[n, subSetSum] != null)
            {
                return memo[n, subSetSum].Value;
            }

            bool result =
                Dfs(nums, n - 1, subSetSum - nums[n - 1], memo) ||
                Dfs(nums, n - 1, subSetSum, memo);
            memo[n, subSetSum] = result;

            return result; 
        }
    }
}
