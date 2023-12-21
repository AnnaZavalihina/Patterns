using System.Runtime.InteropServices;

namespace Patterns
{
    internal class ListNode 
    {
        public int MyValue { get; set; }
        public ListNode? NextListNode { get; set; }
        public ListNode(int value)
        {
            MyValue = value;
            NextListNode = null;
        }
    }
}
