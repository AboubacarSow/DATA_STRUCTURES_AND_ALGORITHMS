namespace DataStructures.Stack.Contracts
{
    public interface IStack<T>
    {
        void Push(T value);
        T Pop();
        T Peek();
        int Count { get; }
    }

}
