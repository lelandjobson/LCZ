using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Maximal_Rectangle : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            var testMatrix = new List<List<int>>()
            {
                new List<int>{ 1,0,1,0,0 },
                new List<int>{ 1,0,1,1,1 },
                new List<int>{ 1,1,1,1,1 },
                new List<int>{ 1,0,0,1,0 }
            };
            var testMatrixMax = MaximalRectangle(testMatrix.Select(m => m.Select( i => i.ToString()[0]).ToArray()).ToArray());
        }

        public int MaximalRectangle(char[][] matrix)
        {

            if (matrix == null || matrix.Length == 0) { return 0; }

            int maxArea = 0;

            // Keeping this array outside of the calculation is key.
            // It grows as we interate, then becomes 0 when we hit a 0.
            int[] heights = new int[matrix[0].Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == '0') { heights[j] = 0; }
                    else { heights[j]++; }
                }
                maxArea = Math.Max(maxArea, LargestRectangleArea(heights));
            }

            return maxArea;
        }

        public int LargestRectangleArea(int[] heights)
        {
            if (heights == null) { return 0; }
            if (heights.Length == 1) { return heights[0]; }

            Stack<int> indices = new Stack<int>();

            int result = 0;

            for (int i = 0; i < heights.Length + 1; i++)
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
