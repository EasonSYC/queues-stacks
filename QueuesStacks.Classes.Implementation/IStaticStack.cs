namespace QueuesStacks.Implementation
{
    public interface IStaticStack<T>
    {
        // Properties
        public int Size { get; } // Returns the number of items in the stack

        public int Capacity { get; } // Returns the maximum number of items in the stack

        // Methods
        public bool IsEmpty(); // Returns true if the stack is empty

        public bool IsFull(); // Returns true if the staick is full

        public void Push(T item); // Adds a new item to the top of the stack. Throws a StackOverFlowException if the stack is full.

        public T Pop(); // Removes and returns the top item from the stack

        public T Peek(); // Returns the top item from the stack but does not remove it

        public string Display(); // Returns a string which displays the items in the stack e.g. [10, 12]. Returns [] for an empty stack.

    }
}
