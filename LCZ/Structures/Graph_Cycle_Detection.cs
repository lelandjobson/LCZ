using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems
{
    internal class Graph_Cycle_Detection
    {
        // Driver code 
        public void Execute()
        {
            Graph graph = new Graph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);

            if (graph.IsCyclic())
                Console.WriteLine("Graph contains cycle");
            else
                Console.WriteLine("Graph doesn't "
                                        + "contain cycle");
        }
    }
}

public class Graph
{

    private readonly int V;
    private readonly List<List<int>> adj;

    public Graph(int V)
    {
        this.V = V;
        adj = new List<List<int>>(V);

        for (int i = 0; i < V; i++)
            adj.Add(new List<int>());
    }

    public void AddEdge(int sou, int dest)
    {
        adj[sou].Add(dest);
    }

    // Returns true if the graph contains a 
    // cycle, else false. 
    // This function is a variation of DFS() in 
    // https://www.geeksforgeeks.org/archives/18212 
    public bool IsCyclic()
    {

        // Mark all the vertices as not visited and 
        // not part of recursion stack 
        bool[] visited = new bool[V];
        bool[] recStack = new bool[V];


        // Call the recursive helper function to 
        // detect cycle in different DFS trees 
        for (int i = 0; i < V; i++)
            if (IsCyclicUtil(i, visited, recStack))
                return true;

        return false;
    }

    private bool IsCyclicUtil(int i, bool[] visited,
                                   bool[] recStack)
    {

        // Mark the current node as visited and 
        // part of recursion stack 
        if (recStack[i])
            return true;

        if (visited[i])
            return false;

        visited[i] = true;
        recStack[i] = true;

        List<int> children = adj[i];

        foreach (int c in children)
            if (IsCyclicUtil(c, visited, recStack))
                return true;

        recStack[i] = false;

        return false;
    }
}
