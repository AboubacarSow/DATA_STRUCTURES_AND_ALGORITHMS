using DataStructures.LinkedList.Single;
using DataStructures.Queue.Contracts;
using DataStructures.Stack;

namespace DataStructures.Queue.Models
{
    internal class LinkedListQueue<T> : IQueue<T>
    {
        private readonly SinglyLinkedList<T> list = new SinglyLinkedList<T>();
        public int Count => list.Count;
        

        public T DeQueue()
        {
            if (Count == 0)
                throw new InvalidOperationException("The given Queue may be empty");
            //need to delete the last element of our linkedlist
            return list.RemoveFirst();
        }

        public void EnQueue(T value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value), "The given Queue may be null");
            list.AddLast(value);
        }

        public T Peek()
        {
            if (Count == 0) throw new InvalidOperationException("The given Queue may be empty");
            return list.Head.Value;
        }
    }
}