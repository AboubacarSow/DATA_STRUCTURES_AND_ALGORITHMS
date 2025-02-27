
using DataStructures.LinkedList.SinglyLinkedListNode;
using System.Collections;
using System.Runtime.CompilerServices;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    internal class SinglyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private  SinglyLinkedListNode<T>? Head;
        private  SinglyLinkedListNode<T>? _current;

        public SinglyLinkedListEnumerator(SinglyLinkedListNode<T> head)
        {
            Head = head;
            _current = null;
        }
        //This represents item in foreach
        public T Current => _current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            //What does this method
            //This method helps the GC to collecte the garbages values
            Head = null;
        }

        public bool MoveNext()
        {
            //When we load in the first time in this method
            //_current is for sure equal to null
            //We need to put this if conditionnal in order to begining the move at the Head position 
            if (_current is null)
                _current = Head;
            else
                _current = _current.Next;
            return _current is not null;
        }

        public void Reset()
        {
            _current = null;
        }
    }
}