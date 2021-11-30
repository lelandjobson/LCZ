using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Playground : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            //var test1 = TrimMean(new int[] { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3 });
            //var test2 = TrimMean(new int[] { 6, 2, 7, 5, 1, 2, 0, 3, 10, 2, 5, 0, 5, 5, 0, 8, 7, 6, 8, 0 });
            //var test3 = TrimMean(new int[] { 9, 7, 8, 7, 7, 8, 4, 4, 6, 8, 8, 7, 6, 8, 8, 9, 2, 6, 0, 0, 1, 10, 8, 6, 3, 3, 5, 1, 10, 9, 0, 7, 10, 0, 10, 4, 1, 10, 6, 9, 3, 6, 0, 0, 2, 7, 0, 6, 7, 2, 9, 7, 7, 3, 0, 1, 6, 1, 10, 3 });

            //Assert.AreEqual(2.0, test1);
            //Assert.AreEqual(4.0, test2);
            //Assert.AreEqual(5.27778, test3);
            var test1 = MinimumDistance("HAPPY");
        }

        public Dictionary<char, int[]> board = new Dictionary<char, int[]>(){
                { 'A', new int[]{ 0,0,} },
                { 'B', new int[]{ 0,1} },
                { 'C', new int[]{ 0,2} },
                { 'D', new int[]{ 0,3} },
                { 'E', new int[]{ 0,4} },
                { 'F', new int[]{ 0,5} },

                { 'G', new int[]{ 1,0,} },
                { 'H', new int[]{ 1,1} },
                { 'I', new int[]{ 1,2} },
                { 'J', new int[]{ 1,3} },
                { 'K', new int[]{ 1,4} },
                { 'L', new int[]{ 1,5} },

                { 'M', new int[]{ 2,0,} },
                { 'N', new int[]{ 2,1,} },
                { 'O', new int[]{ 2,2,} },
                { 'P', new int[]{ 2,3,} },
                { 'Q', new int[]{ 2,4,} },
                { 'R', new int[]{ 2,5,} },

                { 'S', new int[]{ 3,0,} },
                { 'T', new int[]{ 3,1,} },
                { 'U', new int[]{ 3,2,} },
                { 'V', new int[]{ 3,3,} },
                { 'W', new int[]{ 3,4,} },
                { 'X', new int[]{ 3,5,} },

                { 'Y', new int[]{ 4,0,} },
                { 'Z', new int[]{ 4,1,} }
        };

        public int MinimumDistance(string word)
        {
            // Compute distances for each combo.
            int[,] computeMatrix = new int[word.Length, word.Length];
            for (int i = 0; i < word.Length; i++)
            {
                char ichar = word[i];
                for (int j = i; j < word.Length; j++)
                {
                    computeMatrix[i, j] = ComputeDistance(board[ichar], board[word[j]]);
                }
            }

            int[] rowSums = new int[word.Length + 1];
            int[] colSums = new int[word.Length + 1];

            rowSums[0] = 0;
            colSums[word.Length] = 0;

            // Compute row & column sums
            for (int i = 0; i < word.Length; i++)
            {
                int colSum = 0;
                int rowSum = 0;
                for (int j = 0; j < word.Length; j++)
                {
                    colSum += computeMatrix[i, j];
                    rowSum += computeMatrix[j, i];
                }

                colSums[i] = colSum;
                rowSums[i + 1] = rowSum;
            }

            int possible = int.MaxValue;
            for (int i = 0; i < word.Length + 1; i++)
            {
                int sum = rowSums[i] + colSums[i];
                possible = Math.Min(sum, possible);
            }

            return possible;
        }

        public int ComputeDistance(int[] a, int[] b)
        {
            return Math.Abs(a[0] - b[0]) + Math.Abs(a[1] - b[1]);
        }


        public double TrimMean(int[] arr)
        {
            var sorted = arr.OrderBy(x => x).ToList();
            // Figure out when 5% is
            int indicesToRemove = System.Convert.ToInt32(Math.Ceiling(arr.Length * 0.05));
            for(int i =0; i<indicesToRemove; i++)
            {
                sorted.RemoveAt(i);
            }
            int end = sorted.Count - indicesToRemove;
            for (int i = sorted.Count-1; i>= end; i--)
            {
                sorted.RemoveAt(i);
            }
            return sorted.Average();
        }
    }
}
