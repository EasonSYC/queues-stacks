namespace QueuesStacks.Classes.Implementation
{
    public class Node<T>
    {
        public T Value { get; private set; }
        public Node<T>? Next { get; set; } // this acts as a link to the next node
        public Node<T>? Prev { get; set; } // this acts as a link to the previous node

        public Node(T value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }
}

