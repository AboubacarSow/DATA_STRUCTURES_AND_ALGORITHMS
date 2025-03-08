using DataStructures.Array;
using DataStructures.Queue.Contracts;

namespace DataStructures.Queue.Models
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private readonly Array<T> list = new Array<T>();
        public int Count => list.Count;

        public T DeQueue()
        {
            if (Count == 0)
                throw new InvalidOperationException("The given Queue may be empty");
            var temp = list.First();
                list.Remove(list.First());
            return temp;
        }

        public void EnQueue(T value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value),"The given Argument may be null");
            list.Add(value);
        }

        public T Peek()
        {
            if(Count==0) throw new InvalidOperationException("The given Queue may be empty");
            return list.First();
        }
    }
}