using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class IsPerfectSquare : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            bool test1 = CheckIsPerfectSquare(16);
            Assert.IsTrue(test1);

            bool test2 = CheckIsPerfectSquare(14);
            Assert.IsFalse(test2);

            bool test3 = CheckIsPerfectSquare(1);
            Assert.IsTrue(test3);
        }

        bool CheckIsPerfectSquare(int num)
        {
            if(num < 2) { return true; }

            int left = 2;
            int right = num / 2;
            int x;

            while(left <= right)
            {
                x = left + (right - left) / 2;
                int guessSquared = x * x;
                if(guessSquared == num) { return true; }
                if(guessSquared > num)
                {
                    // Overshot
                    right = x - 1;
                }
                else
                {
                    left = x + 1;
                }
            }
            return false;
        }


    }
}
