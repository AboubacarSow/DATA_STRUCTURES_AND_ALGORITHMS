namespace DataStructures.LinkedList.Double
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedListNode<T>? Head { get; set; }
        public DoublyLinkedListNode<T>? Tail { get; set; }
        public int Count { get;set; }

        public DoublyLinkedList() { Count = 0; }
    }
}
