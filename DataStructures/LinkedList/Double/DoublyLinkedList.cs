using System.Collections;

namespace DataStructures.LinkedList.Double
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public DoublyLinkedListNode<T>? Head { get; set; }
        public DoublyLinkedListNode<T>? Tail { get; set; }
        public int Count { get;set; }

        public DoublyLinkedList() { Count = 0; }
        public DoublyLinkedList(IEnumerable<T> collection)
        {
            AddRange(collection);
        }
        public void AddRange(IEnumerable<T> collection)
        {
            foreach(var node in collection)
                AddFirst(node);
        }
        public void AddFirst(T value)
        {
            if (value is null) //This verification is only valuable for reference type such as class
                throw new ArgumentNullException(nameof(value),"The provided parameter may be null");
            var newNode = new DoublyLinkedListNode<T>(value);
            if (InitLinkedList(newNode)) return;
            Head.Prev = newNode;
            newNode.Next = Head;
            Head = newNode;
            Count++;
            
        }
        public void AddLast(T value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value), "Provided parameter may be null");
            var newNode = new DoublyLinkedListNode<T>(value);
            if (InitLinkedList(newNode)) return;
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
            Count++;
        }
        public void AddAfter( DoublyLinkedListNode<T> refNode, T value)
        {
            if (refNode is null)
                throw new ArgumentNullException(nameof(refNode), "Provided node may be null");
            var newNode = new DoublyLinkedListNode<T>(value);
            var currentNode = Head;
            while(currentNode is not null)
            {
                if (currentNode.Equals(refNode))
                {
                    newNode.Prev = currentNode;
                    if(currentNode.Next is null)
                        Tail = newNode;//Update Tail node
                    else
                        newNode.Next = currentNode.Next;
                    currentNode.Next = newNode;//Updated currentNode.Next;
                    Count++;
                    return;
                }
                currentNode = currentNode.Next;
            }
            throw new ArgumentException("The LinkedList does not contain a reference of this refNode", nameof(refNode));

        } 
        public void AddAfter( DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            AddAfter(refNode, newNode.Value);
        }
        public void AddBefore(DoublyLinkedListNode<T> refNode,T value)
        {
            if (refNode is null || value is null) throw new ArgumentNullException("Argument(s) may be null");
            var newNode = new DoublyLinkedListNode<T>(value);
            var currentNode = Head;
            while(currentNode is not null)
            {
                if (currentNode.Equals(refNode))
                {
                    newNode.Next = currentNode;
                    newNode.Prev = currentNode.Prev;
                    currentNode.Prev = newNode;//Updated the new node of current.Prev; 
                    if (currentNode.Next is null)
                        Tail=currentNode; //Updated Tail, actually it's Tail.Prev
                    Count++;
                }
            }
            throw new ArgumentException("The LinkedList does not contain a reference of this refNode", nameof(refNode));
        }
        public void AddBefore(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            AddBefore(refNode, newNode.Value);
        } 

        public T RemoveFirst()
        {
            if (Head is null)
                throw new InvalidOperationException("This operation can not be done because the given node list is already empty");
            var valueToDelete = Head.Value;
            if(Head.Next is null)
            {
                Tail = null;
                Count = 0;
            }
            Head = Head.Next;
            if (Head is not null)
                Head.Prev = null;
            Count--;
            return valueToDelete;
        }
        public T RemoveLast()
        {
            if (Head is null)
                throw new InvalidOperationException("This operation can not be done because the given node list is already empty");
            if (Head.Next is null)
            {
                var valueToDelete = Head.Value;
                Tail = null;
                Head = null;
                Count = 0;
                return valueToDelete;
            }
            var delete = Tail.Value;
            Tail = Tail.Prev;
            Tail.Next = null;
            Count--;
            return delete;
        }
        public void Remove(T value)
        {
            if (value is null)
                throw new ArgumentNullException("Null argument is not valuable");
            if(Head is null)
                throw new InvalidOperationException("This operation can not be done because the given node list is already empty");
            var currentNode = Head;
            var node = new DoublyLinkedListNode<T>(value);
            while(currentNode is not null)
            {
                if (currentNode.Equals(node))
                {
                    if(currentNode.Prev is null)
                    {
                        RemoveFirst();
                        return;
                    }
                    if(currentNode.Next is null)
                    {
                        RemoveLast(); return;
                    }
                    currentNode.Prev.Next = currentNode.Next;
                    currentNode.Next.Prev = currentNode.Prev;
                    currentNode = null;
                    Count--;
                }
                currentNode = currentNode.Next;
            }
            throw new ArgumentException("The LinkedList does not contain a reference of this value", nameof(value));
        }
        private bool InitLinkedList(DoublyLinkedListNode<T> node)
        {
            if (Head is null)
            {
                Head = node;
                Tail = node;
                Count++;
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(Head,Tail);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
