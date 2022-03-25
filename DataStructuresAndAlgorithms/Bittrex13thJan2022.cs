using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class Bittrex13thJan2022
    {
        public static void BittrexMain(string[] args)
        {
            // you can write to stdout for debugging purposes, e.g.
            Console.WriteLine("This is a debug message");
            TNode root = new TNode();
            root.val = 6;
            //root.left=;
            //root.right=8;
        }

        public class TNode
        {
            public int val;
            public TNode left;
            public TNode right;

            public TNode()
            {

            }
        }

        //        8
        //    4       6
        //        2       10
        // pre: 6 4 8 7 9
        // 6 -> 4
        // 6 -> 8 ->7
        // l1 6- 8 -9 
        // l2 6- 8 - 7
        //  i=0; int result =-1; l1[i] ==l2[i] { i++; result = l1[i]; } else { return result;}

        public static TNode LCA(TNode a, TNode b, TNode root) // lowest common ancestor
        {
            // left of root is <=root
            // right of root is >root
            if (root == null) return root;
            int aval = a.val;
            int bval = b.val;
            TNode node = root;
            while (node != null)
            { //8
                if (aval > node.val && bval > node.val)
                {
                    node = node.right;
                }
                else if (aval < node.val && bval < node.val)
                {
                    node = node.left;
                }
                else
                {
                    return node;
                }
            }
            return node;
        }
    }    
}
