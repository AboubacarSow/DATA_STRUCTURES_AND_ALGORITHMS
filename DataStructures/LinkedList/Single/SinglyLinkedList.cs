using System.Collections;

namespace DataStructures.LinkedList.Single
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T>? Head { get; set; }
        public  SinglyLinkedListNode<T>? Tail { get;  private set; }

        public int Count { get; set; }
        

        public SinglyLinkedList() { Count = 0; }
        public SinglyLinkedList(IEnumerable<T> collection)
        {
            AddRange(collection);
        }
        //This method has O(1) time complexity
        public void AddFirst(T value)
        {
            if (value==null)
                throw new ArgumentNullException(nameof(value), "The provided parameter may be null");
            var newNode = new SinglyLinkedListNode<T>(value);
            if (InitLinkedList(newNode)) return;
            newNode.Next = Head;
            Head = newNode;
            Count++;
        }

        //Adding at one time more than one element
        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var value in collection)
                AddFirst(value);
        }

        //This method has O(n) time complexity
        public void AddToEnd(T value)
        {
            if (value is null)
                throw new ArgumentNullException("The provided parameter is null", nameof(value));
            var newNode = new SinglyLinkedListNode<T>(value);
            if (InitLinkedList(newNode)) return;
            var currentNode = Head;
            while (currentNode.Next is not null)
                currentNode = currentNode.Next;
            currentNode.Next = newNode;
            Count++;

        }
        //Althoug this method has O(1) time complexity
        public void AddLast(T value)
        {
            if (value is null)
                throw new ArgumentNullException("The provided parameter is null");
            var newNode = new SinglyLinkedListNode<T>(value);
            InitLinkedList(newNode);
            Tail.Next = newNode;
            Tail = newNode;
            Count++;
        }
        public void AddAfter(SinglyLinkedListNode<T> refNode, T value)
        {
            if (refNode is null || value is null)
                throw new ArgumentNullException("The provided parameter(s) is or are null");
            var newNode = new SinglyLinkedListNode<T>(value);
            var currentNode = Head;
            if (InitLinkedList(newNode)) return;
            while (currentNode is not null)
            {
                if (currentNode.Equals(refNode))
                {
                    if(currentNode.Next is not null)
                        newNode.Next = currentNode.Next;
                    currentNode.Next = newNode;
                    Count++;
                    return;
                }
                currentNode = currentNode.Next;
            }

            throw new ArgumentException("The LinkedList does not contain a reference of this refNode",nameof(refNode));
        }

        public void AddAfter(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            AddAfter(refNode, newNode.Value);
        }

        public void AddBefore(SinglyLinkedListNode<T> refNode, T value)
        {
            if (refNode is null || value is null)
                throw new ArgumentNullException("The provided parameter(s) is or are null");
            var newNode = new SinglyLinkedListNode<T>(value);
            var currentNode = Head;
            if (InitLinkedList(newNode)) return;
            while (currentNode is not null)
            {
                if (currentNode.Next is not null && currentNode.Next.Equals(refNode))
                {
                    newNode.Next = currentNode.Next;
                    currentNode.Next = newNode;
                    Count++;
                    return;
                }
                currentNode = currentNode.Next;
            }
            throw new ArgumentException("The LinkedList does not contain a reference of this refNode", nameof(refNode));
        }

        public void AddBefore(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            AddBefore(refNode, newNode.Value);
        }
        private bool InitLinkedList(SinglyLinkedListNode<T> newNode)
        {
            if (Head is null)
            {
                Head = newNode;
                Tail = newNode;
                Count++;
                return true;
            }
            return false;
        }


        public T RemoveFirst()
        {
            if (Head is null)
                throw new InvalidOperationException("The given LinkedList is already empty");
            if(Head.Next is null)
            {
                var valueT  = Head.Value;
                Head = null;
                Tail=null;
                Count = 0;
                return valueT;
            }
            var value = Head.Value;
            Head = Head.Next;
            Count--;
            return value;
        }
        public T RemoveLast()
        {
            if (Head is null)
                throw new InvalidOperationException("The given LinkedList is already empty");
            if (Head.Next is null)
            {
                var valueToReturn = Head.Value;
                Head = null;
                //Before asking chatgpt to improve my methode, there was not Tail=null
                //I forget to update the value of Tail 
                Tail = null;
                Count = 0;
                return valueToReturn;
            }
            var current = Head;
            while (current.Next.Next is not null)
                current = current.Next;
            var value = current.Next.Value;
            current.Next = null;
            Tail = current;
            Count--;
            return value;


            //This is the code i made before asking chatgpt
            //while(current is not null)
            //{
            //    if(current.Next is not null)
            //    {
            //       if(current.Next.Next is null)
            //       {
            //            
            //            Tail = current;
            //     
            //            current.Next=null;
            //            Count--;
            //            return;
            //       }
            //    }
            //    current = current.Next;
            //}

        }
        public void Remove(T value)
        {
            if (value is null)
                throw new ArgumentNullException("The provided value is actually a null value");
            if (Head is null)
                throw new ArgumentException("The given linkedlist is already empty");
            if(Head.Next is null)
            {
                Head = null;
                Tail = null;
                Count = 0;
                return;
            }
            var currentNode = Head;
            var refNode = new SinglyLinkedListNode<T>(value);
            while(currentNode is not null)
            {
                if (currentNode.Next.Equals(refNode))
                {
                    currentNode.Next = currentNode.Next.Next;
                    Count--;
                    return;
                }
                currentNode = currentNode.Next;
            }
            throw new ArgumentOutOfRangeException("The provided value does not exist in the given linkedlist", nameof(value));   
        }
        public IEnumerator<T> GetEnumerator()
        {

            
            return new SinglyLinkedListEnumerator<T>(Head);
            //In case we have IEnumerator<SinglyLinkedListNode<T>>
            //This approach is simple and fast but can only do an iteration without performing another service
            //for (var current = Head; current is not null; current = current.Next)
            //{
            //    yield return current;
            //}

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
