using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Priority_Queue;
using Path = AlgPlayGroundApp.Core.Path;

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

            public Node From => _from;
            public Node To => _to;
            public int Weight => _weight;
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

        #region Get Shortest Path & Get Shortest Distance
        // for more info - for more info see video 86, 87, 88 in Mosh data-structure course part II
        public int GetShortedDistance(string from, string to)
        {
            if (!_nodes.ContainsKey(from))
                throw new ArgumentException(nameof(from));

            if (!_nodes.ContainsKey(to))
                throw new ArgumentException(nameof(to));

            var fromNode = _nodes[from];
            var toNode = _nodes[to];

            SimplePriorityQueue<Node> queue = new SimplePriorityQueue<Node>();
            //distances map will store distance between fromNode & all other nodes in graph
            Dictionary<Node,int> distances = new Dictionary<Node, int>(_nodes.Count);
            // visited HashSet will track nodes "we" visited during our traversal -
            // because we don't need to visit same node twice'
            HashSet<Node> visited = new HashSet<Node>();
            foreach (var node in _nodes.Values)
            {
                distances.Add(node,int.MaxValue);
            }

            distances[fromNode] = 0;
            //initially we enqueue "fromNode"
            queue.Enqueue(fromNode, 0);

            while (queue.Count > 0)
            {
                // as long as queue is not empty
                // we dequeue nodes
                // the dequeued node should be added to "visited" Hash-Set
                var current = queue.Dequeue();
                visited.Add(current);
                // for each node we iterate its neighbors (via edges)
                foreach (var edge in current.Edges)
                {
                    if(visited.Contains(edge.To))
                        continue;
                    // we calculate the distance to neighbor-node <=> which is stored in edge.To property
                    var newDistance = distances[current] + edge.Weight; // weight property store distance between current node and neighbor-node
                    if (newDistance < distances[edge.To])
                    {
                        //if new distance to neighbor node less than data in "distances" dictionary then
                        // 1) we update "distances" dictionary
                        distances[edge.To] = newDistance;
                        // 2) add this neighbor to priority queue
                        queue.Enqueue(edge.To, newDistance);
                    }
                }

            }
            // here we built distances table
            // now we can get shortest distance to specific "to" node
            return distances[toNode];
        }

        // Dijkstra's shortest path - video # 89 in Mosh Data Structure algorithm part II
        public Path GetShortedPath(string from, string to)
        {
            if (!_nodes.ContainsKey(from))
                throw new ArgumentException(nameof(from));

            if (!_nodes.ContainsKey(to))
                throw new ArgumentException(nameof(to));

            var fromNode = _nodes[from];
            var toNode = _nodes[to];

            SimplePriorityQueue<Node> queue = new SimplePriorityQueue<Node>();
            //distances map will store distance between fromNode & all other nodes in graph
            Dictionary<Node, int> distances = new Dictionary<Node, int>(_nodes.Count);
            // visited HashSet will track nodes "we" visited during our traversal -
            // because we don't need to visit same node twice'
            HashSet<Node> visited = new HashSet<Node>();
            // "previousNodes" will be used to build the path between "from" to "to" Nodes
            Dictionary<Node, Node> previousNodes = new Dictionary<Node, Node>();

            foreach (var node in _nodes.Values)
            {
                distances.Add(node, int.MaxValue);
            }

            distances[fromNode] = 0;
            //initially we enqueue "fromNode"
            queue.Enqueue(fromNode, 0);

            while (queue.Count > 0)
            {
                // as long as queue is not empty
                // we dequeue nodes
                // the dequeued node should be added to "visited" Hash-Set
                var current = queue.Dequeue();
                visited.Add(current);
                // for each node we iterate its neighbors (via edges)
                foreach (var edge in current.Edges)
                {
                    if (visited.Contains(edge.To))
                        continue;
                    // we calculate the distance to neighbor-node <=> which is stored in edge.To property
                    var newDistance = distances[current] + edge.Weight; // weight property store distance between current node and neighbor-node
                    if (newDistance < distances[edge.To])
                    {
                        //if new distance to neighbor node less than data in "distances" dictionary then
                        // 1) we update "distances" dictionary
                        distances[edge.To] = newDistance;
                        // 2) add this neighbor to priority queue
                        queue.Enqueue(edge.To, newDistance);
                        // update "previousNodes" collection
                        if (!previousNodes.TryAdd(edge.To, current))
                        {
                            previousNodes[edge.To] = current;
                        }
                    }
                }

            }
            // here we built distances table
            // now we can get shortest distance to specific "to" node
            return BuildPath(toNode, previousNodes);
        }

        private Path BuildPath(Node toNode, Dictionary<Node, Node> previousNodes)
        {
            //we will add "toNode" & nodes from "PreviousNodes" to stack
            // and then pop Nodes from stack 
            // so we can have the nodes & build the path from "fromNode" to "ToNode" in correct order.
            var stack = new System.Collections.Generic.Stack<Node>();
            stack.Push(toNode);

            previousNodes.TryGetValue(toNode, out var previous);
            while (previous != null)
            {
                stack.Push(previous);
                previous = previousNodes.ContainsKey(previous) ? previousNodes[previous] : null;
            }

            var path = new Path();
            while (stack.Count > 0)
            {
                path.AddNode(stack.Pop().Label);
            }

            return path;
        }
        #endregion

        public bool HasCycle()
        {
            HashSet<Node> visited = new HashSet<Node>();

            foreach (var node in _nodes.Values)
            {
                if (!visited.Contains(node) &&
                    HasCycle(node, null, visited))
                    return true;
            }

            return false;
        }

        private bool HasCycle(Node node, Node parent, HashSet<Node> visited)
        {
            visited.Add(node);
            // we need to check if neighbor nodes has Cycle or not
            // neighbor nodes are stored in Edge(s).To property
            foreach (var edge in node.Edges)
            {
                // if this neighbor is the parent-node (the node we came from) then bypass parent-node because
                // link with parent-node is not cycle
                if(edge.To == parent)
                    continue;

                // if neighbor-node exist in "visited" hash-set or HasCycle then we return true
                if (visited.Contains(edge.To) || HasCycle(edge.To, node, visited))
                    return true;
            }

            return false;
        }
    }
}