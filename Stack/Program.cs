using System.Reflection.Metadata;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SStack<int> stack = new();

            stack.Push(10);
            stack.Push(100);
            stack.Push(1000);

            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
        }
    }
}
