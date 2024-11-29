namespace LinkedLists
{
    public class Program
    {
        public static void Main()
        {
            /*LinkedListBase<int> linkedList = new SinglyLinkedList<int>();
            TestLinkedList(linkedList);*/

            LinkedListBase<int> doublyLinkedList = new DoublyLinkedList<int>();
            TestLinkedList(doublyLinkedList);

            /*Queue<int> queue = new Queue<int>();
            TestLLQueue(queue);*/
        }
        private static void TestLinkedList(LinkedListBase<int> linkedList)
        {
            Console.WriteLine($"Testing {linkedList.GetType().Name}...");

            Random rand = new Random(42);

            for(int i = 0; i < 5; i++) 
            {
                linkedList.Insert(rand.Next(100));
            }

            Console.WriteLine(linkedList);

            Console.WriteLine("Inserting 150 at index 2");
            linkedList.Insert(150, 2);

            Console.WriteLine("Inserting 112 at index 2");
            linkedList.Insert(112, 2);

            Console.WriteLine(linkedList);

            Console.WriteLine($"Searching for 150: {linkedList.Search(150)}");

            Console.WriteLine($"Size of linked list: ${linkedList.Count}");

            Console.WriteLine("\nRemoving 112");
            linkedList.Remove(112);
            Console.WriteLine(linkedList);

            Console.WriteLine("Removing value at index 2");
            linkedList.RemoveAt(2);
            Console.WriteLine(linkedList);

            Console.WriteLine($"Searching for 150: {linkedList.Search(150)}");

            Console.WriteLine("Clearing list");
            linkedList.Clear();
            Console.WriteLine($"Is linked list empty? {linkedList.IsEmpty}");
            Console.WriteLine("\n===============\n");

        }

        private static void TestLLQueue(Queue<int> queue)
        {
            Console.WriteLine($"Testing {queue.GetType().Name}...");

            Random rand = new Random(42);

            for (int i = 0; i < 5; i++)
            {
                queue.Enqueue(rand.Next(100));
            }

            Console.WriteLine(queue);

            Console.WriteLine("Enqueuing 150 and 112...");
            queue.Enqueue(150);
            queue.Enqueue(112);

            Console.WriteLine(queue);

            Console.WriteLine($"Dequeue: {queue.Dequeue()}");
            
            Console.WriteLine($"Peek: {queue.Peek()}");

            Console.WriteLine(queue);

            Console.WriteLine($"Size of queue: ${queue.Count}");

            Console.WriteLine("\n===============\n");

        }
    }
}
