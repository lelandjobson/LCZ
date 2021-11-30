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

        private int LargestRectangleArea(int[] heights)
        {
            if (heights.Length == 0)
            {
                return 0;
            }

            if (heights.Length == 1)
            {
                return heights[0];
            }

            int res = heights[0];
            Stack<int> indices = new Stack<int>();
            for (int i = 0; i < heights.Length; i++)
            {
                while (indices.Count > 0 && heights[indices.Peek()] >= heights[i])
                {
                    var pop = indices.Pop();
                    var leftMost = indices.Count > 0 ? indices.Peek() + 1 : 0;
                    res = Math.Max(res, heights[pop] * (i - leftMost));
                }
                indices.Push(i);
            }

            while (indices.Count > 0)
            {
                var pop = indices.Pop();
                var leftMost = indices.Count > 0 ? indices.Peek() + 1 : 0;
                res = Math.Max(res, heights[pop] * (heights.Length - leftMost));
            }
            return res;
        }

        public int MaximalRectangle(char[][] matrix)
        {
            if (matrix.Length == 0)
            {
                return 0;
            }

            int res = 0;

            int[] heights = new int[matrix[0].Length];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == '0')
                    {
                        heights[j] = 0;
                    }
                    else
                    {
                        heights[j]++;
                    }
                }
                res = Math.Max(res, LargestRectangleArea(heights));
            }

            return res;
        }
    }
}
