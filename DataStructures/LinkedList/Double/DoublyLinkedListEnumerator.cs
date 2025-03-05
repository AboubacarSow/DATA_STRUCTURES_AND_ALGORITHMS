
using System.Collections;

namespace DataStructures.LinkedList.Double
{
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private  DoublyLinkedListNode<T>? Head;
        private  DoublyLinkedListNode<T>? Tail;
        private DoublyLinkedListNode<T>? _current;
        public DoublyLinkedListEnumerator(DoublyLinkedListNode<T> head, DoublyLinkedListNode<T> tail)
        {
            Head = head;
            Tail = tail;
            _current = null;
        }

        public T Current => _current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            Head = null;
            Tail = null;
        }

        public bool MoveNext()
        {
            if (_current is null)
                _current = Head;
            else
                _current = _current.Next;
            return _current is not null;
        }

        public void Reset()
        {
            _current=null;
        }
    }
}