using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class Gusto5thNovember2021
    {
        //. Input: { d: 13, c: 13, a: 12, b: 15 } , 50
        // Output: { d: 12, c: 13, a: 12, b: 13}

        public static IDictionary<string, int> distribute(int amount, IDictionary<string, int> limits)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();
            var sortedLimits = limits.Keys.ToList();
            if (amount % limits.Count == 0)
            {
                return limits;
            }
            int totalNeeded = 0; //48
            foreach (var x in limits)
            {
                totalNeeded += x.Value;
            }
            if (amount < totalNeeded)
            {
                int canPay = amount / limits.Count; //
                foreach (var x in limits)
                {
                    res.Add(x.Key, canPay);
                }
                return res;
            }


            sortedLimits.Sort();

            int remaining = amount;
            int minPay = int.MaxValue;
            foreach (var x in limits)
            {
                if (x.Value < minPay)
                {
                    minPay = x.Value;
                }
                //            int minPay = (amount/limits.Count()); //12
            }
            foreach (var x in limits)
            {
                res.Add(x.Key, minPay);
            }
            remaining = minPay - (limits.Count * minPay); //2

            int i = 0;
            while (i < sortedLimits.Count)
            { // a
                while (remaining > 0)
                {
                    int temp = limits[sortedLimits[i]]; //13
                    int temp2 = temp - res[sortedLimits[i]];// 1
                    res[sortedLimits[i]] += temp2;
                    remaining = remaining - temp2;
                }
                i++;
            }
            return res;
        }

        public static bool sameDictionary(IDictionary<string, int> left, IDictionary<string, int> right)
        {
            var inLeftOnly = left.Except(right);
            var inRightOnly = right.Except(left);
            return !inLeftOnly.Concat(inRightOnly).Any();
        }

        public static void GustoFunction()
        {
            // Example 1
            int amount_1 = 40;
            IDictionary<string, int> input_1 = new Dictionary<string, int>()
        {
            {"a", 10},
            {"b", 10},
            {"c", 10},
            {"d", 10}
        };
            IDictionary<string, int> expected_output_1 = new Dictionary<string, int>()
        {
            {"a", 10},
            {"b", 10},
            {"c", 10},
            {"d", 10}
        };
            bool passes_1 = sameDictionary(distribute(amount_1, input_1), expected_output_1);
            Console.WriteLine("Example 1: " + (passes_1 ? "passes" : "fails"));

            // Example 2
            int amount_2 = 100;
            IDictionary<string, int> input_2 = new Dictionary<string, int>()
        {
            {"a", 10},
            {"b", 10},
            {"c", 10},
            {"d", 10}
        };
            IDictionary<string, int> expected_output_2 = new Dictionary<string, int>()
        {
            {"a", 10},
            {"b", 10},
            {"c", 10},
            {"d", 10}
        };
            bool passes_2 = sameDictionary(distribute(amount_2, input_2), expected_output_2);
            Console.WriteLine("Example 1: " + (passes_2 ? "passes" : "fails"));

            // Example 3
            int amount_3 = 24;
            IDictionary<string, int> input_3 = new Dictionary<string, int>()
        {
            {"a", 12},
            {"b", 12},
            {"c", 12},
            {"d", 12}
        };
            IDictionary<string, int> expected_output_3 = new Dictionary<string, int>()
        {
            {"a", 6},
            {"b", 6},
            {"c", 6},
            {"d", 6}
        };
            bool passes_3 = sameDictionary(distribute(amount_3, input_3), expected_output_3);
            Console.WriteLine("Example 1: " + (passes_3 ? "passes" : "fails"));
        }
    }
}

