namespace DataStructures.LinkedList.Double
{
    public class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode<T>? Prev { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public T Value { get;set; }

        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString();
    }
}
