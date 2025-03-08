namespace DataStructures.Queue.Contracts
{
    public interface IQueue<T>
    {
        int Count { get; }
        void EnQueue(T value);
        T DeQueue();
        T Peek();

    }

}
