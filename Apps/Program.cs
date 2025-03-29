using DataStructures.LinkedList.Double;
using DataStructures.LinkedList.Single;
using DataStructures.Tree.BinarySearchTree;
using DataStructures.Tree.BinaryTree;


namespace Apps
{
     class Program
    {
        static void Main(string[] args)
        {
            var binarySearchTree = new BST<int>( new int[]{ 35, 65,14, 78,24,10,45});
            Console.WriteLine("Recursive InOrder Approch");
            new BinaryTree<int>().InOrder(binarySearchTree.Root).ForEach(node => Console.Write($"{node,3}"));
            Console.WriteLine("\nRecursive PreOrder Approch");
            new BinaryTree<int>().PreOrder(binarySearchTree.Root).ForEach(node => Console.Write($"{node,3}"));
            Console.WriteLine("\nRecursive PostOrder Approch");
            new BinaryTree<int>().PostOrder(binarySearchTree.Root).ForEach(node => Console.Write($"{node,3}"));
            
            //Stack_Test();
            //SingleList_Test();
            //DoubleList_Test();
            Console.ReadKey();
        }

        private static void Stack_Test()
        {
            Stack<int> stack = new Stack<int>();
            int[] arr = { 1, 5, 8, 9 };
            foreach (var item in arr)
                stack.Push(item);
            stack.Pop();
            int length=stack.Count;
           
            Console.WriteLine($"Getting the first element of our stack: {stack.Peek()}");
        }

        private static void DoubleList_Test()
        {
            var doubleNode = new DoublyLinkedList<int>();
            doubleNode.AddFirst(5);
            doubleNode.AddFirst(145);
            doubleNode.AddAfter(new DoublyLinkedListNode<int>(5), 45);

            IEnumerable<int> nodes = Enumerable.Range(25, 5);
            doubleNode.AddRange(nodes);
            Console.WriteLine($"the number of element of the doubleNode :{doubleNode.Count}");
            Console.WriteLine("Elements of the double Linked list");
            foreach (var node in doubleNode) Console.Write($"{node,-5}");
            Console.WriteLine();
            doubleNode.Remove(145);
            Console.WriteLine($"Deletion of 145");
            Console.WriteLine("Elements after deletion");
            foreach (var node in doubleNode) Console.Write($"{node,-5}");
        }

        private static void SingleList_Test()
        {
            var linkedList = new SinglyLinkedList<int>();
            //Console.WriteLine($"The Header of my linkedList is {linkedList.Head}");
            linkedList.AddFirst(98);
            linkedList.AddFirst(15);
            linkedList.AddFirst(52);
            linkedList.AddFirst(8);
            linkedList.AddLast(45);
            linkedList.RemoveLast();

            //linkedList.AddToEnd(98);
            Console.WriteLine("Element of  linkedList");
            foreach (var item in linkedList)
                Console.Write($"{item,-4}");
        }
    }
}
