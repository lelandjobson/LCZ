using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class IntervalIntersection : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            var test1 = Intersect(
                new int[][] { new[] { 0, 2 }, new[] { 5, 10 }, new[] { 13, 23 }, new[] { 24, 25 } },
                new int[][] { new[] { 1, 5 }, new[] { 8, 12 }, new[] { 15, 24 }, new[] { 25, 26 } });
            Console.WriteLine(test1);


            var test2 = Intersect(
                new int[][] { new[] { 5, 7 },},
                new int[][] { new[] { 7, 12 },});
        }


        /// <summary>
        /// This is a bit lengthy.
        /// The two pointer approach is better
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public int[][] Intersect(int[][] first, int[][] second)
        {
            // Create a sorted list of domain starts / ends between the two.
            var fl = first.Select(f => new IntervalEdge(f[0], Dir1D.Left, 0));
            var fr = first.Select(f => new IntervalEdge(f[1], Dir1D.Right, 0));
            var sl = second.Select(f => new IntervalEdge(f[0], Dir1D.Left, 1));
            var sr = second.Select(f => new IntervalEdge(f[1], Dir1D.Right, 1));

            var all = fl.Concat(fr).Concat(sl).Concat(sr).ToList();

            foreach(var both in all.GroupBy(e => e.Num).Where(g => g.Count() > 1 && g.First().Dir != g.Last().Dir))
            {
                foreach(var member in both)
                {
                    all.Remove(member);
                }
                all.Add(new IntervalEdge(both.Key, Dir1D.Both, 2));
            }

            all.Sort((a, b) => a.Num.CompareTo(b.Num));

            // Walk through all finding overlaps.
            List<int[]> output = new List<int[]>();
            for(var i = 1; i < all.Count; i++)
            {
                var cur = all[i];
                IntervalEdge prev = all[i - 1];
                IntervalEdge prevprev = i > 1 ? all[i - 2] : null;

                // Get the direction.
                // We can consider any case of < > as an intersection.
                if (cur.Num != prev.Num && cur.IsRightOrBoth())
                {
                    if (prev.Dir == Dir1D.Left && (prevprev?.IsLeftOrBoth() ?? false))
                    {
                        // Add an output
                        output.Add(new int[2] { prev.Num, cur.Num });
                    }
                }
                // Handle single edges ([25,25]
                if(cur.Dir == Dir1D.Both)
                {
                    output.Add(new int[2] { cur.Num, cur.Num });
                }
            }
            return output.ToArray();
        }
    }

    internal class IntervalEdge
    {
        public readonly int Num;
        public readonly Dir1D Dir;
        public readonly int Parent;

        public IntervalEdge(int num, Dir1D dir, int parent)
        {
            Num = num;
            Dir = dir;
            Parent = parent;
        }

        public bool IsLeftOrBoth() => Dir == Dir1D.Both || Dir == Dir1D.Left;
        public bool IsRightOrBoth() => Dir == Dir1D.Both || Dir == Dir1D.Right;
    }

    internal enum Dir1D
    {
        None = -1,
        Left,
        Right,
        Both,
    }
}
