﻿using System;
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

        public string LongestCommonPrefix(string[] strs)
        {
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

        public int RemoveDuplicates(int[] nums)
        {
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
        {
            int lastIndex = nums.Length - 1;
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] == val)
                {
                    nums[i] = nums[lastIndex];
                    lastIndex--;
                }
                i++;
            }
            return lastIndex + 1;
        }

        public int SearchInsert(int[] nums, int target)
        {
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
            return (target <= nums[start]) ? start : start + 1;
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
        {
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

        public void RotateArray(int[] nums, int k)
        {
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

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            TreeNode left = root.left;
            root.left = InvertTree(root.right);
            root.right = InvertTree(left);
            return root;
        }

        public IList<int> FindDisappearedNumbersInArray(int[] nums)
        {
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
        {
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
        {
            if (root == null) return root;
            if (root.val > high) return TrimBST(root.left, low, high);
            if (root.val < low) return TrimBST(root.right, low, high);
            root.left = TrimBST(root.left, low, high);
            root.right = TrimBST(root.right, low, high);
            return root;
        }

        public int FindLengthOfLCIS(int[] nums)
        {
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
        {
            return FindPeak(arr, 0, arr.Length - 1);
        }

        public int FindPeak(int[] A, int start, int end)
        {
            int mid = start + (end - start) / 2;
            int prev = mid - 1;
            int next = mid + 1;
            if (A[prev] < A[mid] && A[mid] > A[next]) return mid;
            else if (A[prev] > A[mid]) return FindPeak(A, start, mid);
            else return FindPeak(A, mid + 1, end);
        }

        public int CountCharacters(string[] words, string chars)
        {
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

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
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

        public int LengthOfLongestSubstring(string s)
        {
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

        public string Convert(string s, int numRows)
        {
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
        {
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

        public int MaxAreaContainerWithMostWater(int[] A)
        {
            int i = 0, j = A.Length - 1, area = 0;
            while (i < j)
            {
                area = Math.Max(area, ((j - i) * Math.Min(A[i], A[j])));
                if (A[i] > A[j]) j--;
                else i++;
            }
            return area;
        }

        public string IntToRoman(int num)
        {
            string[] I = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string[] X = new string[] { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] C = new string[] { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] M = new string[] { "", "M", "MM", "MMM", "MMMM" };
            return M[(num / 1000)] + C[(num % 1000) / 100] + X[(num % 100) / 10] + I[num % 10];
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> result = new List<IList<int>>();
            List<int> temp = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int l = i + 1, r = nums.Length - 1, x = nums[i];
                while (l < r)
                {
                    if (x + nums[l] + nums[r] == 0)
                    {
                        temp = new List<int> { x, nums[l], nums[r] };
                        result.Add(temp);
                    }
                    else if (x + nums[l] + nums[r] < 0)
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
            }
            return result;
        }

        public IList<string> LetterCombinations(string digits)
        {
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
        {
            List<string> result = new List<string>();
            if (n > 0)
                _printParenthesis(str, 0, n, 0, 0, result);
            return result;
        }

        public int Search(int[] nums, int target)
        {
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
        {
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
        }

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

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            Queue<TreeNode> current = new Queue<TreeNode>();
            if (root != null)
            {
                current.Enqueue(root);
            }
            while (current.Count > 0)
            {
                List<int> level = new List<int>();
                for (int i = 0; i < current.Count; i++)
                {
                    TreeNode node = current.Dequeue();
                    level.Add(node.val);
                    if (node.left != null) current.Enqueue(node.left);
                    if (node.right != null) current.Enqueue(node.right);
                }
                result.Add(level);
            }
            return result;
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
        {
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

        public string ReverseWords2(string s)
        {
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
        {
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
        {
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
        {
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

        public int ClimbStairs(int n)
        {
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
        {
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
        {
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
        {
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
        {
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

        public string SortSentence(string s)
        {
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
        {
            HashSet<string> set = new HashSet<string>();
            string[] tokens = Regex.Replace(word, @"[a-z]+", " ").Split(' ');            
            for (int i = 0; i < tokens.Length; i++)
            {
                if (string.IsNullOrEmpty(tokens[i])) continue;
                if (!set.Contains(tokens[i].TrimStart('0'))) set.Add(tokens[i].TrimStart('0'));
                
            }
            return set.Count();
        }

        public int LengthOfLastWord(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;
            string[] tokens = s.Trim().Split(' ');
            int n = tokens.Length;
            return tokens[n - 1].Length;
        }

        public IList<int> PartitionLabels(string s) //ababcbacadefegdehijhklij
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            int i = 0;
            while (i < s.Length)
            {
                if (!dic.ContainsKey(s[i]))
                    dic.Add(s[i], i);
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

        public bool CanFinishCourse(int numCourses, int[][] prerequisites)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int i = 0;
            while (i < prerequisites.Length)
            {
                int j = 0;
                if (!dic.ContainsKey(prerequisites[i][j]))
                {
                    if (dic.ContainsKey(prerequisites[i][j + 1]) && dic[prerequisites[i][j + 1]] == prerequisites[i][j]) return false;
                    if (prerequisites[i][j] == prerequisites[i][j + 1]) return false;
                    dic.Add(prerequisites[i][j], prerequisites[i][j + 1]);
                }                
                i++;
            }
            return true;
        }
    }

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
    {
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
        {
            for (int i = 0; i < inorder.Length - 1; i++)
            {
                dic.Add(inorder[i], i);
            }
            rootIndex = postorder.Length - 1;
            return BinaryTreeFromInorderAndPostorderUtil(inorder, postorder, 0, inorder.Length - 1);
        }

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
        {
            for (int i = 0; i < inorder.Length; i++)
            {
                dic.Add(inorder[i], i);
            }
            rootIndex = 0;
            return BinaryTreeFromInorderAndPreorderUtil(inorder, preorder, 0, inorder.Length - 1);
        }

        public TreeNode BinaryTreeFromInorderAndPreorderUtil(int[] inorder, int[] preorder, int inostart, int inoend)
        {
            if (inostart > inoend) return null;
            int curRoot = preorder[rootIndex];
            TreeNode tree = new TreeNode(curRoot);
            rootIndex++;

            if (inostart == inoend) return tree;

            int indexCurRoot = dic[curRoot];
            tree.right = BinaryTreeFromInorderAndPostorderUtil(inorder, preorder, indexCurRoot + 1, inoend);
            tree.left = BinaryTreeFromInorderAndPostorderUtil(inorder, preorder, inostart, indexCurRoot - 1);

            return tree;
        }
    }
    #endregion


}
