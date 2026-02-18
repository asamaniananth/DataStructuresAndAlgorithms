using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class Microsoft5thNov2021
    {
        //1st question.
        public bool solution(int[] arr)
        {
            if (arr.Length % 2 != 0) return false;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int i = 0;
            while (i < arr.Length)
            {
                if (!dict.ContainsKey(arr[i]))
                {
                    dict.Add(arr[i], 1);
                }
                else
                {
                    dict[arr[i]] = dict[arr[i]] + 1;
                }
                i++;
            }
            foreach (var x in dict.Values)
            {
                if (x % 2 != 0) return false;
            }
            return true;
        }
        //2nd question

        public int[] solution(int N)
        {
            int[] arr = new int[N];
            int i = 0;
            Random rnd = new Random();
            while (i < arr.Length)
            {
                int num = rnd.Next(1, 1000);
                arr[i] = num;
                i++;
            }
            return arr;
        }

        //3rd question count minimal substrings without repeating chars.
    }
}
