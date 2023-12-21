namespace Patterns.Tree
{
    internal partial class BinarySearchTree
    {
        private TreeNode? _treeNode;
        
        public void AddingNewNode(int newNodeValue)
        {
            if (!IsEmpty())
            {
                var node = _treeNode;
                AddNode(newNodeValue, node);
            }
            else 
            {
                _treeNode = new TreeNode(newNodeValue);
            }
        }
        public void AddNode(int newValue, TreeNode node)
        {
            if (node.Value > newValue)
            {
                if (node.LeftBanch != null)
                {
                    AddNode(newValue, node.LeftBanch);
                    BalanceTree(node);
                }
                else 
                {
                    node.LeftBanch = new TreeNode(newValue) { Parent = node };
                    Console.WriteLine("{0} node is added", newValue);
                }
            }
            else if (node.Value < newValue)
            {
                if (node.RightBanch != null)
                {
                    AddNode(newValue, node.RightBanch);
                    BalanceTree(node);
                }
                else
                {
                    node.RightBanch = new TreeNode(newValue) { Parent = node };
                    Console.WriteLine("{0} node is added", newValue);
                }
            }
            else
            {
                Console.WriteLine($"There is such node {newValue}");
            }
        }

        public void RemoveNode(int nodeValue)
        {
            if (IsEmpty())
            {
                Console.WriteLine("No Nodes at all!");
            }
            else
            {
                Delete(nodeValue, _treeNode);
            }
        }
        public void Delete(int nodeValue, TreeNode current)
        {
            TreeNode parentNode;
            if (current != null)
            {
                if (nodeValue < current.Value)
                {
                    Delete(nodeValue, current.LeftBanch);
                    BalanceTree(current);
                } 
                else if (nodeValue > current.Value)
                {
                    Delete(nodeValue, current.RightBanch);
                    BalanceTree(current);
                }
                else
                {
                    if (current.RightBanch != null)
                    {
                        parentNode = current.RightBanch;
                        while (parentNode.LeftBanch != null)
                        {
                            parentNode = parentNode.LeftBanch;
                        }
                        
                        current.Value = parentNode.Value;

                        Delete(parentNode.Value, current.RightBanch);
                        
                        if (Balance_factor(current) == 2)
                        {
                            BalanceTree(current);
                        }
                    }
                    else if (current.LeftBanch != null)
                    {
                        PlaceNewBalancedChild(current.Parent, current.LeftBanch, current);
                        current.LeftBanch.Parent = current.Parent;
                    }
                    else 
                    {
                        PlaceNewBalancedChild(current.Parent, null, current);
                    }
                }
            }
        }

        public TreeNode? FindNode(int findNodeValue) 
        {
            if (IsEmpty())
            {
                Console.WriteLine("No Nodes at all!");
                return null;
            }
            var comparedNode = _treeNode;
            while (true) 
            {
                if (comparedNode == null)
                {
                    Console.WriteLine($"No Node with value = {findNodeValue}");
                    return null;
                }
                if (findNodeValue == comparedNode.Value)
                {
                    Console.WriteLine($"Node {findNodeValue} is find");
                    return comparedNode;
                }
                
                comparedNode = findNodeValue < comparedNode.Value ? 
                    (comparedNode.LeftBanch) : (comparedNode.RightBanch);
            }
        }
        public void PrintNodes() 
        {
            if (!IsEmpty())
            {
                PrintNode(_treeNode);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No Nodes!");
            }
        }
        public void PrintNode(TreeNode node)
        {
            if (node.LeftBanch != null)
            {
                PrintNode(node.LeftBanch);
                Console.Write(", ");
            }
            Console.Write($"(h-{GetHeight(node)}={node.Value})");
            if (node.RightBanch != null)
            {
                Console.Write(", ");
                PrintNode(node.RightBanch);
            }
        }
        public bool IsEmpty() 
        {
            return _treeNode == null;
        }
    }
}
