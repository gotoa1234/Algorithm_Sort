namespace Algorithm_Sort.Practical
{
    public class BinaryTreeSortExecute
    {
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39 };
            
            var execute = new BinaryTreeSort<int>();

            var result =  execute.BinarySorting(inputItem);
        }
    }

    /// <summary>
    /// 二元樹排序 - BinaryTree Sort 有序二元樹（ordered binary tree）或排序二元樹（sorted binary tree）
    /// Time Complex : O(log n)
    ///        Space : O(n)
    ///    Best Time : O(log n)
    ///   Worst Time : O(n²)（不平衡時）
    ///         原理 : 給定一組可比較陣列
    ///                1. 將該組陣列轉換為二元樹
    ///                2. 利用中序搜尋法找出節點
    ///                3. 遍歷完該樹後中序的結果為排序後的結果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTreeSort<T> where T : IComparable<T>
    {
        public List<int> BinarySorting(List<int> inputItem)
        {
            //1. 數組第一個節點為根結點
            TreeNode root = new TreeNode(inputItem[0]);
            //2. 建構二元樹
            for (int index = 1; index < inputItem.Count(); index++)
                BuildTree(root, inputItem[index]);            
            //3. 中序排序結果
            var result = new List<int>();
            InOrderTraversal(root, ref result);
            return result;
        }

        /// <summary>
        /// 建構二元樹
        /// </summary>
        public void BuildTree(TreeNode node, int value)
        {
            //左節點
            if (value < node.value)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new TreeNode(value);
                }
                else
                {
                    BuildTree(node.LeftNode, value);
                }
            }
            else//右節點
            {
                if (node.RightNode == null)
                {
                    node.RightNode = new TreeNode(value);
                }
                else
                {
                    BuildTree(node.RightNode, value);
                }
            }
        }

        /// <summary>
        /// 中序
        /// </summary>
        private void InOrderTraversal(TreeNode node,ref List<int> container)
        {
            //走到Null直接捨棄
            if (node == null)            
                return;
            InOrderTraversal(node.LeftNode, ref container);
            container.Add(node.value);
            InOrderTraversal(node.RightNode, ref container);
        }
    }

    /// <summary>
    /// 二元樹節點結構
    /// </summary>
    public class TreeNode
    {
        public int value;
        public TreeNode LeftNode;
        public TreeNode RightNode;

        public TreeNode(int value)
        {
            this.value = value;
            this.LeftNode = null;
            this.RightNode = null;
        }
    }
}
