using System.Collections.Generic;
using System.Linq;

namespace AlgPlayGroundApp.LeetCode.Easy
{
    /// <summary>
    /// https://leetcode.com/problems/pascals-triangle-ii
    /// https://leetcode.com/problems/pascals-triangle-ii/solution/
    /// </summary>
    public class PascalTriangleII
    {
        public class Solution
        {
            public IList<int> GetRow(int rowIndex)
            {
                if (rowIndex == 0)
                    return new List<int>() { 1 };
                if (rowIndex == 1)
                    return new List<int>() { 1, 1 };

                var previousRow = GetRow(rowIndex - 1);
                int listSize = rowIndex + 1;

                var rowData = new List<int>();
                rowData.AddRange(Enumerable.Repeat(0,listSize));

                rowData[0] = rowData[listSize - 1] = 1;

                for(int colIndex = 1; colIndex < listSize - 1; colIndex++)
                {
                    rowData[colIndex] = previousRow[colIndex] + previousRow[colIndex - 1];
                }
                return rowData;
            }
        }
    }
}