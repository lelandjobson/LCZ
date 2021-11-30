using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{

    public class Kth_Largest : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            var kthLargest = new KthLargest(3, new[] { 4, 5, 8, 2 });
            Assert.AreEqual(4, kthLargest.Add(3));   // return 4
            Assert.AreEqual(5, kthLargest.Add(5));   // return 5
            Assert.AreEqual(5, kthLargest.Add(10));  // return 5
            Assert.AreEqual(8, kthLargest.Add(9));   // return 8
            Assert.AreEqual(8, kthLargest.Add(4));   // return 8
        }
    }

    public class KthLargest
    {

        List<int> _nums;
        readonly int _k;

        public KthLargest(int k, int[] nums)
        {
            _k = k;
            _nums = nums.OrderBy(a => a).ToList();
        }

        public int Add(int val)
        {
            var pos = _nums.BinarySearch(val);
            if (pos < 0) { pos = ~pos; }
            _nums.Insert(pos, val);
            return _nums[_nums.Count - _k];
        }
    }

    /**
     * Your KthLargest object will be instantiated and called as such:
     * KthLargest obj = new KthLargest(k, nums);
     * int param_1 = obj.Add(val);
     */
}
