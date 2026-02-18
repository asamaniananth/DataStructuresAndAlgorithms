using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace DataStructuresAndAlgorithms
{
    public class WalmartKarat
    {
        public static void Main()
        {
            string[][] badgeRecords = new string[][] {
                new string[] {"Paul", "1350"}, new string[] {"James", "830"}, new string[] {"Paul", "1315"},
                new string[] {"James", "835"}, new string[] {"Paul", "1405"}, new string[] {"Paul", "1630"},
                new string[] {"James", "855"}, new string[] {"James", "930"}, new string[] {"James", "915"},
                new string[] {"James", "730"}, new string[] {"James", "940"}, new string[] {"James", "1410"}
            };

            var result = FindFrequentAccess(badgeRecords);

            foreach (var entry in result)
            {
                Console.WriteLine($"{entry.Key}: {string.Join(", ", entry.Value)}");
            }
        }

        public static Dictionary<string, List<string>> FindFrequentAccess(string[][] records)
        {
            // 1. Group by Name and convert times to integers
            var groups = new Dictionary<string, List<int>>();
            foreach (var record in records)
            {
                string name = record[0];
                int time = int.Parse(record[1]);
                
                if (!groups.ContainsKey(name)) groups[name] = new List<int>();
                groups[name].Add(time);
            }

            var results = new Dictionary<string, List<string>>();

            // 2. Process each person
            foreach (var person in groups)
            {
                List<int> times = person.Value;
                times.Sort(); // Sorting is mandatory for the sliding window

                for (int i = 0; i < times.Count; i++)
                {
                    List<int> window = new List<int>();
                    int startTime = times[i];
                    
                    // Look forward to find all badges within 60 minutes
                    for (int j = i; j < times.Count; j++)
                    {
                        if (MinutesDifference(startTime, times[j]) <= 60)
                        {
                            window.Add(times[j]);
                        }
                        else break;
                    }

                    // 3. Check if window meets the "3 or more" criteria
                    if (window.Count >= 3)
                    {
                        results[person.Key] = window.Select(t => t.ToString()).ToList();
                        break; // Karat usually asks for the FIRST such window
                    }
                }
            }
            return results;
        }

        // Helper to handle the "Base-60" time math
        private static int MinutesDifference(int time1, int time2)
        {
            int h1 = time1 / 100, m1 = time1 % 100;
            int h2 = time2 / 100, m2 = time2 % 100;
            
            int totalMin1 = (h1 * 60) + m1;
            int totalMin2 = (h2 * 60) + m2;
            
            return totalMin2 - totalMin1;
        }

        public IList<string> SubdomainVisits(string[] cpdomains) 
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            foreach (string entry in cpdomains) {
                string[] parts = entry.Split(' ');
                int count = int.Parse(parts[0]);
                string domain = parts[1];

                string[] tokens = domain.Split('.');
                for (int i = 0; i < tokens.Length; i++) {
                    string subdomain = string.Join(".", tokens, i, tokens.Length - i);
                    if (!map.ContainsKey(subdomain)) {
                        map[subdomain] = 0;
                    }
                    map[subdomain] += count;
                }
            }

            List<string> result = new List<string>();
            foreach (var kv in map) {
                result.Add($"{kv.Value} {kv.Key}");
            }
            return result;
        }
    }
}
