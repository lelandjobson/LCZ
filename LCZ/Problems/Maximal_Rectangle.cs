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
            var testMatrixMax = MaxRectangleArea(testMatrix.Select(m => m.ToArray()).ToArray());
        }

        public int MaxRectangleArea(int[][] matrix)
        {
            if(matrix == null || matrix.Length == 0) { return 0; }

            int n = matrix[0].Length;
            int[] height = new int[n + 1];
            int answer = 0;

            for(int x = 0; x<matrix.Length; x++)
            {
                for(int y = 0; y< n; y++)
                {
                    if(matrix[x][y] == 1)
                    {
                        height[y] += 1; 
                    }
                    else
                    {
                        height[y] += 0;
                    }
                }

                Stack<int> stack = new Stack<int>();
                for(int y = 0; y<n +1; y++)
                {
                    while(height[y] < height[stack.Peek()])
                    {
                        var h = stack.Pop();
                        var w = y - 1 - stack.Peek();
                        answer = Math.Max(answer, h * w);
                    }
                    stack.Push(y);
                }
            }
            return answer;
        }
    }
}
