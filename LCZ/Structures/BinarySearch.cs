using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Structures
{
    internal partial class Tools
    {
        public static bool BinarySearch(int lookingFor, int[] nums, int left = -1, int right = -1)
        {
            if(left == -1) { left = 0; }
            if(right == -1) { right = nums.Length - 1; }
            if(left > right) { return false; }
            int mid = left + (right - left) / 2;
            if(lookingFor != nums[mid])
            {
                if(nums[mid] > lookingFor)
                {
                    // Move the right back
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
                return BinarySearch(lookingFor, nums, left, right);
            }
            else
            {
                return true;
            }
        }

        public static void BinarySearch_Test()
        {
            int[] testNums = { 1, 3, 6, 76, 242, 15523 };
            bool test1 = Tools.BinarySearch(3, testNums);
            Assert.IsTrue(test1);
            bool test2 = Tools.BinarySearch(5, testNums);
            Assert.IsFalse(test2);
        }
    }
}
