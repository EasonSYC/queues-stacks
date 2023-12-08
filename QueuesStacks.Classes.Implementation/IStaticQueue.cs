namespace QueuesStacks.Classes.Implementation
{
    public interface IStaticQueue<T>
    {
        // Properties
        public int Size { get; } // Returns the number of items in the queue

        public int Capacity { get; } // Returns the maximum number of items in the queue

        // Methods
        public bool IsEmpty(); // Returns true if the queue is empty

        public bool IsFull(); // Returns true if the queue is false

        public void EnQueue(T item); // Adds a new item to the queue. Throws an InvalidOperationException if the queue is full.

        public T DeQueue(); // Removes an item from the queue and returns it

        public T Peek(); // Returns the first item from the queue but does not remove it

        public string Display(); // Returns a string which displays the items in the queue e.g. [10, 12]. Returns [] for an empty queue.

    }
}