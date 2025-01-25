using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LinkedList
{
    internal class SLinkedList<T>
    {
        #pragma warning disable
        private Node<T> _head; //постоянный указатель на начало списка
        public SLinkedList()
        {
            _head = null;
        }

        #region add/remove first item
        /// <summary>
        /// добавление узла в начало списка
        /// </summary>
        /// <param name="value">значение узла</param>
        /// <exception cref="Exception"></exception>
        public void AddFirst(T value)
        {
            if (value is not null)
            {
                Node<T> temp = new Node<T>(value);
                temp.Next = _head;
                _head = temp;
            }
            else
                throw new Exception("value is empty");
        }
        /// <summary>
        /// удаление узла из начала
        /// </summary>
        public void RemoveFirst()
        {
            if (_head == null) //если список пуст
                return;
            _head = _head.Next; //перепись указателя на следующий узел
        }
        #endregion

        #region add/remove last item
        /// <summary>
        /// добавление в конец списка
        /// </summary>
        /// <param name="value">значение узла</param>
        /// <exception cref="Exception"></exception>
        public void AddLast(T value)
        {
            if (value is null)
                throw new Exception("Value is null");
            
            var temp = new Node<T>(value);

            if (_head is null)//если список пуст
                _head = temp;

            var current = _head; //указатель с помощью которого будем перебирать все элементы до конца списка
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = temp; //связывание последнего узла списка с новым

        }
        /// <summary>
        /// удаление из конца списка
        /// </summary>
        public void RemoveLast()
        {
            if (_head is null || _head.Next is null)
                return;
            var current = _head;
            //указатель проверяет ссылки на последующие узлы "заглядывая" через узел
            //те получение предпоследнего элемента
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;//удаляется связь на последний элемент
        }
        #endregion

        #region add/remove in middle list
        public void RemoveAfter(T value)
        {
            if(_head == null || _head.Next == null)
                return;//если пустой список или всего один элемент
            
            var current = FindNode(value);
            //переброска ссылки на следующий элемент через удаляемый
            if(current != null)
                current.Next = current.Next.Next;
        }
        public void AddAfter(T existingValue, T newValue)
        {
            var node = FindNode(existingValue);
            if (node != null)
            {
                var newNode = new Node<T>(newValue);
                newNode.Next = node.Next;
                node.Next = newNode;
            }
        }
        public void AddBefore(T executingValue, T newValue) 
        { //сам
        }
        public void RemoveBefore(T value)
        {
            //сам
        }
        #endregion
        
        /// <summary>
        /// поиск узла по значению
        /// </summary>
        /// <param name="value">искомое значение</param>
        /// <returns>ссылка на узел</returns>
        public Node<T> FindNode(T value)
        {
            if (_head is null)
                return null;
            var current = _head;    
            while(current.Next is not null &&
                current.Value.ToString != value.ToString)
            {
                current = current.Next;
            }
            //проверить
            if (current.Value.ToString == value.ToString)
                return current;
            else return null;
        }
        public Node<T> FindNode(T value, out Node<T> previousNode)
        {
            throw new NotImplementedException();
            //TODO
        }

        public override string ToString()
        {
            string result = "";
            var current = _head;
            while (current != null)
            {
                result += $"{current.Value} -> ";
                current = current.Next;
            }
            return result;
        }
    }
}
