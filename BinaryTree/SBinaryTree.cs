using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class SBinaryTree<T> where T : class
    {
        #pragma warning disable
        private Node<T> _root; //корневой элемент дерева
        public SBinaryTree()
        {
            _root = null;
        }
        public void AddNode(Node<T> existingNode, T value)
        {
            if (value != null)
            {
                Node<T> newNode = new Node<T>(value);
                if(value.ToString() < existingNode.Value)
            }

        }
    }
}
