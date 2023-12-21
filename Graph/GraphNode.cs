namespace Patterns.Graph
{
    internal class GraphNode
    {
        public int Id
        {
            get;
            set;
        }
        public List<GraphNode>? GraphNodes 
        {
            get;
            set;
        }
        public GraphNode(int graphId) 
        {
            Id = graphId;
            GraphNodes = new List<GraphNode>();
        }
    }
}
