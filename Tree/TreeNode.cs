namespace Patterns.Tree
{
    internal class TreeNode
    {
        public int Value 
        {
            get; 
            set;
        }
        public TreeNode? Parent { get; set; }
        public TreeNode? LeftBanch 
        {
            get;
            set;
        }
        public TreeNode? RightBanch
        {
            get;
            set;
        }
        public TreeNode (int value, TreeNode? left = null,TreeNode? right = null, TreeNode? parent = null) 
        {
            Value = value;
            LeftBanch = left;
            RightBanch = right;
            Parent = parent;
        }

    }
}
