using LeetCode.Structures;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{

    internal class Largest_Component_Size_Common_Factor : IProblemAndSolution
    {
        public Complexity SpaceComplexity => Complexity.Unknown;

        public Complexity TimeComplexity => Complexity.Unknown;

        public dynamic TestData => new List<object>();

        public List<Type> StructuresUsed => new List<Type>() { typeof(DisjointSetUnion) };

        public void Execute()
        {
            int test1 = LargestComponentSize(new[] { 4, 6, 15, 35 });
            Assert.AreEqual(test1, 4);

            int test2 = LargestComponentSize(new[] { 20, 50, 9, 63 });
            Assert.AreEqual(test2, 2);

            int test3 = LargestComponentSize(new[] { 2, 3, 6, 7, 4, 12, 21, 39 });
            Assert.AreEqual(test3, 8);
        }

        public int LargestComponentSize(int[] A)
        {
            int maxValue = A.Max();
            DisjointSetUnion dsu = new DisjointSetUnion(maxValue);

            // attribute each element to all the groups that lead by its factors.
            foreach(int num in A)
            {
                for (int factor = 2; factor < (int)(Math.Sqrt(num)) + 1; ++factor)
                    if (num % factor == 0)
                    {
                        dsu.Union(num, factor);
                        dsu.Union(num, num / factor);
                    }
            }

            // count the size of group one by one
            int maxGroupSize = 0;
            Dictionary<int,int> groupCount = new Dictionary<int, int>();
            foreach(int num in A)
            {
                int groupId = dsu.Find(num);
                int count = groupCount.ContainsKey(groupId) ? groupCount[groupId] : 0;
                if (groupCount.ContainsKey(groupId))
                {
                    groupCount[groupId] = count + 1;
                }
                else
                {
                    groupCount.Add(groupId, count + 1);
                }

                maxGroupSize = Math.Max(maxGroupSize, count + 1);
            }

            return maxGroupSize;
        }
    }
}
