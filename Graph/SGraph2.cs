using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    internal class SGraph2<T>
    {
        private Dictionary<Node<T>, List<Node<T>>> _adjList = new();
        public void AddNode(Node<T> newNode)
        {
            //если узел не в графе, то связывается с пустым списком ссылок на другие узлы
            if (!_adjList.ContainsKey(newNode))
                _adjList[newNode] = new();
        }
        public void AddEdge(Node<T> startNode, Node<T> endNode)
        {
            if (_adjList.ContainsKey(startNode) && _adjList.ContainsKey(endNode))
            {
                _adjList[startNode].Add(endNode); //связали два узла в одном направлении
                _adjList[endNode].Add(startNode); //связали в обратном направлении (граф неориентированный)
            }
            else
                throw new Exception("оба узла на момент связи должны быть добавлены к графу");
        }

        public void Width(Node<T> startNode)
        {
            if (!_adjList.ContainsKey(startNode))
                throw new Exception("начальный узел не принадлежит графу");
            
            HashSet<Node<T>> visitedNodes = new();
            Queue<Node<T>> queue = new();

            queue.Enqueue(startNode);
            visitedNodes.Add(startNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue(); 
                Console.WriteLine(node + " -> ");
                foreach (Node<T> adjNode in _adjList[node])
                {
                    if (!visitedNodes.Contains(adjNode))
                    {
                        visitedNodes.Add(adjNode);
                        queue.Enqueue(adjNode);
                    }
                }
            }
        }
    }
}
