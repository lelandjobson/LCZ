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
            var test1 = new int[] { 2, 1, 5, 6, 2, 3 };
            Assert.AreEqual(10, LargestRectangleArea(test1));
        }
        public int LargestRectangleArea(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            int length = heights.Length;
            int maxArea = 0;

            // In this one, we only recalculate
            // when we get to the bottom of the stack,
            // or when we have a block that is smaller
            // than the next block.
            for (int i = 0; i < length; i++)
            {
                while ((stack.Peek() != -1)
                        && (heights[stack.Peek()] >= heights[i]))
                {
                    int currentHeight = heights[stack.Pop()];
                    int currentWidth = i - stack.Peek() - 1;
                    maxArea = Math.Max(maxArea, currentHeight * currentWidth);
                }
                stack.Push(i);
            }
            // In this one... i dont know lol
            while (stack.Peek() != -1)
            {
                int currentHeight = heights[stack.Pop()];
                int currentWidth = length - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, currentHeight * currentWidth);
            }
            return maxArea;
        }
    }
}
