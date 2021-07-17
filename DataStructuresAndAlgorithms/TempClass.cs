using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class TempClass
    {
        //    Given a binary tree, imagine yourself standing on the right side of it, return the values of the nodes you can see ordered from top to bottom.
        //Example: 
        //  1              <---  Inorder: 25

        // /   \ 


        //2      3         <--- 


        // \      \ 


        //  5      4       <---  

        //Output: [1, 3, 4]

        public void RightSideOfBT(BTNode root)
        { // level order traversal using queue
            // base case
            if (root == null) return;
            Queue<BTNode> q = new Queue<BTNode>();
            q.Enqueue(root);

            BTNode temp;
            while (q.Count != 0)
            {
                int size = q.Count; //1
                int i = 1;
                while (i <= size)
                {
                    temp = q.Dequeue();
                    if (i == size)
                    {
                        Console.WriteLine(temp.key);
                    }
                    if (temp.left != null)
                    {
                        q.Enqueue(temp.left);
                    }
                    if (temp.right != null)
                    {
                        q.Enqueue(temp.right);
                    }
                    i++;
                }
            }
        }

        public void RecRightSide(BTNode root, int level)
        {

        }

    }


    public class BTNode
    {
        public int key;
        public BTNode left { get; set; }
        public BTNode right { get; set; }

        public BTNode(int x)
        {
            key = x;
        }
    }

    
}
