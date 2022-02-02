using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace DataStructuresAndAlgorithms
{
    public class LeetCodeProblems
    {
        public int[] TwoSum(int[] nums, int target)
        {
            #region  Brute force method
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    for(int j = i + 1; j < nums.Length; j++)
            //    {
            //        int diff = target - nums[i];
            //        if (nums[j] == diff)
            //        {
            //            return new int[] { i, j };
            //        }
            //    }
            //}
            //throw new ArgumentOutOfRangeException();
            #endregion

            #region Using dictionary
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int index = 0; index < nums.Length; index++)
            {
                dic.Add(index, nums[index]);
            }
            for (int i = 0; i < nums.Length; i++)
            {
                int diff = target - nums[i];
                if (dic.ContainsValue(diff) && dic.Values.ToList().IndexOf(diff) != i)
                {
                    return new int[] { i, dic.Values.ToList().IndexOf(diff) };
                }
            }
            throw new ArgumentOutOfRangeException();
            #endregion
        }

        public int[] TwoSumII(int[] nums, int target)
        { //https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
            int start = 0, end = nums.Length - 1;

            while (start < end)
            {
                int tot = nums[start] + nums[end];
                if (tot == target)
                {
                    return new int[] { start + 1, end + 1 };
                }
                else if (tot < target)
                {
                    start++;
                }
                else
                {
                    end--;
                }
            }
            return new int[] { -1, -1 };
        }

        public IList<IList<int>> ThreeSum(int[] arr)
        { //https://leetcode.com/problems/3sum/
            //[-4,-1,-1,0,1,2]
            //[[-1,-1,2],[-1,0,1]]
            List<IList<int>> res = new List<IList<int>>();
            Array.Sort(arr);
            int i = 0;
            while (i < arr.Length && arr[i] <= 0)
            {
                if (i == 0 || arr[i - 1] != arr[i])
                {
                    int l = i + 1, r = arr.Length - 1;
                    int sum = arr[i] + arr[l] + arr[r];
                    while (l < r)
                    {
                        if (sum < 0)
                        {
                            l++;
                        }
                        else if (sum > 0)
                        {
                            r--;
                        }
                        else
                        {
                            res.Add(new List<int> { arr[i], arr[l], arr[r] });
                            l++;
                            r--;
                            while (l < r && arr[l] == arr[l - 1])
                            {
                                l++;
                            }

                        }
                    }
                }
                i++;
            }
            return res;
        }

        public int MaxSubArrayLen(int[] nums, int k) // premium problem
        { // https://leetcode.com/problems/maximum-size-subarray-sum-equals-k/
            // use prefix sum, like fibanacci
            int prefix = 0, longest = 0;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int i = 0;
            while (i < nums.Length)
            {
                prefix += nums[i];

                if (prefix == k)
                {
                    longest = i + 1;
                }

                if (dict.ContainsKey(prefix - k))
                {
                    longest = Math.Max(longest, i - dict[prefix - k]);
                }

                if (!dict.ContainsKey(prefix))
                {
                    dict.Add(prefix, i);
                }
                i++;
            }
            return longest;
        }

        public IList<int> ArraysIntersection(int[] arr1, int[] arr2, int[] arr3) // premium problem
        { //https://leetcode.com/problems/intersection-of-three-sorted-arrays/ 
            // can be done using dictionary, add element and increment value, return if element value =3
            int p = 0, q = 0, r = 0;
            List<int> res = new List<int>();

            while (p < arr1.Length && q < arr2.Length && r < arr3.Length)
            {
                if (arr1[p] == arr2[q] && arr2[q] == arr3[r])
                {
                    res.Add(arr1[p]);
                    p++;
                    q++;
                    r++;
                }
                else
                {
                    if (arr1[p] < arr2[q])
                    {
                        p++;
                    }
                    else if (arr2[q] < arr3[r])
                    {
                        q++;
                    }
                    else
                    {
                        r++;
                    }
                }
            }
            return res;
        }

        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        { // https://leetcode.com/problems/next-greater-element-i/
            Stack<int> st = new Stack<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();

            int i = 0;
            while (i < nums2.Length)
            {
                while (st.Count > 0 && nums2[i] > st.Peek())
                {
                    dict.Add(st.Pop(), nums2[i]);
                }
                st.Push(nums2[i]);
                i++;
            }

            while (st.Count != 0)
            {
                dict.Add(st.Pop(), -1);
            }

            int[] res = new int[nums1.Length];
            i = 0;
            while (i < nums1.Length)
            {
                if (dict.ContainsKey(nums1[i]))
                {
                    res[i] = dict[nums1[i]];
                }
                i++;
            }
            return res;
        }

        public int ReverseNumber(int x)
        {
            if (x < 0) return 0;
            int reverse = 0;
            while (x != 0)
            {
                int reminder = x % 10;
                x = x / 10;
                if (reverse > int.MaxValue / 10) return 0;
                //|| (reverse == int.MaxValue / 10 && reminder > 7)
                if (reverse < int.MinValue / 10) return 0;
                //|| (reverse == int.MinValue / 10 && reminder < -8)
                reverse = reverse * 10 + reminder;
            }
            return reverse;
        }

        public bool IsPowerOfFour(int n)
        { //https://leetcode.com/problems/power-of-four/
            if (n == 0) return false;
            while (n != 1)
            {
                if (n % 4 != 0)
                {
                    return false;
                }
                n = n / 4;
            }
            return true;
        }

        public int[] Intersection(int[] nums1, int[] nums2)
        { //https://leetcode.com/problems/intersection-of-two-arrays/
            HashSet<int> set1 = new HashSet<int>();
            foreach (int x in nums1)
            {
                set1.Add(x);
            }
            HashSet<int> set2 = new HashSet<int>();
            foreach (int x in nums2)
            {
                set2.Add(x);
            }
            if (nums1.Length > nums2.Length)
            {
                return IntersectionUtil(set1, set2);
            }
            else
            {
                return IntersectionUtil(set2, set1);
            }
        }
        public int[] IntersectionUtil(HashSet<int> set1, HashSet<int> set2)
        {
            List<int> res = new List<int>();
            foreach (var x in set2)
            {
                if (set1.Contains(x))
                {
                    res.Add(x);
                }
            }
            return res.ToArray();
        }

        public int Fibonacci(int n)
        {
            if (n <= 1) return n;
            int first = 0, second = 1, result = 0;
            for (int i = 2; i <= n; i++)
            {
                result = second + first;
                first = second;
                second = result;
            }
            return result;
        }

        public int[] PlusOne(int[] digits)
        { //https://leetcode.com/problems/plus-one/
            int i = digits.Length - 1;
            while (i >= 0)
            {
                if (digits[i] == 9)
                {
                    digits[i] = 0;
                }
                else
                {
                    digits[i]++;
                    return digits;
                }
                i--;
            }
            digits = new int[digits.Length + 1];
            digits[0] = 1;
            return digits;
        }

        public int SumOfAllEvenNumbersInArray(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0) sum = sum + arr[i];
            }
            return sum;
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x != 0 && x % 10 == 0)) return false;
            int reverse = 0;
            while (x > reverse)
            {
                int reminder = x % 10;
                x = x / 10;
                if (reverse > int.MaxValue / 10) return false;
                if (reverse < int.MinValue / 10) return false;
                reverse = reverse * 10 + reminder;
            }
            return (x == reverse || x == reverse / 10) ? true : false;
        }

        public int RomanToInt(string s)
        {
            int total = 0;
            Dictionary<char, int> pair = new Dictionary<char, int>
            {
                {'I',1},
                {'V',5},
                {'X',10},
                {'L',50},
                {'C',100},
                {'D',500},
                {'M',1000},
            };
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (pair[s[i]] < pair[s[i + 1]])
                {
                    total = total - pair[s[i]];
                }
                else
                {
                    total = total + pair[s[i]];
                }
            }
            return total = total + pair[s[s.Length - 1]];
        }

        public string IntToRoman(int num)
        {
            string[] I = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string[] X = new string[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] C = new string[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] M = new string[] { "", "M", "MM", "MMM", "MMMM" };
            return M[(num / 1000)] + C[(num % 1000) / 100] + X[(num % 100) / 10] + I[num % 10];
        }

        public int DaysBetweenDates(string date1, string date2)
        { // https://leetcode.com/problems/number-of-days-between-two-dates/
            //https://www.geeksforgeeks.org/find-number-of-days-between-two-given-dates/
            return Math.Abs(NumberOfDays(date1) - NumberOfDays(date2));
        }

        public int NumberOfDays(string date)
        {
            int[] daysInMonth = new int[] { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] sarr = date.Split('-');
            int y = int.Parse(sarr[0]);
            int m = int.Parse(sarr[1]);
            int d = int.Parse(sarr[2]);

            int i = 1971;
            while (i < y)
            {
                d += IsLeapYear(i) ? 366 : 365;
                i++;
            }

            i = 1;
            while (i < m) // lessthan month because we already have current month's days in d
            {
                if (i == 2 && IsLeapYear(y))
                {
                    d += 1;
                }
                d += daysInMonth[i];
                i++;
            }
            return d;
        }

        public bool IsLeapYear(int year)
        {
            // An year is a leap year if it is
            // a multiple of 4, multiple of 400
            // and not a multiple of 100.
            if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ReverseVowels(string s)
        {
            int left = 0, right = s.Length - 1;
            char[] carr = s.ToCharArray();
            while (left < right)
            {
                if (!IsVowel(s[left]))
                {
                    left++;
                    continue;
                }
                if (!IsVowel(s[right]))
                {
                    right--;
                    continue;
                }
                char temp = carr[left];
                carr[left] = carr[right];
                carr[right] = temp;
                left++;
                right--;
            }
            return new String(carr);
        }

        public bool IsVowel(char x)
        {
            if (x == 'a' || x == 'e' || x == 'i' || x == 'o' || x == 'u' || x == 'A' || x == 'E' || x == 'I' || x == 'O' || x == 'U')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BuddyStrings(string s, string t)
        { // https://leetcode.com/problems/buddy-strings/
            // https://www.geeksforgeeks.org/meta-strings-check-two-strings-can-become-swap-one-string/
            if (s.Length != t.Length) return false;
            int count = 0;
            int first = -1, second = -1;
            if (s == t)
            {
                int c = (new HashSet<char>(s)).Count;
                if (c < s.Length)
                {
                    return true;
                }
                return false;
            }
            else
            {
                int i = 0;
                while (i < s.Length)
                {
                    if (s[i] != t[i])
                    {
                        count++;
                        if (count > 2)
                        {
                            return false;
                        }
                        first = second;
                        second = i;
                    }
                    i++;
                }
            }
            return (count == 2 && s[first] == t[second] && s[second] == t[first]);
        }

        public string LongestCommonPrefix(string[] strs)
        { //https://leetcode.com/problems/longest-common-prefix/
            string longest = "";
            if (strs.Length == 0 || strs == null) return longest;
            string firstWord = strs[0];
            int j = 0;
            while (j < firstWord.Length)
            {
                for (int i = 1; i < strs.Length; i++)
                {
                    if (j >= strs[i].Length) return longest;
                    if (firstWord[j] != strs[i][j])
                        return longest;
                }
                longest = longest + firstWord[j];
                j++;
            }
            return longest;
        }

        /**
         * https://leetcode.com/problems/read-n-characters-given-read4/
         * The Read4 API is defined in the parent class Reader4.        premium question, very important
         *     int Read4(char[] buf4);
         */

        //public class Solution : Reader4
        //{
        /**
         * @param buf Destination buffer
         * @param n   Number of characters to read
         * @return    The number of actual characters read
         */

        //    public int Read(char[] buf, int n)
        //    {
        //        int copiedchars = 0, readchars = 4;
        //        char[] buf4 = new char[4];

        //        while (copiedchars < n && readchars == 4)
        //        {
        //            readchars = Read4(buf4);
        //            int i = 0;
        //            while (i < readchars)
        //            {
        //                if (copiedchars == n)
        //                {
        //                    return copiedchars;
        //                }
        //                buf[copiedchars] = buf4[i];
        //                copiedchars++;
        //                i++;
        //            }
        //        }
        //        return copiedchars;
        //    }
        //}


        public int LengthOfLongestSubstringTwoDistinct(string s)
        { //https://leetcode.com/problems/longest-substring-with-at-most-two-distinct-characters/   premium question
            // with 2 distinct character, same as fruits problem.
            int left = 0, right = 0, res = 0;

            Dictionary<char, int> dict = new Dictionary<char, int>();

            while (right < s.Length)
            {
                if (!dict.ContainsKey(s[right]))
                {
                    dict.Add(s[right], right); // add index
                }
                else
                {
                    dict[s[right]] = right; // update with last seen index
                }
                if (dict.Count > 2)
                {
                    int smallest = int.MaxValue;
                    foreach (var x in dict.Values)
                    {
                        if (x < smallest)
                        {
                            smallest = x;
                        }
                    }
                    left = smallest + 1;
                    dict.Remove(s[smallest]); // remove smallest index value
                }
                res = Math.Max(res, right - left + 1);

                right++;
            }
            return res;
        }

        public int TotalFruit(int[] f)
        {
            // Same as LengthOfLongestSubstringTwoDistinct, LengthOfLongestSubstringKDistinct
            int left = 0, right = 0, res = 0;

            Dictionary<int, int> dict = new Dictionary<int, int>();

            while (right < f.Length)
            {
                if (!dict.ContainsKey(f[right]))
                {
                    dict.Add(f[right], right);
                }
                else
                {
                    dict[f[right]] = right;
                }
                if (dict.Count > 2)
                {
                    int smallest = int.MaxValue;
                    foreach (var x in dict.Values)
                    {
                        if (x < smallest)
                        {
                            smallest = x;
                        }
                    }
                    left = smallest + 1;
                    dict.Remove(f[smallest]);
                }
                res = Math.Max(res, right - left + 1);

                right++;
            }
            return res;
        }

        public bool IsValidParentheses(string s)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case '(':
                        stack.Push(s[i]);
                        break;
                    case '[':
                        stack.Push(s[i]);
                        break;
                    case '{':
                        stack.Push(s[i]);
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(') return false;
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[') return false;
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{') return false;
                        break;
                }
            }
            return stack.Any() ? false : true;
        }

        public string Multiply(string num1, string num2)
        {
            BigInteger f = atoi(num1);
            BigInteger s = atoi(num2);
            BigInteger res = f * s;
            return res.ToString();
        }

        public BigInteger atoi(string s)
        {
            BigInteger res = 0;
            int i = 0;
            while (i < s.Length)
            {
                if (!(s[i] - '0' >= 0 && s[i] - '0' <= 9)) return res;
                //if(res > BigInteger.MaxValue/10 || (res ==BigInteger.MaxValue/10 && s[i]> BigInteger.MaxValue %10)){
                //  return BigInteger.MaxValue;
                //}
                res = res * 10 + s[i] - '0';
                i++;
            }
            return res;
        }

        public int MaxProfit(int[] prices)
        { // https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
            int lowest = int.MaxValue;
            int profit = 0;
            int i = 0;
            while (i < prices.Length)
            {
                if (prices[i] < lowest)
                {
                    lowest = prices[i];
                }
                else if (profit < (prices[i] - lowest))
                {
                    profit = prices[i] - lowest;
                }
                i++;
            }
            return profit;
        }

        public string FindReplaceString(string s, int[] indices, string[] sources, string[] targets)
        {
            // https://leetcode.com/problems/find-and-replace-in-string/

            Dictionary<int, string> sDict = new Dictionary<int, string>();
            Dictionary<int, string> tDict = new Dictionary<int, string>();

            for (int i = 0; i < indices.Length; i++)
            {
                sDict.Add(indices[i], sources[i]);
                tDict.Add(indices[i], targets[i]);
            }

            Array.Sort(indices);
            StringBuilder sb = new StringBuilder(s);

            int j = indices.Length - 1;
            while (j >= 0)
            {
                if (s.Substring(indices[j], sDict[indices[j]].Length) == sDict[indices[j]])
                {
                    sb.Remove(indices[j], sDict[indices[j]].Length);
                    sb.Insert(indices[j], tDict[indices[j]]);
                }
                j--;
            }

            return sb.ToString();
        }

        public int MinTimeToVisitAllPoints(int[][] points)
        { // https://leetcode.com/problems/minimum-time-visiting-all-points/
            int result = 0;
            int i = 1;
            while (i < points.Length)
            {
                int[] curr = points[i]; // (x2,y2)
                int[] prev = points[i - 1]; // (x1,y1)
                result += Math.Max(Math.Abs(curr[0] - prev[0]), Math.Abs(curr[1] - prev[1])); // Max((x2-x1) (y2-y1)
                i++;
            }
            return result;
        }

        // l1: 1->2->4, 
        // l2: 1->3->4
        // Output: 1->1->2->3->4->4
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode();
            ListNode result = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    result.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    result.next = l2;
                    l2 = l2.next;
                }
                result = result.next;
            }
            while (l1 != null)
            {
                result.next = l1;
                result = result.next;
                l1 = l1.next;
            }
            while (l2 != null)
            {
                result.next = l2;
                result = result.next;
                l2 = l2.next;
            }
            return dummy.next;
        }

        public IList<string> FindMissingRanges(int[] nums, int lower, int upper)
        {
            //https://leetcode.com/problems/missing-ranges/

            List<string> res = new List<string>();
            int prev = lower - 1;
            int i = 0;
            while (i <= nums.Length)
            {
                int curr = (i < nums.Length) ? nums[i] : upper + 1;
                if (prev + 1 <= curr - 1)
                {
                    res.Add(helper(prev + 1, curr - 1));
                }
                prev = curr;
                i++;
            }

            return res;
        }

        public string helper(int lower, int upper)
        {
            if (lower == upper)
            {
                return lower.ToString();
            }
            return lower.ToString() + "->" + upper.ToString();
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] result = MergeTwoSortedArrays(nums1, nums2);
            bool IsEven = (result.Length % 2 == 0) ? true : false;
            double median = 0;
            if (IsEven)
            {
                median = (double)(result[result.Length / 2] + result[(result.Length / 2) - 1]) / 2;
            }
            else
            {
                median = (double)result[result.Length / 2];
            }
            return median;
        }

        public int[] MergeTwoSortedArrays(int[] a, int[] b)
        {
            int mergedLength = a.Length + b.Length;
            int[] result = new int[mergedLength];
            int i = 0, j = 0, k = 0;
            while (i < a.Length && j < b.Length)
            {
                if (a[i] < b[j])
                {
                    result[k] = a[i];
                    i++;
                }
                else
                {
                    result[k] = b[j];
                    j++;
                }
                k++;
            }
            while (i < a.Length)
            {
                result[k] = a[i];
                i++;
                k++;
            }
            while (j < b.Length)
            {
                result[k] = b[j];
                j++;
                k++;
            }
            return result;
        }

        public int[] SortedSquares(int[] nums)
        { // https://leetcode.com/problems/squares-of-a-sorted-array/
            int left = 0, right = nums.Length - 1;
            int i = nums.Length - 1;
            int[] result = new int[nums.Length];
            while (i >= 0)
            {
                int square;
                if (Math.Abs(nums[left]) > Math.Abs(nums[right]))
                {
                    square = nums[left];
                    left++;
                }
                else
                {
                    square = nums[right];
                    right--;
                }
                result[i] = square * square;
                i--;
            }
            return result;
        }

        public string CustomSortString(string order, string s)
        { // https://leetcode.com/problems/custom-sort-string/
            int[] alpha = new int[26];
            int i = 0;
            while (i < s.Length)
            {
                alpha[s[i] - 'a']++;
                i++;
            }
            StringBuilder sb = new StringBuilder();
            i = 0;
            while (i < order.Length)
            {
                while (alpha[order[i] - 'a'] > 0)
                {
                    sb.Append(order[i]);
                    alpha[order[i] - 'a']--;
                }
                i++;
            }
            char c = 'a';
            while (c <= 'z')
            {
                while (alpha[c - 'a'] > 0)
                {
                    sb.Append(c);
                    alpha[c - 'a']--;
                }
                c++;
            }

            return sb.ToString();
        }

        public void NextPermutation(int[] nums)
        { //https://leetcode.com/problems/next-permutation/
            int i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (nums[j] <= nums[i])
                {
                    j--;
                }
                swap(nums, i, j);
            }
            reverse(nums, i + 1);
        }
        public void swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
        public void reverse(int[] a, int i)
        {
            int j = a.Length - 1;
            while (i < j)
            {
                swap(a, i, j);
                i++;
                j--;
            }
        }

        public string MostCommonWord(string para, string[] banned) // one case failed
        { //https://leetcode.com/problems/most-common-word/
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i < para.Length)
            {
                if (!char.IsPunctuation(para[i]))
                {
                    sb.Append(para[i]);
                }
                i++;
            }

            string newp = sb.ToString().ToLower();
            string[] tokens = newp.Split(' ');
            Dictionary<string, int> dict = new Dictionary<string, int>();

            i = 0;
            while (i < tokens.Length)
            {
                if (!dict.ContainsKey(tokens[i]))
                {
                    dict.Add(tokens[i], 1);
                }
                else
                {
                    dict[tokens[i]]++;
                }
                i++;
            }

            HashSet<string> set = new HashSet<string>();
            i = 0;
            while (i < banned.Length)
            {
                set.Add(banned[i]);
                i++;
            }

            string result = string.Empty;
            int max = int.MinValue;

            foreach (var kvp in dict)
            {
                if (kvp.Value > max && !set.Contains(kvp.Key))
                {
                    result = kvp.Key;
                    max = kvp.Value;
                }
            }
            return result;
        }

        public int RemoveDuplicates(int[] nums)
        { //https://leetcode.com/problems/remove-duplicates-from-sorted-array/
            int i = 0;
            int j = i + 1;
            if (nums.Length == 0) return i;
            while (i < nums.Length && j < nums.Length)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
                j++;
            }
            return i + 1;
        }

        public int RemoveElement(int[] nums, int val)
        { //https://leetcode.com/problems/remove-element/
            int length = nums.Length;
            int i = 0;
            if (nums.Length == 0 || nums == null) return 0;
            if (nums.Length == 1 && nums[i] == val) return 0;
            while (i < length)
            {
                if (nums[i] == val)
                {
                    nums[i] = nums[length - 1];
                    length--;
                }
                else
                {
                    i++;
                }
            }
            return length;
        }

        public int SearchInsert(int[] nums, int target)
        { // https://leetcode.com/problems/search-insert-position/
            int start = 0, end = nums.Length - 1;
            while (start < end)
            {
                int middle = (start + end) / 2;
                if (nums[middle] == target)
                {
                    return middle;
                }
                else if (target < nums[middle])
                {
                    end = middle;
                }
                else
                {
                    start = middle + 1;
                }
            }
            return (target == nums[start]) ? start : (target < nums[start]) ? start : start + 1;
        }

        public void RotateMatrixBy90(int[][] matrix)
        {
            TransposeOfMatrix(matrix);
            SwapElementsInMatrix(matrix);
        }

        public void TransposeOfMatrix(int[][] mat)
        {
            int rowLen = mat.Length;
            int colLen = mat[0].Length;

            for (int i = 0; i < rowLen; i++)
            {
                for (int j = i; j < colLen; j++)
                {
                    if (i != j) //Avoid diagnol, because we don't swap diagnol elements
                    {
                        int temp = mat[i][j];
                        mat[i][j] = mat[j][i];
                        mat[j][i] = temp;
                    }
                }
            }
        }

        public void SwapElementsInMatrix(int[][] mat)
        {
            int rowLen = mat.Length;
            int colLen = mat[0].Length;

            for (int i = 0; i < rowLen; i++)
            {
                for (int j = 0; j < colLen / 2; j++)
                {
                    int temp = mat[i][j];
                    mat[i][j] = mat[i][colLen - 1 - j];
                    mat[i][colLen - 1 - j] = temp;
                }
            }
        }

        public void SetZeroes(int[][] matrix)
        { //https://leetcode.com/problems/set-matrix-zeroes/solution/   wrong solution
            int rowlen = matrix.Length;
            int collen = matrix[0].Length;
            bool rowflag = false;
            bool colflag = false;
            //1) Scan the first row and set a variable rowFlag to indicate whether 
            //   we need to set all 1s in first row or not. 
            // 2) Scan the first column and set a variable colFlag to indicate whether 
            //      we need to set all 1s in first column or not. 
            for (int i = 0; i < rowlen; i++)
            {
                for (int j = 0; j < collen; j++)
                {
                    if (i == 0 && matrix[i][j] == 0)
                    {
                        rowflag = true;
                    }
                    if (j == 0 && matrix[i][j] == 0)
                    {
                        colflag = true;
                    }
                }
            }

            //3) Use first row and first column as the auxiliary arrays row[] and col[]             
            //   respectively, consider the matrix as submatrix starting from second row and second column and apply method 1. 
            for (int i = 1; i < rowlen; i++)
            {
                for (int j = 1; j < collen; j++)
                {
                    if (matrix[0][j] == 0 || matrix[i][0] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
            // 4) Finally, using rowFlag and colFlag, update first row and first column if needed.
            if (rowflag == true)
            {
                for (int j = 0; j < collen; j++)
                {
                    matrix[0][j] = 0;
                }
            }

            if (colflag == true)
            {
                for (int i = 0; i < rowlen; i++)
                {
                    matrix[i][0] = 0;
                }
            }
        }

        public string SimplifyPath2(string s) // Doesn't cover all the edge cases, see next solution.
        {
            string[] carr = s.Split('/');
            StringBuilder sb = new StringBuilder();
            if (carr.Length == 1)
            {
                sb.Insert(0, carr[0]);
                sb.Insert(0, "/");
            }

            int i = carr.Length - 1;
            while (i >= 0)
            {
                int count = 0;
                if (carr[i] == "..")
                {
                    while (carr[i] == "..")
                    {
                        i--;
                        count++;
                    }
                    while (count > 0)
                    {
                        if (carr[i] == ".")
                        {
                            i--;
                            continue;
                        }
                        else
                        {
                            i--;
                            count--;
                        }
                    }
                }
                else if (carr[i] == "." || carr[i] == "")
                {
                    i--;
                }
                else
                {
                    if (i == 0)
                    {
                        sb.Insert(0, carr[i]);
                    }
                    else
                    {
                        sb.Insert(0, carr[i]);
                        sb.Insert(0, "/");
                    }
                    i--;
                }
            }
            return sb.ToString().Length == 0 ? "/" : sb.ToString();
        }

        public string SimplifyPath(string s)
        { //https://leetcode.com/problems/simplify-path/
            Stack<string> st = new Stack<string>();
            string[] sarr = s.Split('/');

            int i = 0;
            while (i < sarr.Length)
            {
                if (sarr[i] == "." || sarr[i] == "")
                {
                    i++;
                    continue;
                }
                else if (sarr[i] == "..")
                {
                    if (st.Count > 0)
                    {
                        st.Pop();
                    }
                }
                else
                {
                    st.Push(sarr[i]);
                }
                i++;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var x in st)
            {
                sb.Insert(0, x);
                sb.Insert(0, "/");
            }
            return (sb.ToString().Length == 0) ? "/" : sb.ToString();
        }

        public List<char> PrintFromCharToZ(char c)
        {
            List<char> res = new List<char>();
            int cValue = (int)c; //98
            int aDiffValue = cValue - 'a'; //98-97 =1
            int zValue = cValue + 25 - aDiffValue; //98+25-1
            int i = cValue;
            while (i <= zValue)
            {
                res.Add((char)i);
                i++;
            }
            return res; // will print b-z inclusive
        }

        public class ListNodeForCycle
        {
            public int val;
            public ListNodeForCycle next;
            public ListNodeForCycle(int x)
            {
                val = x;
                next = null;
            }
        }

        public bool HasCycle(ListNodeForCycle head)
        {
            if (head == null) return false;
            ListNodeForCycle move2steps = head;
            ListNodeForCycle move1step = head;
            while (move2steps != null && move2steps.next != null)
            {
                move2steps = move2steps.next.next;
                move1step = move1step.next;
                if (move2steps == move1step) return true;
            }
            return false;
        }

        public ListNodeForCycle DetectCycle(ListNodeForCycle head)
        {
            if (head == null) return null;
            ListNodeForCycle move2steps = head;
            ListNodeForCycle move1step = head;
            while (move2steps != null && move2steps.next != null)
            {
                move2steps = move2steps.next.next;
                move1step = move1step.next;
                if (move2steps == move1step) break;
            }
            if (move2steps == null || move1step == null) return null;
            move1step = head;
            while (move1step != move2steps)
            {
                move1step = move1step.next;
                move2steps = move2steps.next;
            }
            return move1step;
        }

        public ListNode RemoveElementFromLinkedList(ListNode head, int n)
        {
            if (head.val == n)
            {
                head = head.next;
            }
            else
            {
                ListNode prev = null;
                ListNode curr = head;
                while (curr != null)
                {
                    prev = curr;
                    curr = curr.next;
                    if (curr.val == n)
                    {
                        prev.next = curr.next;
                        return head;
                    }
                }
            }
            return head;
        }

        public int MajorityElementInArray(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            int half = nums.Length / 2;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dic.ContainsKey(nums[i])) dic.Add(nums[i], 1);
                else dic[nums[i]] = dic[nums[i]] + 1;
                if (dic[nums[i]] > half) return nums[i];
            }
            return -1;
        }

        public bool IsHappy(int n)
        {
            HashSet<int> set = new HashSet<int>();
            if (n < 0) return false;
            while (n != 1)
            {
                if (set.Contains(n)) return false;
                set.Add(n);
                n = SumOfSquare(n);
            }
            return n == 1 ? true : false;
        }

        public int SumOfSquare(int n)
        {
            int sum = 0;
            while (n != 0)
            {
                int rem = n % 10;
                int sq = rem * rem;
                sum = sum + sq;
                n = n / 10;
            }
            return sum;
        }

        public int CountPrimes(int n)
        {
            int[] primes = new int[n];
            if (n <= 2) return 0;
            if (n == 3) return 1;
            primes[0] = 2;
            primes[1] = 3;
            int primeIndex = 2;
            bool isPrime;
            for (int p = 5; p < n; p = p + 2)
            {
                isPrime = true;
                for (int i = 0; i < Math.Sqrt(p) && i < primeIndex; i++)
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
            return primeIndex;
        }

        public bool IsAnagram(string s, string t)
        { //https://leetcode.com/problems/valid-anagram/
            if (s.Length != t.Length) return false;
            Dictionary<char, int> letterCount = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!letterCount.ContainsKey(s[i]))
                {
                    letterCount.Add(s[i], 1);
                }
                else
                {
                    letterCount[s[i]] = letterCount[s[i]] + 1;
                }
            }
            for (int j = 0; j < t.Length; j++)
            {
                if (!letterCount.ContainsKey(t[j])) return false;
                else
                {
                    letterCount[t[j]] = letterCount[t[j]] - 1;
                    if (letterCount[t[j]] < 0) return false;
                }

            }
            return true;
        }

        public class NumArray
        { // https://leetcode.com/problems/range-sum-query-immutable/
            List<int> list = new List<int>();
            public NumArray(int[] nums)
            {
                int i = 0;
                while (i < nums.Length)
                {
                    list.Add(nums[i]);
                    i++;
                }
            }

            public int SumRange(int left, int right)
            {
                int result = 0;
                while (left <= right && left < list.Count)
                {
                    result += list[left];
                    left++;
                }
                return result;
            }
        }

        public int GetSum(int a, int b)
        {
            int carry;
            while (b != 0)
            {
                carry = a & b;
                a = a ^ b;
                b = carry << 1;
            }
            return a;
        }

        public int[] MergeSortedArrays(int[] nums1, int m, int[] nums2, int n)
        {
            int k = m - 1, l = n - 1, p = m + n - 1;
            while (k >= 0 && l >= 0)
            {
                if (nums1[k] >= nums2[l] && p >= 0)
                {
                    nums1[p] = nums1[k];
                    k--;
                }
                else
                {
                    nums1[p] = nums2[l];
                    l--;
                }
                p--;
            }
            while (k >= 0 && p >= 0)
            {
                nums1[p] = nums1[k];
                k--;
                p--;
            }
            while (l >= 0 && p >= 0)
            {
                nums1[p] = nums2[l];
                l--;
                p--;
            }
            return nums1;
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0) return null;

            TreeNode headNode = BuildBST(nums, 0, nums.Length - 1);
            return headNode;
        }

        public TreeNode BuildBST(int[] nums, int start, int end)
        {
            if (start > end) return null;
            int mid = ((start + end) + 1) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = BuildBST(nums, start, mid - 1);
            root.right = BuildBST(nums, mid + 1, end);
            return root;
        }

        public int ClosestValue(TreeNode root, double target)
        { //https://leetcode.com/problems/closest-binary-search-tree-value/     premium question
            int temp = root.val, closest = root.val;
            while (root != null)
            {
                temp = root.val;
                closest = Math.Abs(temp - target) < Math.Abs(closest - target) ? temp : closest;

                if (target > root.val)
                {
                    root = root.right;
                }
                else
                {
                    root = root.left;
                }
            }
            return closest;
        }

        public void RotateArray(int[] nums, int k)
        { //https://leetcode.com/problems/rotate-array/
            k = k % nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k);
            Reverse(nums, k + 1, nums.Length - 1);
        }

        public void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        public bool IsIsomorphic(string s, string t)
        {
            //s = "egg", t = "add" ans true
            //s = "foo", t = "bar" ans false
            if (s.Length != t.Length) return false;
            for (int i = 0; i < s.Length; ++i)
            {
                if (s.IndexOf(s[i], 0, i) != t.IndexOf(t[i], 0, i))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsStrobogrammatic(string num)
        { //https://leetcode.com/problems/strobogrammatic-number/
            Dictionary<char, char> dict = new Dictionary<char, char>{
                                                                        {'0','0'},
                                                                        {'1','1'},
                                                                        {'6','9'},
                                                                        {'8','8'},
                                                                        {'9','6'}
                                                                    };

            StringBuilder sb = new StringBuilder();
            int i = num.Length - 1;
            while (i >= 0)
            {
                if (!dict.ContainsKey(num[i]))
                {
                    return false;
                }
                sb.Append(dict[num[i]]);

                i--;
            }
            return num.Equals(sb.ToString());
        }

        public TreeNode InvertTree(TreeNode root)
        {
            //https://leetcode.com/problems/invert-binary-tree/

            if (root == null) return null;
            TreeNode left = root.left;
            root.left = InvertTree(root.right);
            root.right = InvertTree(left);
            return root;
        }

        public int FirstUniqChar(string s)
        { //https://leetcode.com/problems/first-unique-character-in-a-string/
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int i = 0;
            while (i < s.Length)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    dict.Add(s[i], 1);
                }
                else
                {
                    dict[s[i]]++;
                }
                i++;
            }
            i = 0;
            while (i < s.Length)
            {
                if (dict[s[i]] == 1)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public IList<int> FindDisappearedNumbersInArray(int[] nums)
        {
            //https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
            for (int i = 0; i < nums.Length; i++)
            {
                int j = Math.Abs(nums[i]) - 1;
                nums[j] = Math.Abs(nums[j]) * -1;
            }
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    result.Add(i + 1);
                }
            }
            return result;
        }

        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            return s != null && (IsSubtreeEqual(s, t) || IsSubtree(s.left, t) || IsSubtree(s.right, t));
        }

        public bool IsSubtreeEqual(TreeNode x, TreeNode y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return x.val == y.val && IsSubtreeEqual(x.left, y.left) && IsSubtreeEqual(x.right, y.right);
        }

        public string ReverseWords(string s)
        {
            StringBuilder sb = new StringBuilder();
            string[] sarr = s.Split(' ');
            foreach (string x in sarr)
            {
                sb.Append(reverseString(x));
                sb.Append(" ");
            }
            return sb.ToString().Trim();
        }

        public string reverseString(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }
            return sb.ToString();
        }

        public int StrStr(string s, string t)
        { //https://leetcode.com/problems/implement-strstr/
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(t)) return 0;

            if (s.Contains(t))
            {
                return s.IndexOf(t);
            }
            else return -1;
        }

        public int CompareVersion(string s, string t)
        { // https://leetcode.com/problems/compare-version-numbers/
            string[] sarr = s.Split('.');
            string[] tarr = t.Split('.');
            int n1 = sarr.Length;
            int n2 = tarr.Length;

            int i = 0;
            while (i < Math.Max(n1, n2))
            {
                int v1 = i < n1 ? int.Parse(sarr[i]) : 0;
                int v2 = i < n2 ? int.Parse(tarr[i]) : 0;
                if (v1 != v2)
                {
                    return v1 > v2 ? 1 : -1;
                }
                i++;
            }
            return 0;
        }

        public int[] ProductExceptSelf(int[] nums)
        {//https://leetcode.com/problems/product-of-array-except-self/
            int l = nums.Length;
            int[] res = new int[l];
            res[0] = 1;
            int i = 1;
            while (i < l)
            {
                res[i] = res[i - 1] * nums[i - 1];
                i++;
            }

            int r = 1;
            i = l - 1;
            while (i >= 0)
            {
                res[i] = res[i] * r;
                r = r * nums[i];
                i--;
            }
            return res;
        }

        public void ReverseWords(char[] s)
        { //https://leetcode.com/problems/reverse-words-in-a-string-ii/ - premium question
            //s = ["t","h","e"," ","s","k","y"," ","i","s"," ","b","l","u","e"]
            //s = ["e","u","l","b"," ","s","i"," ","y","k","s"," ","e","h","t"]
            int right = s.Length - 1, left = 0;
            ReverseWordhelper(s, left, right);
            left = 0;
            right = 0;
            while (left < s.Length)
            {
                while (right < s.Length && s[right] != ' ')
                {
                    right++;
                }
                ReverseWordhelper(s, left, right - 1);
                left = right + 1;
                right = right + 1;
            }

        }
        public void ReverseWordhelper(char[] s, int left, int right)
        {
            while (left <= right)
            {
                char temp = s[right];
                s[right] = s[left];
                s[left] = temp;
                left++;
                right--;
            }
        }

        public IList<int> Preorder(Node root)
        {
            List<int> result = new List<int>();
            if (root == null) return result;
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            Node temp;
            while (stack.Count > 0)
            {
                temp = stack.Pop();
                result.Add(temp.val);
                for (int i = temp.children.Count - 1; i >= 0; i--)
                {
                    stack.Push(temp.children[i]);
                }
            }
            return result;
        }

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int i = 0, count = 0;
            while (i < flowerbed.Length)
            {
                if (flowerbed[i] == 0)
                {
                    int next = (i == flowerbed.Length - 1) ? 0 : flowerbed[i + 1];
                    int prev = (i == 0) ? 0 : flowerbed[i - 1];
                    if (next == 0 && prev == 0)
                    {
                        flowerbed[i] = 1;
                        count++;
                    }
                }
                if (count >= n)
                {
                    return true;
                }
                i++;
            }
            return false;
        }

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null) return t2;
            if (t2 == null) return t1;
            t1.val = t1.val + t2.val;
            t1.left = MergeTrees(t1.left, t2.left);
            t1.right = MergeTrees(t1.right, t2.right);
            return t1;
        }

        public bool CheckPossibilityToMakeNonDecreasingArrayByChangingOneElement(int[] nums)
        { //https://leetcode.com/problems/non-decreasing-array/ //4,2,1 | 4,2,3
            int count = 0, i = 0;
            while (i < nums.Length - 1)
            {
                if (nums[i] > nums[i + 1])
                {
                    if (i > 0)
                    {
                        if (nums[i - 1] <= nums[i + 1]) nums[i] = nums[i - 1];
                        else nums[i + 1] = nums[i];
                    }
                    count++;
                    if (count > 1) return false;
                }
                i++;
            }
            return true;
        }

        public TreeNode TrimBST(TreeNode root, int low, int high)
        { //https://leetcode.com/problems/trim-a-binary-search-tree/
            if (root == null) return root;
            if (root.val > high) return TrimBST(root.left, low, high);
            if (root.val < low) return TrimBST(root.right, low, high);
            root.left = TrimBST(root.left, low, high);
            root.right = TrimBST(root.right, low, high);
            return root;
        }

        public int FindLengthOfLCIS(int[] nums)
        {
            // https://leetcode.com/problems/longest-increasing-subsequence/    wrong answer
            if (nums.Length == 0) return 0;
            int diff = 1, i = 1, length = 1;
            while (i < nums.Length)
            {
                if (nums[i - 1] < nums[i]) { length++; diff = Math.Max(diff, length); }
                else length = 1;
                i++;
            }
            return diff;
        }

        public int PeakIndexInMountainArray(int[] arr)
        { //https://leetcode.com/problems/peak-index-in-a-mountain-array/
            return FindPeak(arr, 0, arr.Length - 1);
        }

        public int FindPeak(int[] A, int start, int end)
        {
            //0,1,2,3
            //3,4,5,1
            int mid = start + (end - start) / 2;
            int prev = mid - 1;
            int next = mid + 1;
            if (A[prev] < A[mid] && A[mid] > A[next]) return mid;
            else if (A[prev] > A[mid]) return FindPeak(A, start, mid);
            else return FindPeak(A, mid + 1, end);
        }

        public int CountCharacters(string[] words, string chars)
        { //https://leetcode.com/problems/find-words-that-can-be-formed-by-characters/
            int charsLength = chars.Length;
            int result = 0;
            Dictionary<char, int> dictChar = new Dictionary<char, int>();
            for (int i = 0; i < chars.Length; i++)
            {
                if (dictChar.ContainsKey(chars[i]))
                {
                    dictChar[chars[i]]++;
                }
                else dictChar.Add(chars[i], 1);
            }
            for (int j = 0; j < words.Length; j++)
            {
                string temp = words[j];
                if (temp.Length > charsLength) continue;
                else
                {
                    Dictionary<char, int> dictTemp = new Dictionary<char, int>();
                    for (int z = 0; z < temp.Length; z++)
                    {
                        if (dictTemp.ContainsKey(temp[z]))
                        {
                            dictTemp[temp[z]]++;
                        }
                        else dictTemp.Add(temp[z], 1);
                    }
                    for (int y = 0; y < temp.Length; y++)
                    {
                        if (dictChar.ContainsKey(temp[y]))
                        {
                            if (dictChar[temp[y]] < dictTemp[temp[y]]) break;
                            if (y == temp.Length - 1) { result += temp.Length; dictTemp.Clear(); }
                        }
                        else break;
                    }
                }
            }
            return result;
        }

        public string GetHint(string secret, string guess)
        { //https://leetcode.com/problems/bulls-and-cows/
            if (secret.Length != guess.Length) return "0A0B";
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int i = 0;
            while (i < secret.Length)
            {
                if (!dict.ContainsKey(secret[i]))
                {
                    dict.Add(secret[i], 1);
                }
                else
                {
                    dict[secret[i]]++;
                }
                i++;
            }

            i = 0;
            int j = 0, bulls = 0, cows = 0;
            while (i < secret.Length && j < guess.Length)
            {
                if (dict.ContainsKey(guess[j]))
                {
                    if (guess[j] == secret[i])
                    {
                        bulls++;
                        if (dict[guess[j]] <= 0)
                        {
                            cows--;
                        }
                    }
                    else
                    {
                        if (dict[guess[j]] > 0)
                        {
                            cows++;
                        }
                    }
                    dict[guess[j]]--;
                }

                i++;
                j++;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(bulls + "A" + cows + "B");
            return sb.ToString();
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        { //https://leetcode.com/problems/add-two-numbers/
            BigInteger l1Sum = 0;
            BigInteger l2Sum = 0;
            BigInteger placeVal = 1;
            while (l1 != null || l2 != null)
            {
                l1Sum = l1 != null ? (l1.val * placeVal) + l1Sum : l1Sum;
                l2Sum = l2 != null ? (l2.val * placeVal) + l2Sum : l2Sum;
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
                placeVal *= 10;
            }
            l1Sum += l2Sum;
            if (l1Sum == 0) return new ListNode((int)l1Sum);
            ListNode dummy = new ListNode();
            ListNode result = dummy;
            while (l1Sum != 0)
            {
                BigInteger reminder = l1Sum % 10;
                result.next = new ListNode((int)reminder);
                result = result.next;
                l1Sum = l1Sum / 10;
            }
            return dummy.next;
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        { //https://leetcode.com/problems/remove-nth-node-from-end-of-list/
            //https://www.geeksforgeeks.org/delete-nth-node-from-the-end-of-the-given-linked-list/
            ListNode first = head;
            ListNode second = head;
            int i = 0;
            while (i < n)
            {
                if (second.next == null)
                {
                    if (i == n - 1)
                    {
                        head = head.next;
                        return head;
                    }
                }

                second = second.next;
                i++;
            }

            while (second.next != null)
            {
                second = second.next;
                first = first.next;
            }
            first.next = first.next.next;
            return head;
        }

        public ListNode ReverseList(ListNode head)
        { //https://leetcode.com/problems/reverse-linked-list/
            ListNode prev = null, curr = head, next = null;
            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
            return prev;
        }

        public ListNode MiddleNode(ListNode head)
        { //https://leetcode.com/problems/middle-of-the-linked-list/
            ListNode slow = head, fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

        public void ReorderList(ListNode head)
        { //https://leetcode.com/problems/reorder-list/
            ListNode slow = head, fast = head;
            //Middle node
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            // slow is middle node
            // reverse middle to last, including
            ListNode prev = null, curr = slow, next;
            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            // prev is the second portion head now
            ListNode first = head, second = prev;
            while (second.next != null)
            {
                next = first.next;
                first.next = second;
                first = next;

                next = second.next;
                second.next = first;
                second = next;
            }
        }

        public ListNode MergeKLists(ListNode[] lists)
        { //https://leetcode.com/problems/merge-k-sorted-lists/
            if (lists.Length == 0) return null;
            if (lists.Length < 2) return lists[0];
            ListNode temp = new ListNode();
            temp = Merge2Lists(lists[0], lists[1]);

            int i = 2;
            while (i < lists.Length)
            {
                temp = Merge2Lists(temp, lists[i]);
                i++;
            }

            return temp;
        }

        public ListNode Merge2Lists(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode();
            ListNode result = dummy;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    result.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    result.next = l2;
                    l2 = l2.next;
                }
                result = result.next;
            }
            while (l1 != null)
            {
                result.next = l1;
                l1 = l1.next;
                result = result.next;
            }
            while (l2 != null)
            {
                result.next = l2;
                l2 = l2.next;
                result = result.next;
            }
            return dummy.next;
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB) // Common ancestor problem.
        { //https://leetcode.com/problems/intersection-of-two-linked-lists/
            ListNode pA = headA;
            ListNode pB = headB;
            while (pA != pB)
            {
                pA = pA == null ? headB : pA.next;
                pB = pB == null ? headA : pB.next;
            }
            return pB;
        }

        public int LengthOfLongestSubstring(string s)
        { //https://leetcode.com/problems/longest-substring-without-repeating-characters/
            int right = 0, left = 0, maxLen = 0;
            HashSet<char> set = new HashSet<char>();
            while (right < s.Length)
            {
                if (!set.Contains(s[right]))
                {
                    set.Add(s[right]);
                    maxLen = Math.Max(maxLen, set.Count);
                    right++;
                }
                else
                {
                    set.Remove(s[left]);
                    left++;
                }
            }
            return maxLen;
        }

        public string LongestPalindrome(string s)
        {
            return ManachersAlgorithm(s);
        }

        public string ManachersAlgorithm(string s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("$");
            foreach (char x in s)
            {
                sb.Append("#");
                sb.Append(x);
            }
            sb.Append("#");
            sb.Append("@");
            string T = sb.ToString();

            int[] lps = new int[T.Length];
            int c = 0, r = 0;
            for (int i = 1; i < T.Length - 1; i++)
            {
                int mirror = 2 * c - i;

                // is i lies within the boundary?
                if (i < r) // is i lessthan the main boundary?
                    lps[i] = Math.Min(r - i, lps[mirror]); // copy the mirror value to lps

                // expand and check
                while (T[i + (1 + lps[i])] == T[i - (1 + lps[i])]) // compare the values.
                    lps[i]++;

                // Does it expand beyond R right boundary?
                if (i + lps[i] > r) // is new pali boundary greater than old boundary?
                {
                    c = i; // make old center to new pali center.
                    r = i + lps[i]; // this is the boundary of new pali.
                }
            }
            int length = 0;
            c = 0;
            for (int i = 1; i < lps.Length - 1; i++)
            {
                if (lps[i] > length)
                {
                    length = lps[i];
                    c = i;
                }
            }
            return s.Substring((c - 1 - length) / 2, length);
        }

        public int MaxSubArray(int[] a)
        { //https://leetcode.com/problems/maximum-subarray/
            //[-2,1,-3,4,-1,2,1,-5,4], ans: 6
            int tempMax = a[0], actualMax = a[0], i = 1;
            while (i < a.Length)
            {
                tempMax = Math.Max(a[i], tempMax + a[i]);
                if (tempMax > actualMax)
                {
                    actualMax = tempMax;
                }
                i++;
            }
            return actualMax;
        }

        public int MaxProduct(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int maxsofar = nums[0], minsofar = nums[0];
            int result = maxsofar;
            int i = 1;
            while (i < nums.Length)
            {
                int curr = nums[i];
                int temp = Math.Max(curr, Math.Max(curr * maxsofar, curr * minsofar));
                minsofar = Math.Min(curr, Math.Min(curr * maxsofar, curr * minsofar));

                maxsofar = temp;
                result = Math.Max(maxsofar, result);
                i++;
            }
            return result;
        }

        public string Convert2(string s, int numRows)
        { //https://leetcode.com/problems/zigzag-conversion/
            if (numRows == 1) return s;
            int i = 0, k = 2 * numRows - 2;
            StringBuilder sb = new StringBuilder();
            while (i < numRows)
            {
                int j = 0;
                while (j + i < s.Length)
                {
                    sb.Append(s[i + j]);
                    if (i != 0 && i != numRows - 1 && j + k - i < s.Length)
                        sb.Append(s[j + k - i]);
                    j += k;
                }
                i++;
            }
            return sb.ToString();
        }

        public int MyAtoi(string s)
        { //https://leetcode.com/problems/string-to-integer-atoi/
            int sign = 1, i = 0, result = 0;
            if (s.Length == 0) return result;
            s = s.Trim(' ');
            while (i < s.Length)
            {
                if (i == 0 && (s[i] == '-' || s[i] == '+'))
                {
                    sign = (s[i] == '-') ? -1 : 1;
                    i++;
                    continue;
                }
                if (!((s[i] - '0') >= 0 && (s[i] - '0') <= 9)) return result * sign;
                if (s[i] == ' ') return result * sign;
                if ((s[i] - '0') >= 0 && (s[i] - '0') <= 9)
                {
                    if (result == 0) result = s[i] - '0';
                    else
                    {
                        if ((result > int.MaxValue / 10) || (result == int.MaxValue / 10 && s[i] - '0' > int.MaxValue % 10))
                        {
                            return (sign == 1) ? int.MaxValue : int.MinValue;
                        }
                        result = result * 10 + s[i] - '0';
                    }
                }
                i++;
            }
            return result * sign;
        }

        public int MyAtoi2(string s) // Not efficient solution.
        {
            if (String.IsNullOrWhiteSpace(s)) return 0;
            if (s.Length == 0)
            {
                return 0;
            }
            int i = 0;
            while (s[i] == ' ')
            {
                i++;
            }
            int sign = 1;
            if (s[i] == '-' || s[i] == '+')
            {
                if (s[i] == '-') sign = -1;
                i++;
            }

            int result = 0;
            while (i < s.Length)
            {
                if (!(s[i] - '0' >= 0 && s[i] - '0' <= 9)) return result * sign;
                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && s[i] - '0' > int.MaxValue % 10))
                {
                    if (sign == 1)
                    {
                        return int.MaxValue;
                    }
                    return int.MinValue;
                }
                result = result * 10 + (s[i] - '0');
                i++;
            }
            return result * sign;
        }

        public int MaxAreaContainerWithMostWater(int[] A)
        { //https://leetcode.com/problems/container-with-most-water/
            //https://www.youtube.com/watch?v=4GIIy1o-3DM&ab_channel=jayatitiwari
            int i = 0, j = A.Length - 1, area = 0;
            while (i < j)
            {
                area = Math.Max(area, ((j - i) * Math.Min(A[i], A[j])));
                if (A[i] < A[j]) i++;
                else j--;
            }
            return area;
        }

        public IList<string> LetterCombinations(string digits)
        { //https://leetcode.com/problems/letter-combinations-of-a-phone-number/
            List<string> temp = new List<string>(); // ex: digits= "234"
            if (digits.Length == 0) return temp;
            Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>
            {
                {2, new List<string>{ "a","b","c"} },
                {3,new List<string>{ "d","e","f"}},
                {4,new List<string>{ "g","h","i"}},
                {5,new List<string>{ "j","k","l"}},
                {6,new List<string>{ "m","n","o"}},
                {7,new List<string>{ "p","q","r","s"}},
                {8,new List<string>{ "t","u","v"}},
                {9,new List<string>{ "w","x","y","z"}}
            };
            if (digits.Length == 1) return dict[digits[0] - '0'];
            int i = digits.Length - 2;
            while (i >= 0)
            {
                if (i == (digits.Length - 2)) temp = CartesianProductOfTwoStrings(dict[digits[i] - '0'], dict[digits[i + 1] - '0']);
                else temp = CartesianProductOfTwoStrings(dict[digits[i] - '0'], temp);
                i--;
            }
            return temp;
        }

        public List<string> CartesianProductOfTwoStrings(List<string> x, List<string> y)
        {
            List<string> cart = new List<string>();
            int i = 0;
            while (i < x.Count)
            {
                int j = 0;
                while (j < y.Count)
                {
                    cart.Add(x[i] + y[j]);
                    j++;
                }
                i++;
            }
            return cart;
        }

        public void _printParenthesis(char[] str, int count, int n, int left, int right, List<string> result)
        {
            if (right == n)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < str.Length; i++)
                    sb.Append(str[i]);
                result.Add(sb.ToString());
                return;
            }
            else
            {
                if (left > right)
                {
                    str[count] = '}';
                    _printParenthesis(str, count + 1, n, left, right + 1, result);
                }
                if (left < n)
                {
                    str[count] = '{';
                    _printParenthesis(str, count + 1, n, left + 1, right, result);
                }
            }
        }

        public List<string> printParenthesis(char[] str, int n)
        { //https://leetcode.com/problems/generate-parentheses/
            List<string> result = new List<string>();
            if (n > 0)
                _printParenthesis(str, 0, n, 0, 0, result);
            return result;
        }

        public string ValidIPAddress(string ip)
        {
            string[] v4 = ip.Split('.');
            string[] v6 = ip.Split(':');
            if (v4.Length != 4 && v6.Length != 8)
            {
                return "Neither";
            }
            if (v4.Length == 4)
            {
                return checkv4Validity(v4);
            }
            else if (v6.Length == 8)
            {
                return checkv6Validity(v6);
            }
            else
            {
                return "Neither";
            }
        }

        public string checkv4Validity(string[] v4)
        {
            foreach (string x in v4)
            {
                if (String.IsNullOrWhiteSpace(x) || x.Length == 0 || x.Length > 3) return "Neither";
                if (x[0] == '0' && x.Length != 1) return "Neither";
                try
                {
                    int temp = int.Parse(x);
                    if (temp < 0 || temp > 255) return "Neither";
                }
                catch (Exception)
                {
                    return "Neither";
                }
            }
            return "IPv4";
        }

        public string checkv6Validity(string[] v6)
        {
            foreach (string x in v6)
            {
                if (String.IsNullOrWhiteSpace(x) || x.Length == 0 || x.Length > 4) return "Neither";
                try
                {
                    int temp = Convert.ToInt32(x, 16);
                }
                catch (Exception)
                {
                    return "Neither";
                }
            }
            return "IPv6";
        }

        public int Search(int[] nums, int target)
        { //https://leetcode.com/problems/search-in-rotated-sorted-array/
            if ((nums.Length == 1) && (nums[0] == target)) return 0;
            int rotatedAt = FindRotatedAt(nums, 0, nums.Length - 1);
            if (rotatedAt == -1) return BinarySearchIn(nums, 0, nums.Length - 1, target);
            if (target == nums[rotatedAt]) return rotatedAt;
            if (target >= nums[0]) return BinarySearchIn(nums, 0, rotatedAt - 1, target);
            return BinarySearchIn(nums, rotatedAt + 1, nums.Length - 1, target);
        }

        public int FindRotatedAt(int[] arr, int low, int high)
        {
            if (high < low)
                return -1;
            if (high == low)
                return low;

            int mid = (low + high) / 2;

            if (mid < high && arr[mid] > arr[mid + 1])
                return mid;

            if (mid > low && arr[mid] < arr[mid - 1])
                return (mid - 1);

            if (arr[low] >= arr[mid])
                return FindRotatedAt(arr, low, mid - 1);

            return FindRotatedAt(arr, mid + 1, high);
        }

        public int BinarySearchIn(int[] A, int start, int end, int target)
        {
            if (start > end) return -1;
            int mid = (start + end) / 2;
            if (target == A[mid]) return mid;
            if (target > A[mid]) return BinarySearchIn(A, mid + 1, end, target);
            return BinarySearchIn(A, start, mid - 1, target);
        }

        public int Search1(int[] nums, int target)
        {
            return pivotedBinarySearch(nums, nums.Length, target);
        }

        public int pivotedBinarySearch(int[] arr, int n, int key)
        {
            int pivot = findPivot(arr, 0, n - 1);
            if (pivot == -1)
                return binarySearch(arr, 0, n - 1, key);
            if (arr[pivot] == key)
                return pivot;
            if (arr[0] <= key)
                return binarySearch(arr, 0, pivot - 1, key);
            return binarySearch(arr, pivot + 1, n - 1, key);
        }

        public int findPivot(int[] arr, int low, int high)
        {
            if (high < low)
                return -1;
            if (high == low)
                return low;

            int mid = (low + high) / 2;

            if (mid < high && arr[mid] > arr[mid + 1])
                return mid;

            if (mid > low && arr[mid] < arr[mid - 1])
                return (mid - 1);

            if (arr[low] >= arr[mid])
                return findPivot(arr, low, mid - 1);

            return findPivot(arr, mid + 1, high);
        }

        public int binarySearch(int[] arr, int low, int high, int key)
        {
            if (high < low)
                return -1;

            int mid = (low + high) / 2;

            if (key == arr[mid])
                return mid;
            if (key > arr[mid])
                return binarySearch(arr, (mid + 1), high, key);

            return binarySearch(arr, low, (mid - 1), key);
        }

        public int[] SearchRange(int[] nums, int target)
        { //https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
            int[] result = new int[] { -1, -1 };
            if (nums.Length == 0 && target == 0) return result;
            SeearchRangeUsingBinarySearch(nums, 0, nums.Length - 1, target, result);
            return result;
        }

        public int[] SeearchRangeUsingBinarySearch(int[] A, int start, int end, int target, int[] result)
        {
            int mid = (start + end) / 2;
            if (A[start] == target)
            {
                result[0] = start;
                int i = start + 1;
                while (A[i] == target)
                {
                    i++;
                }
                result[1] = i - 1;
                return result;
            }
            if (target > A[mid])
            {
                return SeearchRangeUsingBinarySearch(A, mid + 1, end, target, result);
            }
            else
            {
                return SeearchRangeUsingBinarySearch(A, start, mid - 1, target, result);
            }
        }

        public int[] SearchOccurenceRange(int[] nums, int target)
        {
            int[] res = new int[] { -1, -1 };
            if (nums.Length == 0) return res;
            res[0] = FirstOccurence(nums, 0, nums.Length - 1, target);
            res[1] = LastOccurence(nums, 0, nums.Length - 1, target);
            return res;
        }

        public int FirstOccurence(int[] A, int start, int end, int target)
        {
            if (end >= start)
            {
                int mid = start + (end - start) / 2;
                if (target == A[mid] && (mid == 0 || A[mid - 1] < target)) return mid;
                else if (target > A[mid]) return FirstOccurence(A, mid + 1, end, target);
                else return FirstOccurence(A, start, mid - 1, target);
            }
            return -1;
        }

        public int LastOccurence(int[] A, int start, int end, int target)
        {
            if (end >= start)
            {
                int mid = start + (end - start) / 2;
                if ((mid == A.Length - 1 || target < A[mid + 1]) && A[mid] == target) return mid;
                else if (target < A[mid]) return LastOccurence(A, start, (mid - 1), target);
                else return LastOccurence(A, (mid + 1), end, target);
            }
            return -1;
        }

        public List<string> GetPerms(string str)
        {
            List<string> result = new List<string>();
            GetPerms("", str, result);
            return result;
        }

        public void GetPerms(string prefix, string remainder, List<string> result)
        {
            if (remainder.Length == 0) result.Add(prefix);
            int len = remainder.Length - 1;
            for (int i = 0; i < len; i++)
            {
                string before = remainder.Substring(0, i);
                string after = remainder.Substring(i + 1, len);
                char c = remainder[i];
                GetPerms(prefix + c, before + after, result);
            }
        }

        public List<List<TreeNode>> CreateLevelOrder(TreeNode root)
        {
            List<List<TreeNode>> listOfList = new List<List<TreeNode>>();
            CreateLevelOrderHelper(root, listOfList, 0);
            return listOfList;
        } //Forget this

        public void CreateLevelOrderHelper(TreeNode root, List<List<TreeNode>> lol, int level)
        {
            if (root == null) return;
            List<TreeNode> list = null;
            if (lol.Count == level)
            {
                list = new List<TreeNode>();
                lol.Add(list);
            }
            else
            {
                list = lol[level];
            }
            list.Add(root);
            CreateLevelOrderHelper(root.left, lol, level + 1);
            CreateLevelOrderHelper(root.right, lol, level + 1);
        }

        public bool FindIfAappearsBeforeB(string S)
        {
            // aabbb:t, ba:f, aaa:t, b:t, abba:f
            if (S.Length == 1 && S[0] == 'b') return false;
            bool flag = false;
            for (int i = 0; i < S.Length; i++)
            {
                if (i > 0 && (S[i] == 'b' && S[i - 1] == 'a')) flag = true;
                else flag = false;
            }
            return flag;
        }

        public int EvaluateReversePolishNotationOrPostFixNotation(string[] s)
        { //https://leetcode.com/problems/evaluate-reverse-polish-notation/
            Stack<int> st = new Stack<int>();
            int temp;
            int op1;
            int op2;
            for (int i = 0; i < s.Length; i++)
            {
                switch (s[i])
                {
                    case "+":
                        if (st.Count > 0)
                        {
                            op2 = st.Pop();
                            op1 = st.Pop();
                            temp = op1 + op2;
                            st.Push(temp);
                        }
                        break;
                    case "-":
                        if (st.Count > 0)
                        {
                            op2 = st.Pop();
                            op1 = st.Pop();
                            temp = op1 - op2;
                            st.Push(temp);
                        }
                        break;
                    case "*":
                        if (st.Count > 0)
                        {
                            op2 = st.Pop();
                            op1 = st.Pop();
                            temp = op1 * op2;
                            st.Push(temp);
                        }
                        break;
                    case "/":
                        if (st.Count > 0)
                        {
                            op2 = st.Pop();
                            op1 = st.Pop();
                            temp = op1 / op2;
                            st.Push(temp);
                        }
                        break;
                    default:
                        st.Push(Int32.Parse(s[i]));
                        break;
                }
            }
            return st.Pop();
        }

        public int[][] Merge(int[][] intervals)
        { //https://leetcode.com/problems/merge-intervals/
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

            List<int[]> res = new List<int[]>();

            foreach (var interval in intervals)
            {
                // b[0] <=a[1] then add a[0], b[1]
                if (!res.Any() || res[res.Count - 1][1] < interval[0])
                {
                    res.Add(interval);
                }
                else
                {
                    //extend the [1] element of already in the list.
                    res[res.Count - 1][1] = Math.Max(res[res.Count - 1][1], interval[1]);
                }
            }
            return res.ToArray();
        }

        public string ReverseWords2(string s)
        { //https://leetcode.com/problems/reverse-words-in-a-string/
            StringBuilder sb = new StringBuilder();
            int j, i = 0;
            while (i < s.Length)
            {
                while (i < s.Length && s[i] == ' ') { i++; }
                if (i >= s.Length) break;
                j = i + 1;
                while (j < s.Length && s[j] != ' ') { j++; }

                if (sb.Length == 0)
                {
                    sb.Append(s.Substring(i, j - i));
                }
                else
                {
                    sb.Insert(0, ' ');
                    sb.Insert(0, s.Substring(i, j - i));
                }
                i = j + 1;
            }
            return sb.ToString().Trim();
        }

        public string FractionToDecimal(int numerator, int denominator)
        { //https://leetcode.com/problems/fraction-to-recurring-decimal/
            StringBuilder sb = new StringBuilder();
            long nume;
            long den;
            if ((numerator < 0 && denominator > 0) || (numerator > 0 && denominator < 0))
            {
                sb.Append("-");
            }
            nume = Math.Abs((long)numerator);
            den = Math.Abs((long)denominator);

            long q = nume / den;
            long r = nume % den;
            sb.Append(q);
            if (r == 0)
            {
                return sb.ToString();
            }
            else
            {
                sb.Append(".");
                Dictionary<long, long> dic = new Dictionary<long, long>();
                while (r != 0)
                {
                    if (dic.ContainsKey(r))
                    {
                        sb.Insert((int)dic[r], "(");
                        sb.Append(")");
                        break;
                    }
                    else
                    {
                        dic.Add(r, sb.Length);
                        r *= 10;
                        q = r / den;
                        r = r % den;
                        sb.Append(q);
                    }
                }
            }

            return sb.ToString();
        }

        public string FormLargestNumber(int[] nums)
        { //https://leetcode.com/problems/largest-number/
            if (nums.Length == 0) return "0";
            string[] sarr = new string[nums.Length];
            sarr = nums.Select(x => x.ToString()).ToArray();

            Array.Sort(sarr, (string a, string b) =>
            {
                string op1 = a + b;
                string op2 = b + a;
                return op2.CompareTo(op1);
            });
            if (sarr[0].Equals("0")) return "0";
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i < sarr.Length)
            {
                sb.Append(sarr[i]);
                i++;
            }
            return sb.ToString();
        }

        public int NumIslands(char[][] grid)
        { //https://leetcode.com/problems/number-of-islands/
            int rows = grid.Length;
            int cols = grid[0].Length;

            int islands = 0;
            int i = 0;
            while (i < rows)
            {
                int j = 0;
                while (j < cols)
                {
                    if (grid[i][j] == '1')
                    {
                        MarkAdjacentIslands(grid, i, j, rows, cols);
                        islands++;
                    }
                    j++;
                }
                i++;
            }
            return islands;
        }

        public void MarkAdjacentIslands(char[][] grid, int i, int j, int rows, int cols)
        {
            if (i < 0 || i >= rows || j < 0 || j >= cols || grid[i][j] != '1') return;
            grid[i][j] = '2';
            MarkAdjacentIslands(grid, i, j + 1, rows, cols); //right
            MarkAdjacentIslands(grid, i, j - 1, rows, cols); //left
            MarkAdjacentIslands(grid, i + 1, j, rows, cols); //down
            MarkAdjacentIslands(grid, i - 1, j, rows, cols);// up
        }

        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        { //https://leetcode.com/problems/flood-fill/
            int rowlen = image.Length;
            int collen = image[0].Length;
            int oldColor = image[sr][sc];
            if (oldColor != newColor)
            {
                MarkAdjacentFloodFill(image, sr, sc, rowlen, collen, oldColor, newColor);
            }
            return image;
        }

        public void MarkAdjacentFloodFill(int[][] image, int i, int j, int rowlen, int collen, int oldColor, int newColor)
        {
            if (i < 0 || i >= rowlen || j < 0 || j >= collen || image[i][j] != oldColor) return;
            image[i][j] = newColor;
            MarkAdjacentFloodFill(image, i, j + 1, rowlen, collen, oldColor, newColor);
            MarkAdjacentFloodFill(image, i, j - 1, rowlen, collen, oldColor, newColor);
            MarkAdjacentFloodFill(image, i - 1, j, rowlen, collen, oldColor, newColor);
            MarkAdjacentFloodFill(image, i + 1, j, rowlen, collen, oldColor, newColor);
        }

        public int ClimbStairs(int n)
        { //https://leetcode.com/problems/climbing-stairs/
            if (n == 0 || n == 1) return 1;
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            int i = 2;
            while (i <= n)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
                i++;
            }
            return dp[n];
        }

        public int NumJewelsInStones(string jewels, string stones)
        { //https://leetcode.com/problems/jewels-and-stones/
            if (jewels == "" || stones == "") return 0;
            int count = 0;
            byte[] jewelAscii = Encoding.ASCII.GetBytes(jewels);
            byte[] stonesAscii = Encoding.ASCII.GetBytes(stones);
            foreach (var x in stonesAscii)
            {
                if (jewelAscii.Contains(x)) count++;
            }
            return count;
        }

        public string DefangIPaddr(string address)
        { //https://leetcode.com/problems/defanging-an-ip-address/
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i < address.Length)
            {
                if (address[i] == '.') sb.Append("[.]");
                else sb.Append(address[i]);
                i++;
            }
            return sb.ToString();
        }

        public string RestoreString(string s, int[] indices)
        { //https://leetcode.com/problems/shuffle-string/
            char[] r = new char[s.Length];
            int i = 0;
            foreach (int x in indices)
            {
                r[x] = s[i];
                i++;
            }
            return new string(r);
        }

        public string Interpret(string command)
        { //https://leetcode.com/problems/goal-parser-interpretation/
            StringBuilder sb = new StringBuilder();
            int i = 0;
            while (i < command.Length)
            {
                if (command[i] == '(' && command[i + 1] == ')')
                {
                    sb.Append('o');
                    i = i + 2;
                }

                else if (command[i] == '(' && command[i + 1] == 'a' && command[i + 2] == 'l' && command[i + 3] == ')')
                {
                    sb.Append('a');
                    sb.Append('l');
                    i = i + 4;
                }
                else
                {
                    sb.Append(command[i]);
                    i++;
                }
            }
            return sb.ToString();
        }

        public int[][] KClosest(int[][] points, int k)
        { //https://leetcode.com/problems/k-closest-points-to-origin/
            //https://www.geeksforgeeks.org/find-k-closest-points-to-the-origin/
            int n = points.Length;
            int[] distance = new int[n];
            for (int i = 0; i < n; i++)
            {
                int x = points[i][0], y = points[i][1];
                distance[i] = (x * x) + (y * y);
            }

            Array.Sort(distance);
            int distK = distance[k - 1];
            List<int[]> res = new List<int[]>();

            for (int i = 0; i < n; i++)
            {
                int x = points[i][0], y = points[i][1];
                int dist = (x * x) + (y * y);
                if (dist <= distK)
                {
                    res.Add(new int[] { points[i][0], points[i][1] });
                }
            }
            int[][] jaggedArr = new int[res.Count][];

            for (int i = 0; i < res.Count; i++)
            {
                jaggedArr[i] = res[i];
            }

            return jaggedArr;
        }

        public bool BackspaceCompare(string s, string t)
        { //https://leetcode.com/problems/backspace-string-compare/
            string a = BackspaceCompareHelper(s);
            string b = BackspaceCompareHelper(t);
            return a == b;
        }

        public string BackspaceCompareHelper(string s)
        {
            Stack<char> st = new Stack<char>();
            int i = 0;
            while (i < s.Length)
            {
                if (s[i] != '#')
                {
                    st.Push(s[i]);
                }
                else if (st.Count > 0)
                {
                    st.Pop();
                }
                i++;
            }
            return new string(st.ToArray());
        }

        public string SortSentence(string s)
        { //https://leetcode.com/problems/sorting-the-sentence/
            Dictionary<int, string> dic = new Dictionary<int, string>();
            StringBuilder sb = new StringBuilder();
            string[] tokens = s.Split(' ');
            int i = 0;
            while (i < tokens.Length)
            {
                string word = tokens[i];
                string temp = word.Substring(0, word.Length - 1);
                int index = word.Length - 1;
                if (!dic.ContainsKey(int.Parse(word[index].ToString())))
                    dic.Add(int.Parse(word[index].ToString()), temp);
                i++;
            }
            for (int j = 1; j <= 9; j++)
            {
                if (dic.ContainsKey(j))
                {
                    sb.Append(dic[j]);
                    sb.Append(" ");
                }
            }
            return sb.ToString().Trim();
        }

        public int NumDifferentIntegers(string word)
        { //https://leetcode.com/problems/number-of-different-integers-in-a-string/
            HashSet<string> set = new HashSet<string>();
            string[] tokens = Regex.Replace(word, @"[a-z]+", " ").Split(' ');
            for (int i = 0; i < tokens.Length; i++)
            {
                if (string.IsNullOrEmpty(tokens[i])) continue;
                if (!set.Contains(tokens[i].TrimStart('0'))) set.Add(tokens[i].TrimStart('0'));

            }
            return set.Count();
        }

        public string DecodeString(string s)
        { //https://leetcode.com/problems/decode-string/
            //s = "3[a]2[bc]"
            Stack<int> intSt = new Stack<int>();
            Stack<char> charSt = new Stack<char>();
            string result = "", temp = "";

            for (int i = 0; i < s.Length; i++)
            {
                int count = 0;
                if (char.IsDigit(s[i]))
                {
                    while (char.IsDigit(s[i]))
                    {
                        count = count * 10 + s[i] - '0';
                        i++;
                    }
                    i--;
                    intSt.Push(count);
                }
                else if (s[i] == '[')
                {
                    if (char.IsDigit(s[i - 1]))
                    {
                        charSt.Push(s[i]);
                    }
                    else
                    {
                        intSt.Push(1); // important to consider
                        charSt.Push(s[i]);
                    }
                }
                else if (s[i] == ']')
                {
                    temp = "";
                    count = 0;
                    while (charSt.Count > 0 && charSt.Peek() != '[')
                    {
                        temp = charSt.Peek() + temp;
                        charSt.Pop();
                    }

                    if (charSt.Count > 0 && charSt.Peek() == '[')
                    {
                        charSt.Pop();
                    }
                    if (intSt.Count > 0)
                    {
                        count = intSt.Peek();
                        intSt.Pop();
                    }

                    for (int j = 0; j < count; j++)
                    {
                        result = result + temp;
                    }

                    for (int j = 0; j < result.Length; j++)
                    {
                        charSt.Push(result[j]);
                    }
                    result = "";
                }
                else
                {
                    charSt.Push(s[i]);
                }
            }

            while (charSt.Count > 0)
            {
                result = charSt.Peek() + result;
                charSt.Pop();
            }
            return result;
        }

        public int LengthOfLastWord(string s)
        { //https://leetcode.com/problems/length-of-last-word/
            if (string.IsNullOrEmpty(s)) return 0;
            string[] tokens = s.Trim().Split(' ');
            int n = tokens.Length;
            return tokens[n - 1].Length;
        }

        public IList<int> PartitionLabels(string s) //ababcbacadefegdehijhklij
        { //https://leetcode.com/problems/partition-labels/
            Dictionary<char, int> dic = new Dictionary<char, int>();
            int i = 0;
            while (i < s.Length)
            {
                if (!dic.ContainsKey(s[i]))
                    dic.Add(s[i], i); // store last seen index.
                else dic[s[i]] = i;
                i++;
            }
            i = 0;
            List<int> result = new List<int>();
            int end = 0, temp = 0;
            while (i < s.Length)
            {
                end = Math.Max(end, dic[s[i]]);
                if (i == end)
                {
                    result.Add(i - temp + 1);
                    temp = i + 1;
                }

                i++;
            }
            return result;
        }

        public string MinWindow(string s, string t) // this is wrong answer
        { //https://leetcode.com/problems/minimum-window-substring/
            StringBuilder sb = new StringBuilder();
            if (s.Length < t.Length) return sb.ToString();
            Dictionary<char, int> dic = StringToDictionary(t);

            int i = 0, j = t.Length - 1;
            while (j < s.Length)
            {
                if (DoesStringContainAllCharsOf(s.Substring(i, j - i + 1), dic, t))
                {
                    sb.Clear();
                    sb.Append(s.Substring(i, j - i + 1));
                }
                else
                {
                    j++;
                    while (j < s.Length)
                    {
                        if (DoesStringContainAllCharsOf(s.Substring(i, j - i + 1), dic, t))
                        {
                            sb.Clear();
                            sb.Append(s.Substring(i, j - i + 1));
                            break;
                        }
                        j++;
                    }
                }
                i++;
                while (i < j && (j - i + 1 >= t.Length) && j < s.Length)
                {
                    if (DoesStringContainAllCharsOf(s.Substring(i, j - i + 1), dic, t))
                    {
                        if ((j - i + 1) < sb.ToString().Length)
                        {
                            sb.Clear();
                            sb.Append(s.Substring(i, j - i + 1));
                        }
                    }
                    else
                    {
                        break;
                    }
                    i++;
                }
            }
            return sb.ToString();
        }

        public bool DoesStringContainAllCharsOf(string x, Dictionary<char, int> dic, string t)
        {
            Dictionary<char, int> xdic = StringToDictionary(x);
            int i = 0;
            while (i < t.Length)
            {
                if (xdic.ContainsKey(t[i]))
                {
                    if (xdic[t[i]] < dic[t[i]])
                    {
                        return false;
                    }
                }
                else if (!xdic.ContainsKey(t[i]))
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        public Dictionary<char, int> StringToDictionary(string t)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            int i = 0;
            while (i < t.Length)
            {
                if (!dic.ContainsKey(t[i]))
                {
                    dic.Add(t[i], 1);
                }
                else
                {
                    dic[t[i]]++;
                }
                i++;
            }
            return dic;
        }

        public IList<IList<string>> GroupAnagrams(string[] arr) // Not efficient solution, look into GroupAnagrams2 sol.
        { //https://leetcode.com/problems/group-anagrams/
            List<IList<string>> output = new List<IList<string>>();
            List<string> result = new List<string>();
            if (arr.Length == 1)
            {
                result.Add(arr[0]);
                output.Add(result);
                return output;
            }
            if (IsValidAnagram(arr[0], arr[1]))
            {
                result.Add(arr[0]);
                result.Add(arr[1]);
                output.Add(result);
            }
            else
            {
                output.Add(new List<string> { arr[0] });
                output.Add(new List<string> { arr[1] });
            }
            int x = 2;
            while (x < arr.Length)
            {
                int y = 0;
                while (y < output.Count)
                {
                    if (IsValidAnagram(arr[x], output[y][0]))
                    {
                        output[y].Add(arr[x]);
                        break;
                    }
                    else if (y == output.Count - 1)
                    {
                        output.Add(new List<string> { arr[x] });
                        break;
                    }
                    y++;
                }
                x++;
            }
            return output;
        }

        public bool IsValidAnagram(string a, string b)
        {
            if (a.Length != b.Length) return false;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int i = 0, j = 0;
            while (i < a.Length)
            {
                if (!dict.ContainsKey(a[i]))
                {
                    dict.Add(a[i], 1);
                }
                else
                {
                    dict[a[i]]++;
                }
                i++;
            }
            while (j < b.Length)
            {
                if (!dict.ContainsKey(b[j]))
                {
                    //dict.Clear();
                    return false;
                }
                else
                {
                    dict[b[j]]--;
                    if (dict[b[j]] < 0)
                    {
                        //dict.Clear();
                        return false;
                    }
                }
                j++;
            }
            //dict.Clear();
            return true;
        }

        public IList<IList<string>> GroupAnagrams2(string[] arr)
        { //https://leetcode.com/problems/group-anagrams/
            List<IList<string>> output = new List<IList<string>>();
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
            int i = 0;
            while (i < arr.Length)
            {
                char[] ch = arr[i].ToCharArray();
                Array.Sort(ch);
                string key = new string(ch);
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, new List<string>());
                }
                dict[key].Add(arr[i]);
                i++;
            }
            foreach (var x in dict.Values)
            {
                output.Add(x);
            }
            return output;
        }

        public bool IsPalindromeStringWithOnlyAlphaNumericCharacters(string s)
        { //https://leetcode.com/problems/valid-palindrome/
            //string a = Regex.Replace(s,@"[A-Za-z0-9]+","").ToLower();
            int head = 0, tail = s.Length - 1;
            while (head <= tail)
            {
                if (!Char.IsLetterOrDigit(s[head]))
                {
                    head++;
                }
                else if (!Char.IsLetterOrDigit(s[tail]))
                {
                    tail--;
                }
                else
                {
                    if (Char.ToLower(s[head]) != Char.ToLower(s[tail]))
                    {
                        return false;
                    }
                    head++;
                    tail--;
                }
            }
            return true;
        }

        public int NumUniqueEmails(string[] e)
        { //https://leetcode.com/problems/unique-email-addresses/
            int i = 0;
            //int res=0;
            HashSet<string> res = new HashSet<string>();
            while (i < e.Length)
            {
                string[] part = e[i].Split('@');
                string[] local = part[0].Split('+');
                //if(part[1].Split(".").Length >2){
                //  i++;
                //continue;
                //}
                //res++;
                res.Add(local[0].Replace(".", "") + "@" + part[1]);
                i++;
            }
            return res.Count;
        }

        public string LicenseKeyFormatting(string s, int k)
        { //https://leetcode.com/problems/license-key-formatting/
            s = s.Replace("-", "").ToUpper();
            StringBuilder sb = new StringBuilder();
            int i = s.Length;
            while (i > k)
            {
                i = i - k;
                string r = s.Substring(i, k);
                sb.Insert(0, r);
                sb.Insert(0, '-');
            }
            sb.Insert(0, s.Substring(0, i));
            return sb.ToString();
        }

        public IList<int> RightSideView(TreeNode root)
        { //https://leetcode.com/problems/binary-tree-right-side-view/
            Queue<TreeNode> q = new Queue<TreeNode>();
            if (root != null)
            {
                q.Enqueue(root);
            }
            List<int> li = new List<int>();
            while (q.Count > 0)
            {
                int size = q.Count;
                for (int i = 1; i <= size; i++)
                {
                    TreeNode temp = q.Dequeue();
                    if (temp.left != null)
                        q.Enqueue(temp.left);
                    if (temp.right != null)
                        q.Enqueue(temp.right);
                    if (i == size) li.Add(temp.val);
                }
            }
            return li;
        }

    }

    /**
  // This is the interface that allows for creating nested lists.
  // You should not implement it, or speculate about its implementation
  interface NestedInteger {
 
      // Constructor initializes an empty nested list.
      public NestedInteger();
 
      // Constructor initializes a single integer.
      public NestedInteger(int value);
 
      // @return true if this NestedInteger holds a single integer, rather than a nested list.
      bool IsInteger();
 
      // @return the single integer that this NestedInteger holds, if it holds a single integer
      // Return null if this NestedInteger holds a nested list
      int GetInteger();
 
     // Set this NestedInteger to hold a single integer.
      public void SetInteger(int value);
 
     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
      public void Add(NestedInteger ni);
 
      // @return the nested list that this NestedInteger holds, if it holds a nested list
      // Return null if this NestedInteger holds a single integer
     IList<NestedInteger> GetList();
  }
 */
    //public class DepthSumSolution             // ****** premium Question*******
    //{
    //    public int DepthSum(IList<NestedInteger> nestedList)
    //    {
    //        int depth = 1;
    //        return DepthSumUtil(nestedList, depth);
    //    }
    //    public int DepthSumUtil(IList<NestedInteger> nestedList, int depth)
    //    {
    //        int total = 0;
    //        int i = 0;
    //        while (i < nestedList.Count)
    //        {
    //            if (nestedList[i].IsInteger())
    //            {
    //                total += nestedList[i].GetInteger() * depth;
    //            }
    //            else
    //            {
    //                total += DepthSumUtil(nestedList[i].GetList(), depth + 1);
    //            }

    //            i++;
    //        }
    //        return total;
    //    }
    //}

    /**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // Constructor initializes an empty nested list.
 *     public NestedInteger();
 *
 *     // Constructor initializes a single integer.
 *     public NestedInteger(int value);
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // Set this NestedInteger to hold a single integer.
 *     public void SetInteger(int value);
 *
 *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
 *     public void Add(NestedInteger ni);
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
    //public class DepthSumInverseSolution
    //{
    //    public int DepthSumInverse(IList<NestedInteger> nestedList)
    //    {
    //        int maxdepth = findmaxdepth(nestedList);
    //        return Util(nestedList, 1, maxdepth);
    //    }
    //    public int findmaxdepth(IList<NestedInteger> nestedList)
    //    {
    //        int max = 1;
    //        int i = 0;
    //        while (i < nestedList.Count)
    //        {
    //            if (!nestedList[i].IsInteger())
    //            {
    //                max = Math.Max(max, 1 + findmaxdepth(nestedList[i].GetList()));
    //            }
    //            i++;
    //        }
    //        return max;
    //    }
    //    public int Util(IList<NestedInteger> nestedList, int depth, int maxdepth)
    //    {
    //        int res = 0;
    //        int i = 0;
    //        while (i < nestedList.Count)
    //        {
    //            if (!nestedList[i].IsInteger())
    //            {
    //                res += Util(nestedList[i].GetList(), depth + 1, maxdepth);
    //            }
    //            else
    //            {
    //                res += nestedList[i].GetInteger() * (maxdepth - depth + 1);
    //            }
    //            i++;
    //        }
    //        return res;
    //    }
    //}

    #region Diameter of Tree
    public class DiameterSolution
    {
        int dia = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            height(root);
            return dia;
        }

        public int height(TreeNode root)
        {
            if (root == null) return 0;
            int leftH = height(root.left);
            int rightH = height(root.right);

            dia = Math.Max(dia, leftH + rightH);
            return Math.Max(leftH, rightH) + 1;
        }
    }
    #endregion

    #region LinkedList random pointer
    public class RandomListNode
    {
        public int val;
        public RandomListNode next;
        public RandomListNode random;

        public RandomListNode(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
    public class LinkedListRandomList
    { //https://leetcode.com/problems/copy-list-with-random-pointer/
        Dictionary<RandomListNode, RandomListNode> visited = new Dictionary<RandomListNode, RandomListNode>();

        public RandomListNode CopyRandomList(RandomListNode head)
        {
            if (head == null)
            {
                return null;
            }
            if (visited.ContainsKey(head))
            {
                return visited[head];
            }

            RandomListNode newNode = new RandomListNode(head.val);

            visited.Add(head, newNode);

            newNode.next = CopyRandomList(head.next);
            newNode.random = CopyRandomList(head.random);

            return newNode;
        }
    }
    #endregion

    #region Max path sum
    public class MaxPathSumClass
    { //https://leetcode.com/problems/binary-tree-maximum-path-sum/
        int result = int.MinValue;
        public int MaxPathSum(TreeNode root)
        {
            maxUtil(root);
            return result;
        }

        public int maxUtil(TreeNode root)
        {
            if (root == null) return 0;

            int l = Math.Max(maxUtil(root.left), 0);
            int r = Math.Max(maxUtil(root.right), 0);

            result = Math.Max(result, l + r + root.val);

            return root.val + Math.Max(l, r);
        }
    }
    #endregion

    #region ListNode
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    #endregion

    #region MinStack LeetCode
    public class MinStack
    {
        Stack<int> Regular;
        Stack<int> Mininum;
        public MinStack()
        {
            Regular = new Stack<int>();
            Mininum = new Stack<int>();
        }

        public void Push(int x)
        {
            Regular.Push(x);
            if (Mininum.Count == 0) Mininum.Push(x);
            else if ((x <= Mininum.Peek())) Mininum.Push(x);
        }

        public void Pop()
        {
            int removedElement = Regular.Pop();
            if (removedElement == Mininum.Peek()) Mininum.Pop();
        }

        public int Top()
        {
            return Regular.Peek();
        }

        public int GetMin()
        {
            return Mininum.Peek();
        }

    }
    #endregion

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class RangeSumBSTSolution
    {
        int result = 0;
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            UtilRangeSumBST(root, low, high);
            return result;
        }
        public void UtilRangeSumBST(TreeNode root, int low, int high)
        {
            if (root != null)
            {
                if (root.val < high)
                {
                    UtilRangeSumBST(root.right, low, high);
                }
                if (root.val > low)
                {
                    UtilRangeSumBST(root.left, low, high);
                }
                if (root.val >= low && root.val <= high)
                {
                    result = result + root.val;
                }
            }
        }
    }

    public class SymmetryClass
    {
        public bool IsSymmetric(TreeNode root)
        { //https://leetcode.com/problems/symmetric-tree/
            return SymmetricUtil(root, root);
        }

        public bool SymmetricUtil(TreeNode t1, TreeNode t2)
        { // Recursive
            if (t1 == null && t2 == null) return true;
            if (t1 == null || t2 == null) return false;
            return (t1.val == t2.val) && SymmetricUtil(t1.left, t2.right)
                            && SymmetricUtil(t1.right, t2.left);

        }

        public bool SymmetricUtil2(TreeNode root)
        { // iterative
            Queue<TreeNode> q = new Queue<TreeNode>();
            if (root != null)
            {
                q.Enqueue(root);
                q.Enqueue(root);
            }
            while (q.Count > 0)
            {
                TreeNode t1 = q.Dequeue();
                TreeNode t2 = q.Dequeue();
                if (t1 == null && t2 == null) continue;
                if (t1 == null || t2 == null) return false;
                if (t1.val != t2.val) return false;
                q.Enqueue(t1.left);
                q.Enqueue(t2.right);
                q.Enqueue(t1.right);
                q.Enqueue(t2.left);
            }
            return true;
        }
    }


    //Inorder - preorder - postorder
    public class BinaryTreeDFS
    {
        List<int> result = new List<int>();
        public IList<int> InorderTraversal(TreeNode root)
        {
            InorderUtil(root);
            return result;
        }
        public void InorderUtil(TreeNode root)
        {
            if (root == null) return;
            if (root.left != null)
            {
                InorderUtil(root.left);
            }
            result.Add(root.val);
            if (root.right != null)
            {
                InorderUtil(root.right);
            }
        }
    }

    public class BinaryTreeBFS
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> res = new List<IList<int>>();
            Queue<TreeNode> q = new Queue<TreeNode>();
            if (root != null) q.Enqueue(root);

            while (q.Count > 0)
            {
                List<int> level = new List<int>();
                int i = 0;
                int size = q.Count;
                while (i < size)
                {
                    TreeNode temp = q.Dequeue();
                    level.Add(temp.val);
                    if (temp.left != null)
                    {
                        q.Enqueue(temp.left);
                    }
                    if (temp.right != null)
                    {
                        q.Enqueue(temp.right);
                    }
                    i++;
                }
                res.Add(level);

            }
            return res;
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        { //https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
            List<IList<int>> res = new List<IList<int>>();

            bool leftToRight = true;
            Stack<TreeNode> currentLevel = new Stack<TreeNode>();
            Stack<TreeNode> nextLevel = new Stack<TreeNode>();
            if (root != null)
            {
                currentLevel.Push(root);
            }
            List<int> level = new List<int>();
            while (currentLevel.Count > 0)
            {
                TreeNode node = currentLevel.Pop();

                level.Add(node.val);
                if (leftToRight)
                {
                    if (node.left != null)
                    {
                        nextLevel.Push(node.left);
                    }
                    if (node.right != null)
                    {
                        nextLevel.Push(node.right);
                    }
                }
                else
                {
                    if (node.right != null)
                    {
                        nextLevel.Push(node.right);
                    }
                    if (node.left != null)
                    {
                        nextLevel.Push(node.left);
                    }
                }

                if (currentLevel.Count == 0)
                {
                    res.Add(level);
                    leftToRight = !leftToRight;
                    Stack<TreeNode> temp = currentLevel;
                    currentLevel = nextLevel;
                    nextLevel = temp;
                    level = new List<int>();
                }

            }
            return res;
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) // Binary Search Tree
        { //https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-search-tree/
            int pval = p.val;
            int qval = q.val;
            TreeNode node = root;
            while (node != null)
            {
                int parentval = node.val;
                if (pval > parentval && q.val > parentval)
                {
                    node = node.right;
                }
                else if (pval < parentval && q.val < parentval)
                {
                    node = node.left;
                }
                else
                {
                    return node;
                }
            }
            return node;
        }

        public TreeNode LowestCommonAncestorBinaryTree(TreeNode root, TreeNode p, TreeNode q) //Binary Tree
        { // https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
            // https://www.geeksforgeeks.org/lowest-common-ancestor-binary-tree-set-1/ method 2
            if (root == null) return null;
            if (root == p || root == q) return root;
            TreeNode left = LowestCommonAncestorBinaryTree(root.left, p, q);
            TreeNode right = LowestCommonAncestorBinaryTree(root.right, p, q);

            if (left != null && right != null) return root;
            if (left == null && right == null) return null;
            return left != null ? left : right;
        }

        #region Binary Tree easy method
        public TreeNode res = null;
        public TreeNode LowestCommonAncestorBinaryTree2(TreeNode root, TreeNode p, TreeNode q)
        {
            util(root, p, q);
            return res;
        }

        public bool util(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return false;
            }
            int left = util(root.left, p, q) ? 1 : 0;
            int right = util(root.right, p, q) ? 1 : 0;
            int mid = (root == p || root == q) ? 1 : 0;
            if (mid + left + right >= 2)
            {
                res = root;
            }
            return (mid + left + right > 0);
        }
        #endregion
    }

    public class NodeNextPointer
    {
        public int val;
        public NodeNextPointer left;
        public NodeNextPointer right;
        public NodeNextPointer next;

        public NodeNextPointer() { }

        public NodeNextPointer(int _val)
        {
            val = _val;
        }

        public NodeNextPointer(int _val, NodeNextPointer _left, NodeNextPointer _right, NodeNextPointer _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }

        public NodeNextPointer Connect(NodeNextPointer root)
        { // https://leetcode.com/problems/populating-next-right-pointers-in-each-node/
            if (root == null) return root;
            NodeNextPointer leftmost = root;
            while (leftmost.left != null)
            {
                NodeNextPointer head = leftmost;
                while (head != null)
                {
                    //connection 1
                    head.left.next = head.right;
                    //connection 2
                    if (head.next != null)
                    {
                        head.right.next = head.next.left;
                    }
                    head = head.next;
                }
                leftmost = leftmost.left;
            }
            return root;
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }

    #region Kth Largest
    public class KthLargest
    { //https://leetcode.com/problems/kth-largest-element-in-an-array/
        int[] minHeap;
        int heapSize;
        SortAlgorithms sortAlgorithms = new SortAlgorithms();

        public KthLargest(int k, int[] nums)
        {
            heapSize = k;
            if (nums.Length != 0 && k <= nums.Length)
            {
                minHeap = new int[heapSize];
                sortAlgorithms.MinHeapSort(nums);
                for (int i = 0; i < heapSize; i++)
                {
                    minHeap[i] = nums[i];
                }
                sortAlgorithms.BuildMinHeap(minHeap, minHeap.Length);
            }
            else if (nums.Length != 0 && nums.Length <= k)
            {
                minHeap = new int[nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    minHeap[i] = nums[i];
                }
                sortAlgorithms.MinHeapSort(minHeap);
                sortAlgorithms.BuildMinHeap(minHeap, minHeap.Length);
            }
        }

        public int Add(int val)
        {
            if (minHeap == null || minHeap.Length == 0)
            {
                minHeap = new int[heapSize];
                minHeap[0] = val;
            }
            else if (minHeap.Length == 1 && val > minHeap[0])
            {
                minHeap[0] = val;
            }
            else if (heapSize > minHeap.Length)
            {
                int[] newHeap = new int[heapSize];
                int j = 0;
                while (j < minHeap.Length)
                {
                    newHeap[j] = minHeap[j];
                    j++;
                }
                if (j < heapSize)
                {
                    newHeap[j] = val;
                }
                minHeap = newHeap;
                sortAlgorithms.BuildMinHeap(minHeap, minHeap.Length);
            }
            else if (val > minHeap[0])
            {
                minHeap[0] = val;
                sortAlgorithms.BuildMinHeap(minHeap, minHeap.Length);
            }
            return minHeap[0];
        }
    }
    #endregion

    #region LeetCode HashSet
    public class MyHashSet
    {
        int[] HashArr;
        int Capacity;
        int DefaultCapacity = 1000000;

        public MyHashSet()
        {
            Capacity = DefaultCapacity;
            HashArr = new int[Capacity];
            for (int i = 0; i < Capacity; i++)
            {
                HashArr[i] = -1;
            }
        }

        public MyHashSet(int capacity)
        {
            Capacity = capacity;
            HashArr = new int[Capacity];
            for (int i = 0; i < Capacity; i++)
            {
                HashArr[i] = -1;
            }
        }

        public void Add(int key)
        {
            int slot = key % Capacity;
            if (HashArr[slot] == key)
            {
                return;
            }
            HashArr[slot] = key;
        }

        public void Remove(int key)
        {
            int slot = key % Capacity;
            if (HashArr[slot] == key)
            {
                HashArr[slot] = -1;
            }
        }

        public bool Contains(int key)
        {
            int slot = key % Capacity;
            if (HashArr[slot] != -1 && HashArr[slot] == key) return true;
            else return false;
        }
    }
    #endregion

    #region Binary tree from inorder, postorder or preorder
    public class BinaryTreeFromInorderPreorderPostorder
    {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        int rootIndex;

        public TreeNode BinaryTreeFromInorderAndPostorder(int[] inorder, int[] postorder)
        { //https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/
            for (int i = 0; i < inorder.Length - 1; i++)
            {
                dic.Add(inorder[i], i);
            }
            rootIndex = postorder.Length - 1;
            return BinaryTreeFromInorderAndPostorderUtil(inorder, postorder, 0, inorder.Length - 1);
        }

        // Construct Binary Tree from Inorder and Postorder Traversal
        public TreeNode BinaryTreeFromInorderAndPostorderUtil(int[] inorder, int[] postorder, int inostart, int inoend)
        {
            if (inostart > inoend) return null;
            int curRoot = postorder[rootIndex];
            TreeNode tree = new TreeNode(curRoot);
            rootIndex--;

            if (inostart == inoend) return tree;

            int indexCurRoot = dic[curRoot];
            tree.right = BinaryTreeFromInorderAndPostorderUtil(inorder, postorder, indexCurRoot + 1, inoend);
            tree.left = BinaryTreeFromInorderAndPostorderUtil(inorder, postorder, inostart, indexCurRoot - 1);

            return tree;
        }

        public TreeNode BinaryTreeFromInorderAndPreorder(int[] inorder, int[] preorder)
        { //https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
            for (int i = 0; i < inorder.Length; i++)
            {
                dic.Add(inorder[i], i);
            }
            rootIndex = 0;
            return BinaryTreeFromInorderAndPreorderUtil(inorder, preorder, 0, inorder.Length - 1);
        }

        // BuildTree, Construct Binary Tree from Preorder and Inorder Traversal
        public TreeNode BinaryTreeFromInorderAndPreorderUtil(int[] inorder, int[] preorder, int inostart, int inoend)
        {
            if (inostart > inoend) return null;
            int curRoot = preorder[rootIndex];
            TreeNode tree = new TreeNode(curRoot);
            rootIndex++;

            if (inostart == inoend) return tree;

            int indexCurRoot = dic[curRoot];
            tree.left = BinaryTreeFromInorderAndPreorderUtil(inorder, preorder, inostart, indexCurRoot - 1);
            tree.right = BinaryTreeFromInorderAndPreorderUtil(inorder, preorder, indexCurRoot + 1, inoend);


            return tree;
        }
    }
    #endregion

    #region
    public class IsValidBSTClass
    {
        int? lastVal = null;
        public bool IsValidBST(TreeNode root)
        {
            if (root == null) return true;

            if (!IsValidBST(root.left)) return false;

            if (lastVal != null && root.val <= lastVal) return false; // ex: if root value is lessthan left value return false

            lastVal = root.val;

            if (!IsValidBST(root.right)) return false;
            return true;
        }
    }

    #endregion

    #region Trie class
    public class Trie
    {

        TrieNode root;

        /** Initialize your data structure here. */
        public Trie()
        {
            root = new TrieNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            TrieNode node = root;
            int i = 0, index;
            while (i < word.Length)
            {
                index = word[i] - 'a';
                if (node.Children[index] == null)
                {
                    node.Children[index] = new TrieNode();
                }

                node = node.Children[index];

                i++;
            }
            node.IsEndOfTheWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            TrieNode node = root;
            int i = 0, index;
            while (i < word.Length)
            {
                index = word[i] - 'a';
                if (node.Children[index] == null)
                {
                    return false;
                }
                node = node.Children[index];

                i++;
            }
            return node.IsEndOfTheWord && node != null;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string word)
        {
            TrieNode node = root;
            int i = 0, index;
            while (i < word.Length)
            {
                index = word[i] - 'a';
                if (node.Children[index] == null)
                {
                    return false;
                }
                node = node.Children[index];

                i++;
            }
            return node != null;
        }
    }

    public class TrieNode
    {
        readonly int AlphabetSize = 26;
        public bool IsEndOfTheWord;
        public TrieNode[] Children;
        public TrieNode()
        {
            IsEndOfTheWord = false;
            Children = new TrieNode[AlphabetSize];

            int i = 0;
            while (i < Children.Length)
            {
                Children[i] = null;
                i++;
            }
        }
    }

    #endregion

}
