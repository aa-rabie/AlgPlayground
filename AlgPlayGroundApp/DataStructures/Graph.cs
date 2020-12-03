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
        public IList<string> TraverseDepthFirst(string label)
        {
            var values = new List<string>();

            if (!_nodes.TryGetValue(label, out Node node))
                return values;

            TraverseDepthFirst(node, values, new HashSet<Node>());
            return values;
        }

        private void TraverseDepthFirst(Node node, List<string> values, HashSet<Node> visitedNodes)
        {
            visitedNodes.Add(node);
            values.Add(node.Label);

            foreach (var neighbor in _adjacencyList[node])
            {
                // we traverse a node only if it is not visited before
                if (!visitedNodes.Contains(neighbor))
                    TraverseDepthFirst(neighbor, values, visitedNodes);
            }
        }
        #endregion
    }
}