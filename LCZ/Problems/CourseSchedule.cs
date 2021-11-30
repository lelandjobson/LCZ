using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    public class CourseNode
    {
        public readonly int Val;
        public readonly List<CourseNode> Neighbors = new List<CourseNode>();

        public CourseNode(int val)
        {
            Val = val;
        }

        public CourseNode(int val, CourseNode neighbor)
        {
            Val = val;
            Neighbors.Add(neighbor);
        }
    }

    internal class CourseSchedule : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        public void Execute()
        {
            throw new NotImplementedException();
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // Produce coursenode graph
            Dictionary<int, CourseNode> nodes = new Dictionary<int, CourseNode>();

            int uniqueNodes = 0;
            foreach (var p in prerequisites)
            {
                if (!nodes.ContainsKey(p[1]))
                {
                    nodes.Add(p[1], new CourseNode(p[1]));
                    uniqueNodes++;
                }
                if (!nodes.ContainsKey(p[0]))
                {
                    nodes.Add(p[0], new CourseNode(p[0]));
                    uniqueNodes++;
                }
                nodes[p[0]].Neighbors.Add(nodes[p[1]]);
            }

            // Detect cycles.
            // If WasTested[n] = true && BeingTested[n] = false, then there is definitely no cycle there.
            // If BeingTested[n] = true during cycle detection, then there is a cycle.
            var beingTested = nodes.Keys.ToDictionary(k => k, k => false);
            var wasTested = nodes.Keys.ToDictionary(k => k, k => false);


            foreach (var k in nodes.Keys)
            {
                if (FoundCycle(nodes[k], beingTested, wasTested))
                {
                    return false;
                }
            }

            return true;
        }

        public bool FoundCycle(CourseNode n, Dictionary<int, bool> beingTested, Dictionary<int, bool> wasTested)
        {

            if (beingTested[n.Val])
            {
                return true;
            }

            if (wasTested[n.Val])
            {
                return false;
            }

            beingTested[n.Val] = true;
            wasTested[n.Val] = true;

            foreach (var neighbor in n.Neighbors)
            {
                if (FoundCycle(neighbor, beingTested, wasTested))
                {
                    return true;
                }
            }

            beingTested[n.Val] = false;

            return false;
        }
    }
}
