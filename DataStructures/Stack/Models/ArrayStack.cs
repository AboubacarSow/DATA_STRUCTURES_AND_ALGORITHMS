using DataStructures.Array;
using DataStructures.Stack.Contracts;

namespace DataStructures.Stack.Models
{
    public class ArrayStack<T> : IStack<T>
    {
        private readonly Array<T> list = new Array<T>();
        public int Count => list.Count;

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("The given stack is empty");
            return list.Last();
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("The given Stack is actually empty");
            var value =list.Remove();
            return value;
        }

        public void Push(T value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value), "The given argument may be null");
            list.Add(value);
        }
    }
}