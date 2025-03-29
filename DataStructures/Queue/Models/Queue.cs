using DataStructures.Queue.Contracts;
using DataStructures.Queue.Models.Enums;

namespace DataStructures.Queue.Models
{
    public class Queue<T>
    {
        private readonly IQueue<T> queue;
        public Queue(QueueType type = QueueType.ArrayQueue)
        {
            if (type == QueueType.ArrayQueue)
                queue = new ArrayQueue<T>();
            else
                queue = new LinkedListQueue<T>();
        }
        public int Count => queue.Count;
        public void EnQueue(T value)
        {
            queue.EnQueue(value);
        }
        public T DeQueue()
        {
            return queue.DeQueue();
        }
        public T Peek()
        {
            return queue.Peek();
        }

        
    }

}
