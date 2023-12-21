namespace Patterns.LinkedList
{
    internal class MyLinkedList : MyList
    {
        public MyLinkedList() { }
        public void RemoveListNode(int value)
        {
            if (_firstNode == null)
            {
                Console.WriteLine("No Nodes at all!");
            }

            else if (_firstNode.MyValue == value)
            {
                _firstNode = _firstNode.NextListNode;
                Console.WriteLine($"Node with value {value} is deleted");
            }

            else
            {
                bool isDeleted = false;
                var node = _firstNode;
                while (node.NextListNode != null)
                {
                    node = node.NextListNode;
                    if (node.MyValue == value)
                    {
                        node = node.NextListNode;
                        Console.WriteLine($"Node with value {value} is deleted");
                        isDeleted = true;
                        break;
                    }
                }

                if (node.NextListNode == null && !isDeleted)
                {
                    Console.WriteLine($"There is no Node with value {value}");
                }
            }
        }
        public override int Count()
        {
            int counter = base.Count();
            Console.WriteLine($"LinkedList length = {counter}");
            return counter;
        }
    }
}
