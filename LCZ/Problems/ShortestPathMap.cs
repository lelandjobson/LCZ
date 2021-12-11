using LeetCode.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class ShortestPathMap : IProblemAndSolution
    {
        public Complexity SpaceComplexity => throw new NotImplementedException();

        public Complexity TimeComplexity => throw new NotImplementedException();

        public dynamic TestData => throw new NotImplementedException();

        public List<Type> StructuresUsed => throw new NotImplementedException();

        private UndirectedGraphNode<string> GenerateLocationMap()
        {
            var A = new UndirectedGraphNode<string>("A", ("C", 2), ("F", 5));
            var B = new UndirectedGraphNode<string>("B", ("F", 1), ("J", 6));
            var C = new UndirectedGraphNode<string>("C", ("A", 2), ("E", 1));
            var D = new UndirectedGraphNode<string>("D", ("E", 3), ("F", 1));
            var E = new UndirectedGraphNode<string>("E", ("D", 3), ("C", 1));
            var F = new UndirectedGraphNode<string>("F", ("D", 1), ("B", 1), ("H",4));
            var G = new UndirectedGraphNode<string>("G", ("D", 2), ("H", 4));
            var H = new UndirectedGraphNode<string>("H", ("G", 4), ("F", 4), ("I",2), ("M", 5), ("L",2));
            var I = new UndirectedGraphNode<string>("I", ("H", 2), ("K", 1));
            var J = new UndirectedGraphNode<string>("J", ("B", 6), ("K", 2));
            var K = new UndirectedGraphNode<string>("K", ("J", 2), ("I", 1));
            var L = new UndirectedGraphNode<string>("L", ("H", 2));
            var M = new UndirectedGraphNode<string>("M", ("H", 5), ("N",3));
            var N = new UndirectedGraphNode<string>("N", ("M", 3), ("O",9));
            var O = new UndirectedGraphNode<string>("O", ("K", 2), ("N",9));
            var P = new UndirectedGraphNode<string>("P", ("N", 2));

            var graph = UndirectedGraphNode<string>.BuildGraph(A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P);
            return graph;

        }

        public void Execute()
        {
            var map = GenerateLocationMap();
            // Get from A to P distance

            var nodeHeap = new BinaryHeap<UndirectedGraphNode<string>>(16);

            double value = GetDistance(map, "P", ref nodeHeap);
        }

        double GetDistance(UndirectedGraphNode<string> node, string endpoint, ref BinaryHeap<UndirectedGraphNode<string>> nodeNetwork)
        {
            // Assuming the head node is the start point.

        }


    }

    public class Location
    {
        public string Name;

        public Location(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Node @ {Name}";
        }
    }

    public class UndirectedGraphNode<T>
    {
        //public readonly Func<T, double> GetNodeValue;
        public readonly List<(UndirectedGraphNode<T>, double)> Children = new List<(UndirectedGraphNode<T>, double)>();
        public readonly T Value;

        public UndirectedGraphNode(T value, params (T,double)[] children)
        {
            Value = value;

            //this.GetNodeValue = getNodeValue;
            if(children != null)
            {
                foreach(var c in children) { Children.Add((new UndirectedGraphNode<T>(c.Item1),c.Item2)); }
            }
        }

        public void Add((UndirectedGraphNode<T>, double) child)
        {
            Children.Add(child);
        }

        public static UndirectedGraphNode<T> BuildGraph(params UndirectedGraphNode<T>[] nodes)
        {
            Dictionary<T, UndirectedGraphNode<T>> nodesByValue = nodes.ToDictionary(n => n.Value, n => n);
            foreach(var n in nodes)
            {
                for(int i =0; i< n.Children.Count; i++)
                {
                    n.Children[i] = (nodesByValue[n.Children[i].Item1.Value], n.Children[i].Item2);
                }
            }
            return nodes.First();
        }
    }

}
