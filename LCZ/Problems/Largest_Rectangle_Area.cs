using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Largest_Rectangle_Area : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            //var test1 = new int[] { 2, 1, 5, 6, 2, 3 };
            var test1 = new int[] { 2, 4 };
            Assert.AreEqual(10, LargestRectangleArea(test1));
        }

        public int LargestRectangleArea(int[] heights)
        {
            if(heights == null) { return 0; }
            if(heights.Length == 1) { return heights[0]; }

            Stack<int> indices = new Stack<int>();

            int result = 0;

            for(int i =0; i<heights.Length + 1; i++)
            {
                int curHeight = i == heights.Length ? 0 : heights[i];
                while (PreviousBarOnStackIsGreaterThan(indices, heights, curHeight))
                {
                    var pop = indices.Pop();
                    var leftMost = indices.Count == 0 ? 0 : indices.Peek() + 1;
                    var rightMost = i;
                    result = Math.Max(result, (rightMost - leftMost) * heights[pop]);
                }
                indices.Push(i);
            }

            return result;
        }

        bool PreviousBarOnStackIsGreaterThan(Stack<int> stack, int[] heights, int next)
        {
            return stack.Count > 0 && heights[stack.Peek()] > next;
        }


     
    }
}
