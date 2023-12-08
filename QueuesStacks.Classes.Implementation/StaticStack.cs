namespace QueuesStacks.Classes.Implementation
{
    public class StaticStack<T> : IStaticStack<T>
    {
        // Fields
        private readonly T[] _innerArray;

        // Properties
        public int Capacity { get; private set; }
        public int Size { get; private set; }

        // Constructor
        public StaticStack(int capacity)
        {
            Capacity = capacity;
            Size = 0;
            _innerArray = new T[capacity];
        }

        // Methods
        public bool IsEmpty()
        {
            return Size == 0;
        }

        public bool IsFull()
        {
            return Size == Capacity;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return _innerArray[--Size];
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return _innerArray[Size - 1];
        }

        public void Push(T item)
        {
            if (IsFull())
            {
                throw new StackOverflowException("Stack is full");
            }
            _innerArray[Size++] = item;
        }

        public string Display()
        {
            List<T> list = new();

            for (int i = 0; i < Size; ++i)
            {
                list.Add(_innerArray[i]);
            }

            return '[' + String.Join(", ", list) + ']';
        }

    }
}

