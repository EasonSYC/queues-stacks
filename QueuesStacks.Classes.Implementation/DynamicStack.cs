namespace QueuesStacks.Classes.Implementation
{
    public class DynamicStack<T> : IDynamicStack<T>
    {
        // Fields
        private Node<T>? _top;

        // Properties
        public int Size { get; private set; }

        // Constructor
        public DynamicStack()
        {
            Size = 0;
            _top = null;
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            // in this case _top cannot be null
            T val = _top!.Value;
            _top = _top.Next; // let the new top be where the current top is pointing to
            --Size;

            return val;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            // in this case _top cannot be null
            return _top!.Value;
        }

        public void Push(T item)
        {
            Node<T> newNode = new(item);

            if (IsEmpty())
            {
                _top = newNode;
            }
            else
            {
                newNode.Next = _top; // let the current node point to the original top
                _top = newNode; // let the top be the new node
            }

            ++Size;
        }

        public string Display()
        {
            return '[' + String.Join(", ", Content()) + ']';
        }

        internal List<T> Content()
        {
            Node<T>? node = _top;
            List<T> list = new();

            while (node != null)
            {
                list.Add(node.Value);
                node = node.Next;
            }

            list.Reverse();

            return list;
        }
    }
}

