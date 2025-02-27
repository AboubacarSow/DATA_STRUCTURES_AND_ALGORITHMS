using DataStructures.LinkedList.SinglyLinkedList;

namespace Apps
{
     class Program
    {
        static void Main(string[] args)
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

            Console.ReadKey();
        }
    }
}
