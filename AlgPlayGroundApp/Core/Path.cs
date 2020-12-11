using System.Collections.Generic;

namespace AlgPlayGroundApp.Core
{
    public class Path
    {
        public List<string> Nodes { get; private set; } = new List<string>();

        public void AddNode(string label)
        {
            if(string.IsNullOrEmpty(label))
                return;

            Nodes.Add(label);
        }

        public override string ToString()
        {
            return string.Join(',', Nodes);
        }
    }
}