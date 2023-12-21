namespace Patterns.Quene
{
    internal class MyQuene : MyList
    {
        public MyQuene() { }
        public ListNode Pop() 
        {
            if (!IsEmpty())
            {
                var node = _firstNode;
                _firstNode = _firstNode.NextListNode;
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
                Console.WriteLine("I see "+_firstNode.MyValue);
                return _firstNode;
            }
            else 
            {
                Console.WriteLine("No Nodes!");
                return null;
            }
        }
        public override int Count() 
        {
            int counter = base.Count();
            Console.WriteLine($"Quene length = {counter}");
            return counter;
        }
    }
}
