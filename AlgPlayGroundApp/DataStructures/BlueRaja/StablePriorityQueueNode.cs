namespace Priority_Queue
{
    // source : https://github.com/BlueRaja/High-Speed-Priority-Queue-for-C-Sharp - library 5.00
    public class StablePriorityQueueNode : FastPriorityQueueNode
    {
        /// <summary>
        /// Represents the order the node was inserted in
        /// </summary>
        public long InsertionIndex { get; internal set; }
    }
}
