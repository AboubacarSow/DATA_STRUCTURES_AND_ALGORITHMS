using DataStructures.Tree.BinaryTree;
using System.Collections;

namespace DataStructures.Tree.BinarySearchTree
{
    public class BST<T> : IEnumerable<T>
         where T : IComparable
    {
        public Node<T> Root { get; set; }

        public BST()
        {
            
        }
        public BST(T value)
        {
            var newNode = new Node<T>(value);
            Root = newNode;
        }
        public BST(Node<T> root)
        {
            Root = root;
        }

        public BST(IEnumerable<T> collection)
        {
            foreach (var value in collection)
                Add(value);
        }
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T value)
        {
            var newNode = new Node<T>(value);
            if (Root is null) { 
                Root = newNode;
                return;
            } 
            Node<T> parent;
            var currentNode = Root;
            while (true)
            {
                 parent = currentNode!;
                if (value.CompareTo(currentNode.Value) < 0)
                {
                    currentNode = currentNode?.Left;
                    if (currentNode is null)
                    {
                        parent.Left = newNode;
                        return;
                    }
                }
                else
                {
                    currentNode = currentNode?.Right;
                    if (currentNode is null)
                    {
                        parent.Right = newNode;
                        return;
                    }
                }
            }
        }
    }
}
