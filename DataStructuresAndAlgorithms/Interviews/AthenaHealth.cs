using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{   

    
    public class AthenaHealth
    {
        /// <summary>
        /// You are also given an n-length sequence of folding instructions:
        //L -> fold left edge onto right edge
        //R -> fold right edge onto left edge
        //After performing the n folds, you will now have a folded stack
        //that is 1 square wide and 2^n squares tall.Imagine a toothpick
        //being pushed completely through the stack from the top down.
        //Return the sequence of numbers that the toothpick will pierce in order.

        // Input:
        //Example where n = 2:
        //1 2 3 4

        // Output:
        //Example where n = 1:
        //L = 1,2
        //R = 2,1

        // Output:
        //Example where n = 2: 1 2 3 4
        // LL, LR, RL, RR
        //LL = 3,2,1,4
        //RR = 2,3,4,1
        //LR = 4,1,2,3
        //RL = 1,4,3,2
        /// </summary>
        public void PaperFold(int n, string inst)
        {
            double squares = Math.Pow(2,n);

            for(int i = 0; i < inst.Length; i++)
            {
                //after every fold squares = squares / 2 
                
            }
        }
    }
}
