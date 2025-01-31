using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    internal class SGraph
    {
        private int[,] adjMatrix; //матрица смежности
        private int nodeCount; //количество вершин
        bool[] visitedNodes; //вектор посещенных вершин
        //конструктор для пустого графа
        public SGraph(int count)
        { 
            nodeCount = count;
            adjMatrix = new int[count, count];
            visitedNodes = new bool[count];
        }

        public SGraph(int[,] adj)
        {
            nodeCount = adj.GetLength(0);
            adjMatrix = adj;
            visitedNodes = new bool[nodeCount];
        }
        /// <summary>
        /// добавление ребер
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void AddEdge(int start, int end)
        {
            adjMatrix[start, end] = 1; //путь из вершины start в end
            //adjMatrix[end, start] = 1; //если граф неориентированный
        }

        public void Depth(int start)
        {
            Console.WriteLine(start + " -> ");
            visitedNodes[start] = true;
            
            for(int i =0; i < nodeCount; i++)
            {
                for( int j = 0; j < nodeCount; j++)
                if (adjMatrix[i,j] == 1 && !visitedNodes[i])
                {
                    Depth(i);
                }
            }

        }


    }
}

