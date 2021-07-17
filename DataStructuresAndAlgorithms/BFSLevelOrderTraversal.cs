using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructuresAndAlgorithms
{
    public class BFSLevelOrderTraversal
    {
        public void PrintLevelOrderNonRecursive(BinaryTreeNode<int> root)
        {
            Queue<BinaryTreeNode<int>> queue = new Queue<BinaryTreeNode<int>>();            
            queue.Enqueue(root);
            while (queue.Count !=0)
            {
                BinaryTreeNode<int> temp = queue.Dequeue();
                Console.WriteLine(temp.Value);
                if (root.Left != null)
                {
                    queue.Enqueue(root.Left);
                }
                if (root.Right != null)
                {
                    queue.Enqueue(root.Right);
                }                
            }
        }

        public void PrintLevelOrderRecursive(BinaryTreeNode<int> root)
        {
            int h = HeightOfBST(root);
            for(int i = 1; i <= h; i++)
            {
                PrintGivenLevel(root, i);
            }
        }

        public void PrintGivenLevel(BinaryTreeNode<int> root, int level)
        {
            if (root == null)
            {
                return;
            }
            if (level == 1)
            {
                Console.WriteLine(root.Value + " ");
            }
            else if (level > 1)
            {
                PrintGivenLevel(root.Left, level - 1);
                PrintGivenLevel(root.Right, level - 1);
            }
        }

        public int HeightOfBST(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                int leftHeight = HeightOfBST(root.Left);
                int rightHeight = HeightOfBST(root.Right);
                if (leftHeight > rightHeight)
                {
                    return leftHeight + 1;
                }
                else
                {
                    return rightHeight + 1;
                }                
            }
        }
    }
}
