namespace QueuesStacks.Implementation;

public class StaticQueue<T> : IStaticQueue<T>
{
    // Fields
    private readonly T[] _innerArray;
    private int _front = 0;
    private int _back = 0;

    // Properties
    public int Size { get; private set; }
    public int Capacity { get; private set; }

    // Constructor
    public StaticQueue(int capacity)
    {
        Capacity = capacity;
        _innerArray = new T[capacity];
    }

    // Methods
    private int AddIndex(int val)
    {
        return (val + 1) % Capacity;
    }

    public T DeQueue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        T item = _innerArray[_front];
        _front = AddIndex(_front);
        --Size;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return _innerArray[_front];
    }

    public string Display()
    {
        List<T> list = new();

        for (int i = _front, count = 1; count <= Size; i = AddIndex(i), ++count)
        {
            list.Add(_innerArray[i]);
        }

        //for (int i = _front; i != _back; i = AddIndex(i))
        //{
        //    list.Add(_innerArray[i]);
        //}
        // this is the code I wrote the first time
        // this is not correct, since if the queue is full, then _front == _back and the loop won't even begin
        // an extra test is written for this

        return '[' + String.Join(", ", list) + ']';
    }

    public void EnQueue(T item)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("Queue is full");
        }
        _innerArray[_back] = item;
        _back = AddIndex(_back);
        ++Size;
    }

    public bool IsEmpty()
    {
        return Size == 0;
    }

    public bool IsFull()
    {
        return Size == Capacity;
    }
}
