using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class ChewyClass
    {
        // (sorted) List of prime numbers that are guaranteed to be less than or eq to N (below)
        private List<int> LIST_OF_PRIMES = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        // this function should return true, if there exists exactly k prime numbers that sum up to n (from LIST_OF_PRIMES)
        // sumPrime(5, 2) is true, because 2 + 3 = 5
        // sumPrime(9, 2) is true, because 2 + 7 = 9
        // sumPrime(10. 3) is true, because 2 + 3 + 5 = 10 
        // sumPrime(10. 2) is true, because 5 + 5 = 10 (or 3 + 7)
        // sumPrime(10. 10) is false
        // sumPrime(10, 1) is false
        // sumPrime(5, 5) is false, there doesnt exist 5 primes that sum up to 5


        public bool SumPrime(int target, int k, Dictionary<string, bool> map) // 10, 3, 0
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int j = 0; j < LIST_OF_PRIMES.Count; j++)
            {
                dict.Add(LIST_OF_PRIMES[j], j);
            }

            int i = 0;
            while (i < LIST_OF_PRIMES.Count)
            {
                int count = 1;
                int diff = target - LIST_OF_PRIMES[i]; //5-2
                while (dict.ContainsValue(diff) && count <= k)
                { //3
                    int z = diff - LIST_OF_PRIMES[dict[diff]];
                    diff = z;
                    if (diff == 0)
                    {
                        return true;
                    }
                    count++;
                }

                i++;
            }
            return false;

        }

        //static void Main(String[] args)
        //{

        //    Console.WriteLine(SumPrime(5, 2, new Dictionary<string, bool>()));
        //    Console.WriteLine(SumPrime(33, 3, new Dictionary<string, bool>())); // 11, 11, 11
        //    Console.WriteLine(SumPrime(33, 1, new Dictionary<string, bool>())); // false
        //    Console.WriteLine(SumPrime(10, 2, new Dictionary<string, bool>())); // true
        //    Console.WriteLine(SumPrime(10, 1, new Dictionary<string, bool>())); // false
        //    Console.WriteLine(SumPrime(4, 1, new Dictionary<string, bool>())); // false
        //}
    }
}
