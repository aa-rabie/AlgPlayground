using System;
using System.Collections.Generic;

using System.Text;

namespace AlgPlayGroundApp.Amazon.Demo
{
    public class HousesProblem
    {
        
        public void Test()
        {

        }
        public int[] CellComplete(int[] states, int days)
        {
            //initialization
            Cell[] cells = new Cell[states.Length];
            for (int i = 0; i < states.Length; i++)
            {
                var leftState = i == 0 ? 0 : states[i - 1];
                var rightState = i == states.Length - 1 ? 0 : states[i + 1];
                cells[i] = new Cell(states[i],leftState, rightState);
            }
            //processing
            for (int i = 0; i < days; i++)
            {
                // for first day, no need to update initial state with previous day processing results
                // initial state is initialized from params
                if (i > 0)
                {
                    for (int j = 0; j < cells.Length; j++)
                    {
                        var leftState = j == 0 ? 0 : cells[j - 1].FinalState;
                        var rightState = j == cells.Length - 1 ? 0 : cells[j + 1].FinalState;
                        //for each new day, update initial state before calculating new states values
                        cells[j].UpdateState(leftState,rightState); 
                    }
                }
                foreach (var cell in cells)
                {
                    //updating states
                    cell.CalculateFinalState();
                }
                
            }

            var result = new int[cells.Length];
            for (int i = 0; i < cells.Length; i++)
            {
                result[i] = cells[i].FinalState;
            }

            return result;
        }
    }

    
    public class Cell
    {
        public int InitialState { get; set; }
        public int FinalState { get; set; }
        public int? LeftCellState { get; set; }
        public int? RightCellState { get; set; }
        public Cell(int initialState, int leftCellState, int rightCellState)
        {
            InitialState = initialState;
            LeftCellState = leftCellState;
            RightCellState = rightCellState;
        }

        public void CalculateFinalState()
        {
            FinalState = LeftCellState.GetValueOrDefault(0) ^ RightCellState.GetValueOrDefault(0);
        }

        public void UpdateState(int leftState, int rightState)
        {
            InitialState = FinalState;
            LeftCellState = leftState;
            RightCellState = rightState;
        }
    }
}
