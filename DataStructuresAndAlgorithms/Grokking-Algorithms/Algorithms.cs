using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class GrokkingAlgorithms
    {
        public class BinarySearchWithoutRecursion(int[] arr, int number)
        {
            int low = 0;
            int high = arr.Length -1;
            while (low <=high){
                int mid = (low+high)/2;
                int guess = arr[mid];
                if(guess== number){
                    return mid;
                }
                if(guess > number){
                    high = mid-1;
                }
                else{
                    low =mid+1;
                }
            }
            return -1;            
        }
    }
}