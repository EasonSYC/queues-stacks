namespace QueuesStacks.Implementation;

public interface IDynamicStack<T>
{
    // Properties
    public int Size { get; } // Returns the number of items in the stack

    // Methods
    public bool IsEmpty(); // Returns true if the stack is empty

    public void Push(T item); // Adds a new item to the top of the stack.

    public T Pop(); // Removes and returns the top item from the stack

    public T Peek(); // Returns the top item from the stack but does not remove it

    public string Display(); // Returns a string which displays the items in the stack e.g. [10, 12]. Returns [] for an empty stack.

}
