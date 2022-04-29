using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgPlayGroundApp.Algorithms
{
    /// <summary>
    /// know more from manning course at https://livevideo.manning.com/module/31_7_3/algorithms-in-motion/dijkstra%27s-algorithm/implementing-dijkstra%27s-algorithm?
    /// </summary>
    public class Dijkstra
    {
        public class Graph : Dictionary<Node, List<Node>>
        {

        }
        public class Node
        {
            protected bool Equals(Node other)
            {
                return _label == other._label && _distance == other._distance;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Node) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return HashCode.Combine(_label);
                }
            }

            private readonly string _label;
            private readonly int _distance;

            public Node(string label, int distance)
            {
                if (string.IsNullOrEmpty(label))
                    throw new ArgumentNullException(label);

                if(distance < 0)
                    throw new ArgumentOutOfRangeException(nameof(distance), "Dijkstra Algorithm cannot work with negative cost/distance/weight");

                _label = label;
                _distance = distance;
            }

            public Node(string label): this(label, 0) { }

            public string Label => _label;
            public int Distance => _distance;

            public override string ToString()
            {
                return _label;
            }
        }

        public void Run(Graph graph, Node src)
        {
            if (graph == null || src == null)
                return;

            Dictionary<string,int> costDict = InitCostDict();
            Dictionary<string,string> parentsDict = InitParentsDict();
            Dictionary<string,bool> visitedDict = new Dictionary<string, bool>(graph.Keys.Count);
            visitedDict[src.Label] = true;

            Node FindLowestCostNode()
            {
                var minCost = int.MaxValue;
                Node lowestCostNode = null;
                var nodes = graph.Keys.ToList();
                foreach (var (label, cost ) in costDict)
                {
                    if (!visitedDict.ContainsKey(label) && cost < minCost)
                    {
                        minCost = cost;
                        lowestCostNode = graph.Keys.FirstOrDefault(e => e.Label == label);
                    }
                }
                return lowestCostNode;

            }

            Dictionary<string, int> InitCostDict()
            {
                var dict = new Dictionary<string, int>(graph.Keys.Count);
                dict[src.Label] = 0;
                var otherNodes = graph.Keys.ToList().Where(n => n.Label != src.Label);
                var srcNeighbors = (graph[src] ?? new List<Node>(0)).ToList(); 
                foreach (var node in otherNodes)
                {
                    if (srcNeighbors.Any(n => n.Label == node.Label))
                    {
                        dict[node.Label] = srcNeighbors.First(n => n.Label == node.Label).Distance;
                    }
                    else
                    {
                        dict[node.Label] = int.MaxValue;
                    }
                }

                return dict;
            }

            Dictionary<string, string> InitParentsDict()
            {
                var dict = new Dictionary<string,string>();
                var srcNeighbors = graph[src] ?? new List<Node>();

                foreach (var node in srcNeighbors)
                {
                    dict.Add(node.Label, src.Label);
                }

                return dict;
            }


            var currentNode = FindLowestCostNode();

            while (currentNode != null)
            {
                var neighbors = graph[currentNode] ?? new List<Node>();
                var cost = costDict[currentNode.Label];
                foreach (var node in neighbors)
                {
                    int newCost = node.Distance + cost;

                    if (newCost < costDict[node.Label])
                    {
                        // update node cost 
                        costDict[node.Label] = newCost;
                        // update parents dict
                        parentsDict[node.Label] = currentNode.Label;
                    }
                }
                
                visitedDict[currentNode.Label] = true;
                currentNode = FindLowestCostNode();
            }

            PrintDistanceFromSrc(src, costDict);
        }

        void PrintDistanceFromSrc(Node src, Dictionary<string,int> costDic)
        {
            foreach (var (label, cost) in costDic)
            {
                if(label == src.Label)
                    continue;

                Console.WriteLine($"distance to {label} from {src.Label} is : {cost}");
            }
        }
    }
}