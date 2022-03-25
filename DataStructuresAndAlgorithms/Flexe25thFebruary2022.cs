using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    class Flexe25thFebruary2022
    {
         // 3 concecutive seats available.
        public int Flight3ConsecutiveSeatsAvailable(int N, string S)
        {
            String[] sarr = S.Split(' ');
            HashSet<string> set = new HashSet<string>();
            int availbale = 0;
            int i = 0;
            while (i < sarr.Length)
            {
                set.Add(sarr[i]);
                i++;
            }

            for (i = 1; i <= N; i++)
            {
                if (!set.Contains(i + "A") && !set.Contains(i + "B") && !set.Contains(i + "C"))
                {
                    availbale++;
                }
                if (!set.Contains(i + "D") && !set.Contains(i + "E") && !set.Contains(i + "F") && !set.Contains(i + "G"))
                {
                    availbale++;
                }
                if (!set.Contains(i + "H") && !set.Contains(i + "J") && !set.Contains(i + "K"))
                {
                    availbale++;
                }
            }
            return availbale;
        }
    }
}
