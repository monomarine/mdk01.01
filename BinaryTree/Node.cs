using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Node<T> :IComparable
    {
        #pragma warning disable
        T Value { get; set; }
        Node<T> Left { get; set; } //ссылка на левое поддерево
        Node<T> Right { get; set; } //ссылка на правое поддерево
        public Node(T value)
        {
            Value=value;
            Left = null;
            Right = null;
        }
        public override string ToString()
        {
            return Value.ToString();
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }
    }
}
