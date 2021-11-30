using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Cherry_Pickup_II : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            int[][] test1Matrix = new List<List<int>>()
            {
                new List<int>{ 1,0,0,0,0,0,1 },
                new List<int>{ 2,0,0,0,0,3,0 },
                new List<int>{ 2,0,9,0,0,0,0 },
                new List<int>{ 0,3,0,5,4,0,0 },
                new List<int>{ 1,0,2,3,0,0,6 }
            }.Select(l => l.ToArray()).ToArray();

            var test1 = CherryPickup(test1Matrix);
            Assert.AreEqual(test1, 28);
        }

        public int CherryPickup(int[][] grid)
        {
            int rows = grid.Length;
            int columns = grid[0].Length;
            // Should be initialized to -1 for all.
            int[,,] memo = new int[rows,columns,columns];
            Fill(memo, -1);
            return GetBestValueAtCoordinate(0, 0, columns - 1, grid, memo);
        }

        public void Fill(int[,,] arr, int val)
        {
            for(int i = 0; i<arr.GetLength(0); i++)
            {
                for(int j = 0; j<arr.GetLength(1); j++)
                {
                    for(int k = 0; k<arr.GetLength(2); k++)
                    {
                        arr[i, j, k] = val;
                    }
                }
            }
        }

        public int GetBestValueAtCoordinate(int y, int r1x, int r2x, int[][] grid, int[,,] memo)
        {
            // There are 9 combinations (two robots with 3 possibilities each)

            // If this option is outside of the bounds, return a negative number
            if(r1x < 0 || r1x >= grid[0].Length || r2x < 0 || r2x >= grid[0].Length) { return -1; }

            // check cache
            if (memo[y,r1x,r2x] != -1)
            {
                return memo[y, r1x, r2x];
            }

            // If we've reached the bottom, return the value;
            int result = grid[y][r1x];
            if (r1x != r2x)
            {
                // If they're not overlapping, then you can add in 
                // the value of the square that r2 is on
                result += grid[y][r2x];
            }

            if(y != grid.Length - 1)
            {
                // Compute the lower values
                int best = 0;
                for(int r1xTest = r1x - 1; r1xTest <= r1x + 1; r1xTest++)
                {
                    for(int r2xTest = r2x - 1; r2xTest <= r2x +1; r2xTest++)
                    {
                        best = Math.Max(best, GetBestValueAtCoordinate(y + 1, r1xTest, r2xTest, grid, memo));
                    }
                }
                result += best;
            }

            memo[y,r1x,r2x] = result;
            return result;
        }
    }
}
