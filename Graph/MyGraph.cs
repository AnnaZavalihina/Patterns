namespace Patterns.Graph
{
    internal class MyGraph
    {
        private List<GraphNode> _nodes;
        public MyGraph() 
        {
            _nodes = new List<GraphNode>();
        }
        public void AddNode(int newGraphId) 
        {
            if (NodeExists(newGraphId))
            {
                Console.WriteLine($"There is Node with Id = {newGraphId}");
            }
            else 
            {
                Console.WriteLine($"Added Id {newGraphId}");
                _nodes.Add(new GraphNode(newGraphId));
            }
        }
        public void ConnectNodes(int firstNodeValue, int secondNodeValue) 
        {
            if (!NodeExists(firstNodeValue) || !NodeExists(secondNodeValue))
            {
                Console.WriteLine($"No such Node to connect {firstNodeValue} or {secondNodeValue}");
            }
            else if (firstNodeValue == secondNodeValue)
            {
                Console.WriteLine("This is 1 Node!");
            }
            else
            {
                var firstNode = GetNode(firstNodeValue);
                var secondNode = GetNode(secondNodeValue);
                firstNode.GraphNodes.Add(secondNode);
                secondNode.GraphNodes.Add(firstNode);
                Console.WriteLine($"Nodes {firstNodeValue} and {secondNodeValue} are connected");
            }
        }
        public void DeleteNode(int deleteNodeValue) 
        {
            var deletNode = GetNode(deleteNodeValue);
            if (deletNode == null)
            {
                Console.WriteLine($"No such Node to delete {deleteNodeValue}");
            }
            else
            {
                var listToUpdate = deletNode.GraphNodes;
                foreach ( var node in listToUpdate ) 
                {
                    node.GraphNodes.Remove(deletNode);
                }
                _nodes.Remove(deletNode);
            }
        }
        public void DeleteConnection(int firstNodeValue, int secondNodeValue)
        {
            if (!NodeExists(firstNodeValue) || !NodeExists(secondNodeValue))
            {
                Console.WriteLine($"No such Node {firstNodeValue}, {secondNodeValue}");
            }
            else
            {
                var firstNode = GetNode(firstNodeValue);
                var secondNode = GetNode(secondNodeValue);
                if (firstNode.GraphNodes.Contains(secondNode))
                {
                    firstNode.GraphNodes.Remove(secondNode);
                    secondNode.GraphNodes.Remove(firstNode);
                    Console.WriteLine($"Connection between {firstNodeValue} and {secondNodeValue} is deleted");
                }
                else 
                {
                    Console.WriteLine($"Nodes ({firstNodeValue}, {secondNodeValue}) are not connected");
                }
            }
        }
        public GraphNode? GetNode(int findGraphNodeId) 
        {
            if (_nodes != null)
            {
                foreach (GraphNode node in _nodes) 
                {
                    if (findGraphNodeId == node.Id)
                    {
                        return node;
                    }
                }
            }
            return null;
        }
        public bool NodeExists(int id)
        {
            if (_nodes != null)
            {
                foreach (GraphNode node in _nodes)
                {
                    if (id == node.Id)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public List<GraphNode>? GetConnectedNodes(int nodeId) 
        {
            var node = GetNode(nodeId);
            if (node!=null) 
            {
                return node.GraphNodes;
            }
            Console.Write($"No such Node {nodeId}\t");
            return null;
        }
        public void PrintConnectedNodes(int nodeId) 
        {
            List<GraphNode> connectedNodes = GetConnectedNodes(nodeId);
            if (connectedNodes != null)
            {
                foreach (GraphNode node in connectedNodes)
                {
                    Console.Write($"{node.Id}  ");
                }
                Console.Write("\n");
            }
            else
            {
                Console.WriteLine("No connected Nodes");
            }
        }
        public void ClearGraph() 
        {
            foreach (GraphNode node in _nodes) 
            {
                node.GraphNodes = null;
            }
            _nodes.Clear();
            Console.WriteLine("Clear");
        }
        public int SearchShortWay(int node1, int node2) 
        {
            if (NodeExists(node1) && NodeExists(node2))
            {
                int d = 0;
                List<GraphNode> checkedNodes = new (_nodes.Count);
                
                GraphNode checkNode = GetNode(node1);
                checkedNodes.Add(checkNode);
                Queue<GraphNode>[] generationsQuene = new Queue<GraphNode>[_nodes.Count];
                Queue<GraphNode> queue = new Queue<GraphNode>(GetConnectedNodes(node1));
                generationsQuene[0] = queue;

                while (generationsQuene[d] != null) 
                {
                    d++;
                    var checkQuene = generationsQuene[d-1];

                    while (checkQuene.Count > 0) 
                    {
                        checkNode = checkQuene.Dequeue();
                        if (checkNode.Id == node2)
                        {
                            Console.WriteLine($"Way will {node1}->{node2}last = {d}");
                            return d;
                        }
                        checkedNodes.Add (checkNode);
                        foreach (GraphNode n in checkNode.GraphNodes)
                        {
                            Console.WriteLine($"{d} - {n.Id}");
                            if (!checkedNodes.Contains(n))
                            {
                                if (generationsQuene[d] == null)
                                {
                                    generationsQuene[d] = new Queue<GraphNode>();
                                }
                                generationsQuene[d].Enqueue(n);
                            }
                        }
                    }
                }
                Console.WriteLine($"No connection between {node1}-{node2}");
                return -1;
            }
            Console.WriteLine($"No such Node {node1}, {node2}");
            return -1;
        }
    }
}
