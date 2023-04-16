using System.Collections.Generic;

namespace AlgPlayGroundApp.LeetCode.FindShortestPath
{
    public class FindPathWithinWallsAndGates
    {
        /*
         * Problem : https://leetcode.com/explore/learn/card/queue-stack/231/practical-application-queue/1373/
         * Solution : Approach #2 in https://leetcode.com/problems/walls-and-gates/editorial/
         * You are given an m x n grid rooms initialized with these three possible values.

            -1 A wall or an obstacle.
            0 A gate.
            INF Infinity means an empty room. 
        We use the value Int.MaxValue = 2147483647 to represent INF
        as you may assume that the distance to a gate is less than 2147483647.
        Fill each empty room with the distance to its nearest gate. 
        If it is impossible to reach a gate, it should be filled with INF.
         *
         */

        private const int EMPTY = int.MaxValue;
        private const int GATE = 0;
        private static List<int[]> DIRECTIONS = new List<int[]>(){
            new int[] { 1, 0 }, // up - one level
            new int[] { -1, 0 }, // down
            new int[] { 0, 1 }, // right
            new int[] { 0, -1 } // left
        };

        public void WallsAndGates(int[][] rooms)
        {
            int m = rooms.Length; //rows
            if (m == 0) return;
            int n = rooms[0].Length; // columns
            Queue<int[]> q = new Queue<int[]>();
            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (rooms[row][col] == GATE)
                    {
                        q.Enqueue(new int[] { row, col });
                    }
                }
            }
            while (q.Count > 0)
            {
                int[] point = q.Dequeue();
                int row = point[0];
                int col = point[1];
                foreach (int[] direction in DIRECTIONS)
                {
                    int r = row + direction[0];
                    int c = col + direction[1];
                    if (r < 0 || c < 0 || r >= m || c >= n || rooms[r][c] != EMPTY)
                    {
                        continue;
                    }
                    rooms[r][c] = rooms[row][col] + 1;
                    q.Enqueue(new int[] { r, c });
                }
            }
        }
    }
}