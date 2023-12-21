namespace Patterns.Stack
{
    internal class MyStack : MyList 
    {
        public override void AddNewNode(int newValue)
        {
            ListNode newNode = new(newValue);
            if (!IsEmpty())
            {
                var nextNode = _firstNode;
                _firstNode = newNode;
                _firstNode.NextListNode = nextNode;
            }
            else
            {
                base.AddNewNode(newValue);
            }
        }
        public ListNode Pop()
        {
            if (!IsEmpty())
            {
                var node = _firstNode;
                _firstNode = node.NextListNode;
                return node;
            }
            else
            {
                Console.WriteLine("No Nodes!");
                return null;
            }
        }
        public ListNode Peek()
        {
            if (!IsEmpty())
            {
                Console.WriteLine("I see " + _firstNode.MyValue);
                return _firstNode;
            }
            else
            {
                Console.WriteLine("No Nodes!");
                return null;
            }
        }

        public int FindNodePosition(int findValue) 
        {
            if (IsEmpty()) 
            { 
                return -1; 
            }
            var node = _firstNode;
            int position = 1;
            int length = Count();
            for (; length > 0; length--)
            {
                if (node.MyValue == findValue)
                {
                    return position;
                }
                position++;
                node = node.NextListNode;
            }
            return -1;
        }

    }
}
