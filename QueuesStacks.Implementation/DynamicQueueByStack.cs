namespace QueuesStacks.Implementation;

public class DynamicQueueByStack<T> : IDynamicQueue<T>
{
    // Fields
    private DynamicStack<T> _front, _back;

    // Properties
    public int Size { get; private set; }

    // Constructors
    public DynamicQueueByStack()
    {
        _front = new();
        _back = new();
        Size = 0;
    }

    // Methods
    public bool IsEmpty()
    {
        return Size == 0;
    }

    public void EnQueue(T item)
    {
        _back.Push(item);
        ++Size;
    }

    public T DeQueue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }

        --Size;

        try
        {
            return _front.Pop();
        }
        catch
        {
            while (!_back.IsEmpty())
            {
                _front.Push(_back.Pop());
            }

            return _front.Pop();
        }
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }

        try
        {
            return _front.Peek();
        }
        catch
        {
            while (!_back.IsEmpty())
            {
                _front.Push(_back.Pop());
            }

            return _front.Peek();
        }
    }

    public string Display()
    {
        List<T> l1 = _front.Content();
        List<T> l2 = _back.Content();
        l1.Reverse();
        var l = l1.Concat(l2);

        return '[' + String.Join(", ", l) + ']';
    }
}

