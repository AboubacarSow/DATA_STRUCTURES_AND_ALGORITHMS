namespace DataStructures.LinkedList.Double
{
    public class DoublyLinkedListNode<T> : IEquatable<DoublyLinkedListNode<T>>
    {
        public DoublyLinkedListNode<T>? Prev { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
        public T Value { get;set; }

        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString();

        public bool Equals(DoublyLinkedListNode<T>? other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other), "The reference node can not be null");
            return EqualityComparer<T>.Default.Equals(Value, other.Value);
        }
    }
}
