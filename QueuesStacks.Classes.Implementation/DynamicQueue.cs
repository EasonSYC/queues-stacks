namespace QueuesStacks.Classes.Implementation
{
    public class DynamicQueue<T> : IDynamicQueue<T>
    {
        // Fields
        private Node<T>? _front, _back;

        // Properties
        public int Size { get; private set; }

        // Constructors
        public DynamicQueue()
        {
            _front = null;
            _back = null;
            Size = 0;
        }

        // Methods
        public bool IsEmpty()
        {
            return Size == 0;
        }

        public void EnQueue(T item)
        {
            Node<T> newNode = new(item);
            if (IsEmpty())
            {
                _front = newNode;
                _back = newNode; // let both the front and back point to the current node
            }
            else // in this case _back cannot be null
            {
                _back!.Next = newNode; // let the original back point to the current note
                _back = newNode; // let the back be the current node
            }

            ++Size;
        }

        public T DeQueue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            // in this case _front cannot be null
            T val = _front!.Value;
            _front = _front.Next;
            --Size;

            if (IsEmpty()) // queue is empty, back should be null
                           // it was originally the value popped
            {
                _back = null;
            }

            return val;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }
            return _front!.Value;
        }

        public string Display()
        {
            Node<T>? node = _front;
            List<T> list = new();

            while (node != null)
            {
                list.Add(node.Value);
                node = node.Next;
            }

            return '[' + String.Join(", ", list) + ']';
        }
    }
}

