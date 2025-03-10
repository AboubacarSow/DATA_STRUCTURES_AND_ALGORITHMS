﻿using DataStructures.Array;
using DataStructures.LinkedList.Double;
using DataStructures.LinkedList.Single;


namespace Apps
{
     class Program
    {
        static void Main(string[] args)
        {
            var arr = new Array<int>(4, 5, 6);
            Console.WriteLine($"First Element: {arr.First()}");
           Stack_Test();
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
