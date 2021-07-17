using System;

namespace DataStructuresAndAlgorithms
{
    public class FindingPrimeNumbers
    {
        public void AllPrimeNumbers()
        {
            Console.WriteLine("Enter a number for n, the size of array");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] primes = new int[n];
            bool isPrime;
            int primeIndex = 2;
            primes[0] = 2;
            primes[1] = 3;
            for (int p = 5; p <= n; p = p + 2)
            {
                isPrime = true;                
                for (int i = 0; (i <= Math.Sqrt(p) && i < primeIndex); i++)
                {
                    if (p % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes[primeIndex] = p;
                    primeIndex++;                    
                }
            }
            for (int j = 0; j < primeIndex; j++)
            {
                Console.Write(primes[j]);
                Console.Write(", ");
            }
            Console.ReadKey();
        }
    }
}
