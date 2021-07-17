using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class Reversing
    {
        public void ReverseArray(int[] Array)
        {
            int arrayLength = Array.Length;
            for(int i = 0; i < arrayLength / 2; i++)
            {
                int temp = Array[i];
                Array[i] = Array[arrayLength - 1 - i];
                Array[arrayLength - 1 - i] = temp;
            }
            Console.WriteLine("\n Reversed array:\n");
            for (int k = 0; k < Array.Length; k++)
            {

                Console.Write(Array[k]);
                Console.Write(" ");
            }
        }
    }
}
