using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class Node<T>
    {
        #pragma warning disable
        public T Value {  get; set; }  //полезное значение в узле
        public Node<T> Next { get; set; } //ссылка на следующий узел

        public Node(T value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
