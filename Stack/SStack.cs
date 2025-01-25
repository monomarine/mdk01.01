using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    /// <summary>
    /// стек на основе связного списка
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class SStack<T>
    {
        #pragma warning disable
        private Node<T> _top; //указатель на верхушку стека
        public bool IsEmpty => _top == null; //свойство для проверки (пустой/не пустой стек)

        public SStack()
        {
            _top = null;
        }
        /// <summary>
        /// добавление значения в стек
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            var newNode = new Node<T>(item);
            if (IsEmpty)
                _top = newNode;
            newNode.Previous = _top;
            _top = newNode;
        }
        /// <summary>
        /// извлечение значения из стека
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("stack is empty");
            T temp = _top.Value;
            _top = _top.Previous;
            return temp;
        }
        /// <summary>
        /// просмтр значения сверху без извлечения
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("stack is empty");
            return _top.Value;
        }
    }
}
