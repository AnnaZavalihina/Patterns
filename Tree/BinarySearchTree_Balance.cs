
namespace Patterns.Tree
{
    internal partial class BinarySearchTree
    {
        public void BalanceTree(TreeNode current)
        {
            int b_factor = Balance_factor(current);
            if (b_factor > 1)
            {
                if (Balance_factor(current.LeftBanch) > 0)
                {
                    var parentNode = current.Parent;
                    var newCurrent = RotateLL(current);
                    PlaceNewBalancedChild(parentNode, newCurrent, current);
                }
                else
                {
                    var parentNode = current.Parent;
                    var newCurrent = RotateLR(current);
                    PlaceNewBalancedChild(parentNode, newCurrent, current);
                }
            }
            else if (b_factor < -1)
            {
                if (Balance_factor(current.RightBanch) > 0)
                {
                    var parentNode = current.Parent;
                    var newCurrent = RotateRL(current);
                    PlaceNewBalancedChild(parentNode, newCurrent, current);
                }
                else
                {
                    var parentNode = current.Parent;
                    var newCurrent = RotateRR(current);
                    PlaceNewBalancedChild(parentNode, newCurrent, current);
                }
            }
        }
        public void PlaceNewBalancedChild(TreeNode? parentNode, TreeNode newCurrent, TreeNode current)
        {
            if (parentNode == null)
            {
                _treeNode = newCurrent;
            }
            else if (parentNode.LeftBanch == current)
            {
                parentNode.LeftBanch = newCurrent;
            }
            else
            {
                parentNode.RightBanch = newCurrent;
            }
        }
        public int Balance_factor(TreeNode current)
        {
            int l = GetHeight(current.LeftBanch);
            int r = GetHeight(current.RightBanch);
            int b_factor = l - r;
            return b_factor;
        }
        public int GetHeight(TreeNode current)
        {
            int height = 0;
            if (current != null)
            {

                int l = GetHeight(current.LeftBanch);
                int r = GetHeight(current.RightBanch);
                int m = l > r ? l : r;
                height = ++m;
            }
            return height;
        }
        public TreeNode RotateRR(TreeNode parent) // 5
        {
            var pivot = parent.RightBanch; // 6
            parent.RightBanch = pivot.LeftBanch;
            pivot.LeftBanch = parent;

            pivot.Parent = parent.Parent;
            parent.Parent = pivot;

            return pivot;
        }
        public TreeNode RotateLL(TreeNode parent)
        {
            var pivot = parent.LeftBanch;
            parent.LeftBanch = pivot.RightBanch;
            pivot.RightBanch = parent;

            pivot.Parent = parent.Parent;
            parent.Parent = pivot;

            return pivot;
        }
        public TreeNode RotateLR(TreeNode parent)
        {
            TreeNode pivot = parent.LeftBanch;
            parent.LeftBanch = RotateRR(pivot);
            return RotateLL(parent);
        }
        public TreeNode RotateRL(TreeNode parent)
        {
            TreeNode pivot = parent.RightBanch;
            parent.RightBanch = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
}
