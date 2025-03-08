using DataStructures.Stack.Contracts;
using DataStructures.Stack.Models.Enums;

namespace DataStructures.Stack.Models
{
    public class Stack<T>
    {
        private readonly IStack<T> stack;

        public Stack(StackType type = StackType.Array)
        {
            if (type == StackType.Array)
            {
                stack = new ArrayStack<T>();
            }
            else
                stack = new LinkedListStack<T>();
        }
        public int Count => stack.Count;

        public T Peek()
        {
            return stack.Peek();
        }

        public T Pop()
        {
            return stack.Pop();
        }

        public void Push(T value)
        {
            stack.Push(value);
        }
    }

}
