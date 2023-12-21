namespace Patterns
{
    internal class MyList
    {
        protected ListNode? _firstNode;
        public virtual void AddNewNode(int newValue)
        {
            ListNode newNode = new(newValue);
            if (IsEmpty())
            {
                _firstNode = newNode;
            }
            else
            {
                var node = _firstNode;
                while (node.NextListNode != null)
                {
                    node = node.NextListNode;
                }
                node.NextListNode = newNode;
            }
        }
        public void SortList()
        {
            int length = Count();
            if (length > 1)
            {
                for (; length > 0;)
                {
                    var node = _firstNode;
                    while (node.NextListNode != null)
                    {
                        int node1 = node.MyValue;
                        int node2 = node.NextListNode.MyValue;
                        if (node2 > node1)
                        {
                            node.MyValue = node2;
                            node.NextListNode.MyValue = node1;
                        }
                        node = node.NextListNode;
                    }
                    length--;
                }
            }
        }
        public virtual int Count()
        {
            if (IsEmpty())
            {
                return 0;
            }

            else
            {
                int counter = 1;
                var node = _firstNode;
                while (node.NextListNode != null)
                {
                    counter++;
                    node = node.NextListNode;
                }
                return counter;
            }
        }
        public void PrintAllNodes()
        {
            if (IsEmpty())
            {
                Console.WriteLine("No Nodes!");
            }

            else
            {
                var node = _firstNode;
                while (node.NextListNode != null)
                {
                    Console.Write(node.MyValue + ", ");
                    node = node.NextListNode;
                }

                Console.Write(node.MyValue + "\n");
            }
        }

        protected bool IsEmpty()
        {
            return _firstNode == null;
        }

        public ListNode? FindNode(int value)
        {
            if (IsEmpty())
            {
                Console.WriteLine("No Nodes at all!");
                return null;
            }

            var node = _firstNode;
            if (node.MyValue == value)
            {
                Console.WriteLine($"Node with value {value} is found");
                return node;
            }
            while (node.NextListNode != null)
            {
                node = node.NextListNode;
                if (node.MyValue == value)
                {
                    Console.WriteLine($"Node with value {value} is found");
                    return node;
                }
            }
            Console.WriteLine($"There is no Node with value {value}");
            return null;
        }
        public void Clear()
        {
            while (_firstNode.NextListNode != null) 
            {
                _firstNode = _firstNode.NextListNode;
            }
            _firstNode.NextListNode = null;
        }
    }
}
