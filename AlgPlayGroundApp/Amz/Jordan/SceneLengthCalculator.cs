using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

namespace AlgPlayGroundApp.Amazon.Jordan
{
    public class SceneLengthCalculator
    {
        public List<int> CalculateEachSceneLength(List<char> inputList)
        {
            int startLoc = 0;
            List<int> result = new List<int>();
            HashSet<char> uniqueChar = new HashSet<char>();
            foreach (var ch in inputList)
            {
                uniqueChar.Add(ch);
            }
            // if all char not repeated the all scene length = 1
            if (uniqueChar.Count == inputList.Count)
                return Enumerable.Repeat(1, inputList.Count).ToList();

            while (startLoc < inputList.Count)
            {
                var len = CalculateSceneLength(startLoc == 0
                    ? inputList
                    : inputList.GetRange(startLoc, inputList.Count - startLoc));
                startLoc += len ;
                result.Add(len);
            }

            return result;
        }

        private int CalculateSceneLength(List<char> inputList)
        {
            HashSet<char> uniqueChar = new HashSet<char>();
            foreach (var ch in inputList)
            {
                uniqueChar.Add(ch);
            }

            var table = new Dictionary<char, CharInfo>();
            foreach (var ch in uniqueChar)
            {
                var start = inputList.IndexOf(ch);
                var end = inputList.LastIndexOf(ch);

                table.Add(ch, new CharInfo()
                {
                    Start = start,
                    End = end
                });
            }

            var sceneControllingInfo = table[inputList[0]];
            foreach (var entry in table)
            {
                if (entry.Value.Start < sceneControllingInfo.Length && entry.Value.End > sceneControllingInfo.End)
                {
                    //extend scene length
                    sceneControllingInfo.End = entry.Value.End;
                }
            }

            return sceneControllingInfo.Length;
        }

        class CharInfo
        {
            public int Start { get; set; }
            public int End { get; set; }
            public int Length => End - Start +1;
        }
    }
}