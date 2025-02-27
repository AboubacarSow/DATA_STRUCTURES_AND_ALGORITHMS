namespace DataStructures.LinkedList.SinglyLinkedListNode
{
    public class SinglyLinkedListNode<T>(T value): IEquatable<SinglyLinkedListNode<T>>
    {
        public SinglyLinkedListNode<T>? Next { get;  set; }

        public T Value { get; set; } = value;

        public bool Equals(SinglyLinkedListNode<T> other)
        {
            if (other is null)
                throw new ArgumentNullException("The reference of the node can not be null");
            return EqualityComparer<T>.Default.Equals(Value,other.Value);
        }

        public override string ToString()=>$"{Value}";
       

    }
}
