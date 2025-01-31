namespace Graph
{
    internal class Program
    {
        static void Main(string[] args)
        {
          /*  int[,] adj =
            {
                { 0,1,1,0 },
                { 0,0,0,1 },
                { 0,0,0,0 },
                { 1,0,0,0 }
            };
            SGraph graph = new SGraph(adj);
            graph.Depth(3);*/

            SGraph2<string> graph2 = new SGraph2<string>(); 
            Node<string> node1 = new Node<string>("Moscow");
            Node<string> node2 = new Node<string>("Tokio");
            Node<string> node3 = new Node<string>("Sydney");
            Node<string> node4 = new Node<string>("Oslo");

            graph2.AddNode(node1);
            graph2.AddNode(node2);
            graph2.AddNode(node3);
            graph2.AddNode(node4);

            graph2.AddEdge(node1, node3);
            graph2.AddEdge(node3, node2);
            graph2.AddEdge(node2, node1);
            
            graph2.Width(node1);

        }
    }
}
