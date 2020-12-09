using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgPlayGroundApp.DataStructures
{
    /// <summary>
    /// weighted un-directed Graph
    /// for more info see video 83, 84 in Mosh data-structure course part II
    /// </summary>
    public class WeightedGraph
    {
        public class Node
        {
            private string _label;
            // we used dictionary instead of list 
            // to be easy for us to check if this node is connected to other node or not
            private Dictionary<string, Edge> _edges = new Dictionary<string, Edge>();
            public Node(string label)
            {
                if (string.IsNullOrEmpty(label))
                    throw new ArgumentNullException(label);

                _label = label;
            }

            public string Label => _label;
            public List<Edge> Edges => _edges.Values.ToList();

            public override string ToString()
            {
                return _label;
            }

            public bool EqualTo(Node n)
            {
                if (n == null)
                    return false;
                if (_label == null && n._label != null || _label != null && n._label == null)
                    return false;
                if (!n.Label.Equals(_label))
                    return false;

                return true;
            }

            public void AddEdge(Node to, int weight)
            {
                if(to == null)
                    throw new ArgumentNullException(nameof(to));

                if(!_edges.ContainsKey(to.Label))
                    _edges.Add(to.Label, new Edge(this, to, weight));
            }
        }

        public class Edge
        {
            private readonly Node _from;
            private readonly Node _to;
            private int _weight;

            public Edge(Node from, Node to, int weight)
            {
                _from = from;
                _to = to;
                _weight = weight;
            }

            public override string ToString()
            {
                return $"{_from}->{_to}";
            }

            public bool EqualTo(Edge e)
            {
                if (e == null)
                    return false;
                if (_from == null && e._from != null || _from != null && e._from == null)
                    return false;
                if (_to == null && e._to != null || _to != null && e._to == null)
                    return false;

                if (!_from.EqualTo(e._from))
                    return false;
                if (!_to.EqualTo(e._to))
                    return false;

                return true;
            }
        }

        private Dictionary<string, Node> _nodes = new Dictionary<string, Node>();
        //any node can be connected to 0..N Nodes
        

        public void AddNode(string label)
        {
            var node = new Node(label);
            _nodes.TryAdd(label, node);
        }

        public void AddEdge(string from, string to, int weight)
        {
            if (!_nodes.ContainsKey(from))
                throw new ArgumentException(nameof(from));

            if (!_nodes.ContainsKey(to))
                throw new ArgumentException(nameof(to));

            var fromNode = _nodes[from];
            var toNode = _nodes[to];

            // this in un-directed graph 
            // so we need to add two edges 

            // Edge from "FromNode" to "ToNode"
            fromNode.AddEdge(toNode, weight);

            // add another Edge from "ToNode" to "FromNode"
            toNode.AddEdge(fromNode,weight);
             
        }

        public void Print(TextWriter writer)
        {
            foreach (var entry in _nodes.Values)
            {
                var edges = entry.Edges;
                if (edges.Any())
                {
                    writer.WriteLine($"{entry} is connected to [{string.Join(',', edges)}]");
                }
            }
        }
    }
}