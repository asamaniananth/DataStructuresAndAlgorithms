using System;

namespace DataStructuresAndAlgorithms
{
    public class FindingSubstring
    {
        public void FindSubstringInArray()
        {
            char[] A = new char[] { 'C', 'O', 'N', 'C', 'A', 'T', 'I', 'N', 'A', 'T', 'E' };
            Char[] B = new char[] { 'C', 'A', 'T' };
            int i = 0, j = 0;
            int n = A.Length;
            int m = B.Length;
            int from = 0;
            int to = 0;
            //int remainingACharacters = n - 1 - i;            
            while (i < n && j < m) //&& remainingACharacters > B.Length
            {
                Console.WriteLine();
                //Console.WriteLine("remaining: {0}", remainingACharacters);
                Console.WriteLine("i: {0}", i);
                Console.WriteLine("j: {0}", j);
                if (A[i] == B[j])
                {
                    i++;
                    j++;
                    from = i;
                    to = i;
                }
                else
                {
                    i++;
                    j = 0;
                    from = 0;
                }
                //remainingACharacters -= i;
            }
            if (from == to)
            {
                from = to - B.Length + 1;
                Console.WriteLine();
                Console.WriteLine("from {0}", from);
                Console.WriteLine("to {0}", to);
                //Console.WriteLine("remaining {0}", remainingACharacters);
            }
            else
            {
                Console.WriteLine("Not found.");
            }
        }
    }
}
