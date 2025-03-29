using DataStructures.Stack.Models;
namespace DataStructures.Tree.BinaryTree
{
    public class BinaryTree<T> where T : IComparable
    {
        public List<Node<T>> list { get; private set; } 
        public BinaryTree()
        {
            list = [];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns> </returns>
        public List<Node<T>> InOrder(Node<T> root)
        {
            if(root is not null)
            {
                InOrder(root.Left);
                list.Add(root);
                InOrder(root.Right);
            }
            return list;
        }
        public List<Node<T>> InOrderIteratifTraversal(Node<T> root)
        {
            var stack = new DataStructures.Stack.Models.Stack<Node<T>>();
            var done = false;
            var currentNode = root;
            while (!done)
            {
                if(currentNode is not null)
                {
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode = stack.Pop();
                        list.Add(currentNode);
                        currentNode = currentNode.Right;
                    }
                }
            }
            return list;
        }
        public List<Node<T>> PreOrder(Node<T> root)
        {
            if(root is not null)
            {
                list.Add(root);
                PreOrder(root.Left);
                PreOrder(root.Right);
                
            }
            return list;
        }
        public List<Node<T>> PostOrder(Node<T> root)
        {
            if(root is not null)
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                list.Add(root);
            }
            return list;
        }

        
    }
}
