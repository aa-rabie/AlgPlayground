using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgPlayGroundApp.DataStructures
{
    /// <summary>
    /// This class Implementing directed graph using concept of adjacency-list
    /// 
    /// side-note: dense graph : it is a graph where each node is connected to all other nodes
    /// 
    /// note: if we have dense-graph ( it is better to implement graph using adjacency-matrix
    /// because it will perform better than 'graph implemented using concept of adjacency-list')
    ///
    /// to refresh your mind about Graph expressions & O(N) operations pls review video 64, 65, 66
    /// in Mosh data-structure course part II
    /// video 64 => Introduction to Graphs
    /// video 65 => Intro to implementing graph using adjacency Matrix
    /// video 66 => Intro to implementing graph using adjacency list
    /// </summary>
    public partial class Graph
    {
        public class Node
        {
            private string _label;
            public Node(string label)
            {
                if(string.IsNullOrEmpty(label))
                    throw new ArgumentNullException(label);

                _label = label;
            }

            public string Label => _label;

            public override string ToString()
            {
                return _label;
            }
        }

        private Dictionary<string,Node> _nodes = new Dictionary<string, Node>();
        private Dictionary<Node,List<Node>> _adjacencyList = new Dictionary<Node, List<Node>>();

        public void AddNode(string label)
        {
            var node = new Node(label);
            _nodes.TryAdd(label, node);
            _adjacencyList.TryAdd(node, new List<Node>());
        }

        public void AddEdge(string from, string to)
        {
            if(!_nodes.ContainsKey(from))
                throw new ArgumentException(nameof(from));

            if (!_nodes.ContainsKey(to))
                throw new ArgumentException(nameof(to));

            var fromNode = _nodes[from];
            var toNode = _nodes[to];

            // we implement directed-graph
            // so we only add toNode to fromNode's adjacency list
            var fromAdjacencyList = _adjacencyList[fromNode];
            if(!fromAdjacencyList.Contains(toNode))
                fromAdjacencyList.Add(toNode);

            // in case we implement normal-graph not directed-graph
            // then we need to also add fromNode to toNode's adjacency list 
            /*
             * var toAdjacencyList = _adjacencyList[toNode];
            if(!toAdjacencyList.Contains(fromNode))
                toAdjacencyList.Add(fromNode);
             */
        }

        public void RemoveNode(string label)
        {
            if (string.IsNullOrEmpty(label))
                return;

            _nodes.TryGetValue(label, out Node node);
            if (node == null)
                return;

            //we need to remove all edges that is linked to this node
            // we need to iterate on edge-list for all nodes
            foreach (var key in _adjacencyList.Keys)
            {
                _adjacencyList[key].Remove(node);
            }
            // remove edges-list for that node
            _adjacencyList.Remove(node);
            //remove node from Nodes
            _nodes.Remove(label);
        }

        public void RemoveEdge(string from, string to)
        {
            _nodes.TryGetValue(from, out Node fromNode);
            _nodes.TryGetValue(to, out Node toNode);

            if (fromNode == null || toNode == null)
                return;

            _adjacencyList[fromNode].Remove(toNode);
        }

        public void Print(TextWriter writer)
        {
            foreach (var entry in _nodes)
            {
                var connections = _adjacencyList[entry.Value];
                if (connections.Any())
                {
                    writer.WriteLine($"{entry.Value} is connected to [{string.Join(',',connections)}]");
                }
            }
        }

        #region TraverseDepthFirst - recursively
        // to refresh your mind check video # 70, 71 , 72 in Mosh data-structure course part II
        // video #70 => Graph Traversal Algorithms
        // video #71 => Exercise Depth-First traversal - exercise
        // video #72 => Exercise Depth-First traversal - solution
        public IList<string> TraverseDepthFirstRecursively(string label)
        {
            var values = new List<string>();

            if (!_nodes.TryGetValue(label, out Node node))
                return values;

            TraverseDepthFirstRecursively(node, values, new HashSet<Node>());
            return values;
        }

        private void TraverseDepthFirstRecursively(Node node, List<string> values, HashSet<Node> visitedNodes)
        {
            visitedNodes.Add(node);
            values.Add(node.Label);

            foreach (var neighbor in _adjacencyList[node])
            {
                // we traverse a node only if it is not visited before
                if (!visitedNodes.Contains(neighbor))
                    TraverseDepthFirstRecursively(neighbor, values, visitedNodes);
            }
        }
        #endregion

        public IList<string> TraverseDepthFirstIteratively(string label)
        {
            var values = new List<string>();

            if (!_nodes.TryGetValue(label, out Node node))
                return values;

            var visitedNodes = new HashSet<Node>();
            var stack = new System.Collections.Generic.Stack<Node>();
            stack.Push(node);
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if(visitedNodes.Contains(current))
                    continue;

                values.Add(current.Label);
                visitedNodes.Add(current);
                
                foreach (var neighbor in _adjacencyList[current])
                {
                    // we traverse a node only if it is not visited before
                    if (!visitedNodes.Contains(neighbor))
                        stack.Push(neighbor);
                }
            }

            return values;
        }

        /// <summary>
        /// // to refresh your mind check video # 75, 76 in Mosh data-structure course part II
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        public IList<string> TraverseBreadthFirst(string label)
        {
            var values = new List<string>();

            if (!_nodes.TryGetValue(label, out Node node))
                return values;

            var visitedNodes = new HashSet<Node>();
            var queue = new System.Collections.Generic.Queue<Node>();
            queue.Enqueue(node);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (visitedNodes.Contains(current))
                    continue;

                values.Add(current.Label);
                visitedNodes.Add(current);

                foreach (var neighbor in _adjacencyList[current])
                {
                    // we traverse a node only if it is not visited before
                    if (!visitedNodes.Contains(neighbor))
                        queue.Enqueue(neighbor);
                }
            }

            return values;
        }

        #region Topological Order - works only with Directed Acyclic graphs
        // to refresh your mind check video # 75, 76 in Mosh data-structure course part II

        public List<string> TopologicalOrder()
        {
            var stack = new System.Collections.Generic.Stack<Node>();
            var visitedNodes = new HashSet<Node>();
            foreach (var node in _nodes.Values)
            {
                TopologicalOrder(node, stack, visitedNodes);
            }
            // here - the nodes are sorted in reversed order in stack
            // we need to pop them one by one and add them to list
            var sorted = new List<string>();
            while (stack.Count > 0)
            {
                sorted.Add(stack.Pop().Label);
            }

            return sorted;
        }

        private void TopologicalOrder(Node node, System.Collections.Generic.Stack<Node> stack, HashSet<Node> visitedNodes)
        {
            // if we visited this node before during traversal then exit
            if(visitedNodes.Contains(node))
                return;

            // add node to visited-nodes set
            visitedNodes.Add(node);
            //traverse each neighbor recursively
            foreach (var neighborNode in _adjacencyList[node])
            {
                TopologicalOrder(neighborNode, stack, visitedNodes);
            }
            // after traversing all neighbors, add node to stack 
            stack.Push(node);
        }

        #endregion

        #region HasCycle - video #80 in Mosh course Part II

        public bool HasCycle()
        {
            var all = new HashSet<Node>(_nodes.Values); // initially contains all nodes in graph
            var visiting = new HashSet<Node>(); // // contains nodes that we did NOT visiting them & all their neighbors yet
            var visited = new HashSet<Node>(); // contains nodes after we visiting them & all their neighbors

            while (all.Count > 0)
            {
                using (var enumerator = all.GetEnumerator())
                {
                    enumerator.MoveNext();
                    var current = enumerator.Current;
                    if (HasCycle(current, all, visiting, visited))
                        return true;
                }

            }

            return false;
        }

        private bool HasCycle(Node current, HashSet<Node> all, HashSet<Node> visiting, HashSet<Node> visited)
        {
            all.Remove(current);
            visiting.Add(current);

            foreach (var neighbor in _adjacencyList[current])
            {
                //bypass neighbor if we visited it before
                if(visited.Contains(neighbor))
                    continue;
                // if we still visiting the neighbor then we have a cycle
                if (visiting.Contains(neighbor))
                    return true;
                //return true if neighbor has a Cycle
                if (HasCycle(neighbor, all, visiting, visited))
                    return true;
            }
            // here current node does not have a cycle so
            // 1) remove it from visiting collection
            // 2) add it to visited collection
            // 3) return false;
            visiting.Remove(current);
            visited.Add(current);
            return false;
        }

        #endregion
    }
}