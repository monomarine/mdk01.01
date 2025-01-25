namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SLinkedList<string> sLinkedList = new();
            sLinkedList.AddFirst("Иванов");
            sLinkedList.AddLast("Петров");
            sLinkedList.AddLast("Сидоров");

            sLinkedList.RemoveAfter("Иванов");
            Console.WriteLine(sLinkedList);
        }
    }
}
