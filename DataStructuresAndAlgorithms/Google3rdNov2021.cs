using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    // Interview by Meghana vishwanath, ex microsoft employee, working for google for 10 years
    public class Google3rdNov2021
    {
        // Return the index of the maximal value of an array. Input arrays are guaranteed to have
        // elements which are sorted in strictly increasing order until the max followed by elements
        // which are strictly decreasing after that.
        // Some sample valid input arrays:
        // [ 1, 4, 8, 10, 2]
        // [1, 2, 3, 100]
        // [43, 23, 13, 0]
        // [100, 2]
        // [1, 90]
        // [100]

        //i=3, i-1<i, i> i+1 and i>=0 or i<arr size

        public int findHighest(int[] arr)
        {
            if (arr.Length == 1) return arr[0];

            return fhUtil(arr, 0, arr.Length - 1);


        }
        public int fhUtil(int[] a, int start, int end)
        {

            int mid = (start + end) / 2;
            if (a[mid - 1] < a[mid] && a[mid] > a[mid + 1]) return mid;
            else if (a[mid - 1] > a[mid])
            {
                return fhUtil(a, start, mid - 1);
            }
            else
            {
                return fhUtil(a, mid + 1, end);
            }

        }
    }

    // Find the second largest element of a binary search tree that is not necessarily balanced.
    //  100
    //  / \
    //25  175  
    //    / \
    // 165   195


    // in-order traversal         
    //25,100,165,175,195 -->
    public class bstClass
    {
        int sH = int.MinValue, fH = int.MinValue;

        public int SLargeElement(TreeNode root)
        {
            bstUtil(root);
            return sH;
        }

        public void bstUtil(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            if (root.left != null)
            {
                bstUtil(root.left);
            }
            if (root.val > fH)
            {
                sH = fH;
                fH = root.val;
            }
            if (root.right != null)
            {
                bstUtil(root.right);
            }
        }

    }
}
