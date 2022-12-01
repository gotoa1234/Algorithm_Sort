using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Sort.Practical
{
    public class BinaryTreeSortExecute
    {
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39 };
            var tree = new BinaryTree(inputItem.ToArray());
            var execute = new BinaryTreeSort<int>();
            var temp = new Tree() {};
            for (int index = 0; index < inputItem.Count; index++)
            {
                temp.insert(inputItem[index].ToString());
            }

            //var result = execute.BinaryTree(inputItem);
        }
    }

    /// <summary>
    /// 二元樹排序 - BinaryTree Sort 有序二元樹（ordered binary tree）或排序二元樹（sorted binary tree）
    /// Time Complex : O(log n)
    ///        Space : O(n)
    ///    Best Time : O(log n)
    ///   Worst Time : O(n²)（不平衡時）
    ///         原理 : 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTreeSort<T> where T : IComparable<T>
    {
    }

    public class BinaryTree
    {
        int value;
        BinaryTree left;
        BinaryTree right;

        public BinaryTree(int[] values) : this(values, 0) 
        { 
        }

        BinaryTree(int[] values, int index)
        {
            Load(this, values, index);
        }

        void Load(BinaryTree tree, int[] values, int index)
        {
            this.value = values[index];
            if (index * 2 + 1 < values.Length)
            {
                this.left = new BinaryTree(values, index * 2 + 1);
            }
            if (index * 2 + 2 < values.Length)
            {
                this.right = new BinaryTree(values, index * 2 + 2);
            }
        }
    }

    public class Node
    {
        public string data;
        public Node left { get; set; }
        public Node right { get; set; }

        public Node(string data)
        {
            this.data = data;
        }
    }

    public class Tree
    {
        public Node root;
        public Tree()
        {
            root = null;
        }
        public void insert(string data)
        {
            Node newItem = new Node(data);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                TreeNode sub = new TreeNode();
                Node current = root;
                Node parent = null;
                while (current != null)
                {
                    parent = current;
                    if (String.Compare(data, current.data) < 0)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newItem;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newItem;
                        }
                    }
                }
            }
        }
    }
}
