using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms
{
    public class Graphs
    {
        public System.Collections.Generic.LinkedList<int>[] adj;

        private int _v;

        public void AddEdge(System.Collections.Generic.LinkedList<int>[] adj, int v, int e)
        {
            adj[v].AddLast(e);
            adj[e].AddLast(v);
        }

        public void CreateGraph()
        {
            const int V = 5;
            System.Collections.Generic.LinkedList<int>[] adj = new System.Collections.Generic.LinkedList<int>[V];
            for (int i = 0; i < adj.Length; i++)
            {
                adj[i] = new System.Collections.Generic.LinkedList<int>();
            }
            AddEdge(adj, 0, 1);
            AddEdge(adj, 0, 4);
            AddEdge(adj, 1, 4);
            AddEdge(adj, 1, 3);
            AddEdge(adj, 1, 2);
            AddEdge(adj, 2, 3);
            AddEdge(adj, 3, 4);
        }

        public void CreateGraph(int v)
        {
            adj = new System.Collections.Generic.LinkedList<int>[v];
            for (int i = 0; i < adj.Length; i++)
            {
                adj[i] = new System.Collections.Generic.LinkedList<int>();
            }
            _v = v;
        }

        public void BreadthFirtstSearch(int start)
        {
            bool[] visited = new bool[_v];
            for (int i = 0; i < _v; i++)
            {
                visited[i] = false;
            }
            System.Collections.Generic.LinkedList<int> queue = new System.Collections.Generic.LinkedList<int>();
            visited[start] = true;
            queue.AddLast(start);
            while (queue.Count != 0)
            {
                start = queue.First();
                Console.WriteLine(start + " ");
                queue.RemoveFirst();
                System.Collections.Generic.LinkedList<int> _list = adj[start];
                foreach (int x in _list)
                {
                    if (!visited[x])
                    {
                        visited[x] = true;
                        queue.AddLast(x);
                    }
                }
            }
        }

        public void DeapthFirstSearch(int v, bool[] visited)
        {
            visited[v] = true;
            Console.WriteLine(v + "");
            System.Collections.Generic.LinkedList<int> list = adj[v];
            foreach (var x in list)
            {
                if (!visited[x])
                {
                    DeapthFirstSearch(x, visited);
                }
            }
        }

        public void DFS(int v)
        {
            bool[] visited = new bool[_v];
            DeapthFirstSearch(v, visited);
        }
    }

    public class Graph2
    {
        public List<int>[] _adj;

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            _adj = new List<int>[numCourses];

            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new List<int>();
            }

            bool[] visited = new bool[numCourses];
            bool[] tempvisited = new bool[numCourses];

            for (int i = 0; i < prerequisites.Length; i++)
            {
                _adj[prerequisites[i][1]].Add(prerequisites[i][0]);
            }

            for (int i = 0; i < numCourses; i++)
            {
                if (!DFS(i, visited, tempvisited, _adj))
                {
                    return false;
                }
            }
            return true;
        }

        public bool DFS(int s, bool[] visited, bool[] tempvisited, List<int>[] g)
        {
            if (tempvisited[s])
                return false;
            if (visited[s])
                return true;
            tempvisited[s] = true;
            foreach (var x in g[s])
            {
                if (!DFS(x, visited, tempvisited, g))
                {
                    return false;
                }
            }
            tempvisited[s] = false;
            visited[s] = true;
            return true;
        }
    }
}
