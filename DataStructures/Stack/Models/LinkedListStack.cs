using DataStructures.LinkedList.Single;
using DataStructures.Stack.Contracts;

namespace DataStructures.Stack.Models
{
    internal class LinkedListStack<T> : IStack<T>
    {
        private readonly SinglyLinkedList<T> list = new SinglyLinkedList<T>();
        public int Count => list.Count;

        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("The given Stack may be empty");
            return list.Head.Value;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("The given Stack may be empty");
            return list.RemoveFirst();
        }

        public void Push(T value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value),"The given Argument is null");
            list.AddFirst(value);
        }
    }
}