using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class Program
    {
        delegate void Printer();
        public static void Main(string[] args)
        {
            #region DS and Algorithms
            //DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            //list.Add(3);
            //list.Add(5);
            //list.Add(7);

            //foreach(int x in list)
            //{
            //    Console.WriteLine(x);
            //}

            //FindingPrimeNumbers findPrimeNumbers = new FindingPrimeNumbers();
            //findPrimeNumbers.AllPrimeNumbers();

            //FindingSubstring findingSubstring = new FindingSubstring();
            //findingSubstring.FindSubstringInArray();

            //Console.WriteLine("Size of array:");
            //int n = Convert.ToInt32(Console.ReadLine());
            //int[] ArrayToSort = new int[n];
            //Console.WriteLine("Enter array values");
            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine("Enter array[{0}] th value", i);
            //    ArrayToSort[i] = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("{0} more elements can be added", (n - 1 - i));
            //}
            //Console.WriteLine("\n Inserted array:\n");
            //for (int k = 0; k < ArrayToSort.Length; k++)
            //{
            //    Console.Write(ArrayToSort[k]);
            //    Console.Write(" ");
            //}

            //Reversing reversing = new Reversing();
            //reversing.ReverseArray(ArrayToSort);

            //SortAlgorithms sortAlgorithms = new SortAlgorithms();

            //sortAlgorithms.MaxHeapSort(ArrayToSort);
            //sortAlgorithms.MinHeapSort(ArrayToSort);
            //sortAlgorithms.PrintArrayElements(ArrayToSort);

            //sortAlgorithms.PanCakeSort(ArrayToSort);
            //sortAlgorithms.PrintArrayElements(ArrayToSort);

            //sortAlgorithms.BitonicSort(ArrayToSort, 0, ArrayToSort.Length, 1);
            //sortAlgorithms.PrintArrayElements(ArrayToSort);

            //sortAlgorithms.ShellSort(ArrayToSort);
            //sortAlgorithms.PrintArrayElements(ArrayToSort);

            //sortAlgorithms.RadixSort(ArrayToSort);
            //sortAlgorithms.PrintArrayElements(ArrayToSort);

            // int[] output = sortAlgorithms.CountingSort(ArrayToSort);
            // sortAlgorithms.PrintArrayElements(output);

            // sortAlgorithms.MergeSort(ArrayToSort, 0, ArrayToSort.Length - 1);
            //sortAlgorithms.QuickSort(ArrayToSort, 0, ArrayToSort.Length - 1);
            //sortAlgorithms.BubbleSort(ArrayToSort);
            // sortAlgorithms.SelectionSort(ArrayToSort);
            // sortAlgorithms.InsertionSort(ArrayToSort);

            #endregion

            #region LeetCode
            LeetCodeProblems leetCodeProblems = new LeetCodeProblems();

            //int[] output = leetCodeProblems.TwoSum(new int[] { 3,2,4}, 6);
            //int output = leetCodeProblems.SumOfAllEvenNumbersInArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            //int output = leetCodeProblems.ReverseNumber(1534236469);
            //bool output = leetCodeProblems.IsPalindrome(121);
            //int output = leetCodeProblems.RomanToInt("III");
            //string output= leetCodeProblems.LongestCommonPrefix(new string[] { "aa", "a" });
            //bool output = leetCodeProblems.IsValidParentheses("(]{}");
            //int output = leetCodeProblems.RemoveElement(new int[] { 4,5 }, 5);
            //SortAlgorithms sortAlgorithms = new SortAlgorithms();
            //int output = sortAlgorithms.KMPSearch("", "");
            //int output = leetCodeProblems.SearchInsert(new int[] { 1, 3, 5, 6 }, 2);
            //bool output = leetCodeProblems.IsHappy(89);
            //bool output = leetCodeProblems.IsAnagram("anagram", "nagaram");
            //int output = leetCodeProblems.GetSum(3, 2);
            //int[] output = leetCodeProblems.MergeSortedArrays(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3);
            //bool output = leetCodeProblems.IsIsomorphic("eeggg", "aaddd");
            //var output = leetCodeProblems.FindDisappearedNumbersInArray(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 });
            //string output = leetCodeProblems.ReverseWords("Let's take LeetCode contest");
            //bool output = leetCodeProblems.CanPlaceFlowers(new int[] { 1, 0, 0, 0, 0, 1 }, 2);
            //bool output = leetCodeProblems.CheckPossibilityToMakeNonDecreasingArrayByChangingOneElement(new int[] {4, 2, 1 });
            //KthLargest kthLargest = new KthLargest(7, new int[] { -10, 1, 3, 1, 4, 10, 3, 9, 4, 5, 1 });
            //int output1 = kthLargest.Add(3);
            //MyHashSet myHashSet = new MyHashSet();
            //myHashSet.Add(1);
            //myHashSet.Remove(2);
            //bool param_1 = myHashSet.Contains(3);
            //int output = leetCodeProblems.PeakIndexInMountainArray(new int[] { 3, 4, 5, 1 });
            //string[] input = new string[] { "pxlqovnbsgvqjzpfeidchzrodnbqfrccfydzjptukscjuatlsrcurepllxzyghhdepitqptlmfkhzxjgswaulxkfydhkilg", "uqklvqnlhdkwryjawkqfajfpbcnhglxlwxlaskxlytr", "jvgkxcdkxrvfahjkvhmfuyjzxtyxrsogbtsjybeaxugqymcr", "rgxditmosplnqvodtis", "jm", "ruqjwejuanjtiizcmbieobesnjnadzqvqumggblzmkxilgfarnxwpcawtkzxlvugibpidvwtikloeziuxqoi", "wxeyzrnbhlhwxecrgejsrawyulynvgtszwqqlihkcvckgcgtgpyqtkuwvjywmhpskaiwmpyarftqhnogxpith", "vdpbykqlihtpvfnqbrcjpggojqbalerohyitktuikbffvfatcnneuvbanjihiaorrjcdthntnrxebfhvshmpodmzhtwnasbm", "wgjstkoaojcesfdrllugmojwdmgeejyiqvshlowtktddattunarnohgvqsoskfmbrami", "ecwqxbawirvnxvsjybbebclaturorlcbpf", "gtjbaigvufrotlwfoqqolnjabnvtbcygtfcytinzpcjbvprdkdjawrcbthmxjrabimhhs", "cvzlbrvppkyxtjxzeglzwoagmpjnfxddbwolxmwdohgtfktgftzzkwpianslkpldyfzubtjczse", "neaw", "mxhmvkajofnmdiiduactlemcvpztscmsnrdhuhquxnnzywsrzxyplgbppiypxwcfbsnyzblaeifo", "krekecabfpufucjhqphjnibaeqdvdpmrfougdwugvoioqangdnxromwlxnfeydaneyazzclscqgdxlhhgnoqmslfflzqv", "klutvchxsceihfmzitgqakytesfjykribjhjzdruuoycjkwaghmmqkfrhkrtawudtjyjwqbyspamlegqjlwlj", "raykfkflqdzrpthdejetwolgciygwaktulkxemkdbbllkjxhnnafsms", "os", "xhchkcetmlprcdmrnalvkvgabxxnomphqpqhnddqhecogspbdebeoshvjgzvmqu", "jqtdysnpskktynxwmsfaabglagnqcllptvuyyqjwrmqaftenusmsahhhqubkwxltpr", "sulmwluiwvlroldpiyecaicwrawzwflokefqkdwmxejaovvpbflfdtviinbvvtlhhhefmgfsqs", "sxyhcckvyl", "vsaacsybcddxvuzkddjmuivsvtjyanpbydmkcwnkmxvsiantgkvkmqjysclsvd", "sxcghypulvmfqfunxj", "pozekufhlooosxpcggbi", "xzaoxzllcixfqbupqozmzrnugj", "j", "tgslwp", "ntrdkixexajlpjgmcbrqimwtqnzfrqjszeiuvrgzclerzmsnagzaxbredvlrmipzflrzusclckmxphc", "ifdflsywdfizpodsehrrifsvejcxarrxmxyjgbbvqyqvywncphzfmnxhybxpdcozfnzablfx", "uluhplzrsaehaqxfnbcmixueedevhirbwqdyztwaxnkogcauymxgcpabxekib", "agtfkinbdccoemxetbryzpluzlpyzicnfopphrxriqm", "pdympxpwvxwcqaxrvbvyqkrresrjgzgxuyfxtkgldtathokdbyfsqfmitmiyagtqgijaiazvsumeyutbbwxqdshquzrehn", "rqe", "sljsvenhhstnnngzqyo", "dezrzpgldeimxfoqajuhjctgvalwkhkjemjaxumxqmifglbizusuqlttxirpbqbuvauwy", "dkwpyezbmkcskoxxcgrxcewknqgdckjxfyzcmzqcbyeucxbqybxoldogtkmdknsrruvnlfqnpfx", "sjeftmjkuperfynbreycwhuoyqybticswblbrrpugzhlrmiedjqufnehevzqwtaebwvdswsz", "lolnfyliloqmhjmhhohdtgfajjfdjqpubslbsrwitbjmrcegdrdjzvonxaefdvdfcbqmaaks", "qhcoaiocjhuzywkirlblajgeapzajqsoa", "sxrmoqxqbtakuqwmrrkljmegbwbeqbywmlyuprwyhljzejbybxoumidpxdrohwdjoqycpxcmivaulnqzneydwqfsvcxgyyseuk", "yrowy", "dohrzkrzdjehpctnjrvhzojullsiucrhphshwxwicyzkvzbqrztic", "rmshnxtbhsdgkiijrmwulocdzjzpgfyimkjdthuzkhoqgkeawgwincubrloknocxwzgqqcxafksxgzh", "aymovnuhptozhkiyowbeguzlkmrwjnujgjbdne", "abc", "vxoigovwmqizmkwbkktqk", "uokwktdempzloaglvvkqstztmwzcmhgxtoua", "bzwjxqueazlzfojrkbqmhtwrvuwsnfcnylurnddpektekca", "qgndjgvzcyajhgmrrnhdywwdbmkhtthwcfiueuxfldanyrmccwcy" };
            //int output = leetCodeProblems.CountCharacters(input, "figspbov");
            //ListNode dummy1 = new ListNode(2);
            //dummy1.next = new ListNode(4);
            //dummy1.next.next = new ListNode(3);
            //ListNode dummy2 = new ListNode(5);
            //dummy2.next = new ListNode(6);
            //dummy2.next.next = new ListNode(4);
            //ListNode output = leetCodeProblems.AddTwoNumbers(dummy2, dummy1);
            //int output = leetCodeProblems.LengthOfLongestSubstring("bbbbb");
            //string lps = leetCodeProblems.LongestPalindrome("cbbd");
            //int output = leetCodeProblems.MyAtoi("-2147483649");
            //int output = leetCodeProblems.MaxAreaContainerWithMostWater(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
            //string output = leetCodeProblems.IntToRoman(2859);
            //IList<IList<int>> output = leetCodeProblems.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            //IList<string> output = leetCodeProblems.LetterCombinations("234");
            //int n = 3;
            //char[] str = new char[2 * n];
            //List<string> output = leetCodeProblems.printParenthesis(str, n);
            //int output = leetCodeProblems.Search(new int[] {1,3}, 0);
            //int[] output = leetCodeProblems.SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
            //int[] output = leetCodeProblems.SearchOccurenceRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8);
            //var output = leetCodeProblems.GetPerms("abc");
            //TreeNode root = new TreeNode(5);
            //root.left = new TreeNode(3);
            //root.right = new TreeNode(4);
            //root.left.left = new TreeNode(1);
            //root.left.right = new TreeNode(2);
            //leetCodeProblems.LevelOrder(root);
            //var output = leetCodeProblems.FindIfAappearsBeforeB("aabbb");

            //List<Printer> printers = new List<Printer>();
            //for (int i = 0; i < 10; i++)
            //{
            //    printers.Add(delegate { Console.WriteLine(i); });
            //}

            //foreach (var printer in printers)
            //{
            //    printer();
            //}

            //TempClass ctx = new TempClass();


            //BTNode root = new BTNode(1);
            //root.left = new BTNode(2);
            //root.right = new BTNode(3);
            //root.left.right = new BTNode(5);
            //root.right.right = new BTNode(4);
            //ctx.RightSideOfBT(root);

            //leetCodeProblems.SortSentence("is2 sentence4 This1 a3");
            //leetCodeProblems.NumDifferentIntegers("a123bc34d8ef34");
            //leetCodeProblems.LengthOfLastWord("a ");
            // var output = leetCodeProblems.PartitionLabels("ababcbacadefegdehijhklij");
            //string output= leetCodeProblems.MinWindow("ADOBECODEBANC", "ABC");
            //var output = leetCodeProblems.GroupAnagrams2(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
            //var output = Regex.Replace("A man, a plan, 987 a canal: Panama", @"[A-Za-z,]+","");
            //var output = leetCodeProblems.IsPalindromeStringWithOnlyAlphaNumericCharacters("race a car");
            //Graph2 gra = new Graph2();
            //var output = gra.CanFinish(2, new int[1][] { new int[] { 1,0} });
            //var output = leetCodeProblems.ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            //Dinosaur di = new Dinosaur();
            //di.ReadAndCalculate();
            //var output = leetCodeProblems.NumUniqueEmails(new string[] { "test.email+alex@leetcode.com", "test.email.leet+alex@code.com" });
            //var output = leetCodeProblems.LicenseKeyFormatting("5F3Z-2e-9-w", 4);
            //var output = leetCodeProblems.FindReplaceString("abcd", new int[] { 0, 2 }, new string[] { "a", "cd" }, new string[] { "eee", "ffff" });
            //var output = leetCodeProblems.BackspaceCompare("a#c","b");

            //int[][] jArray = new int[2][]{ new int[2]{1,3},
            //                               new int[2]{ -2, 2 }
            //                             };
            //var output = leetCodeProblems.KClosest(jArray, 1);
            //var output = leetCodeProblems.GetHint("1123", "0111");
            //ChewyClass chewyobj = new ChewyClass();
            //var output = chewyobj.SumPrime(33, 3, new Dictionary<string, bool>());
            //var output = leetCodeProblems.FormLargestNumber(new int[] { 10, 2 });
            //int[][] jArray = new int[3][]{ new int[3]{1,1,1},
            //                               new int[3]{ 1,0,1},
            //                               new int[3]{1,1,1}
            //                             };
            //leetCodeProblems.SetZeroes(jArray);
            //var output = leetCodeProblems.SimplifyPath("/a/./b/../../c/");
            //var output = leetCodeProblems.PrintFromCharToZ('b');
            //var output = leetCodeProblems.ValidIPAddress("1.0.1.");
            var output = leetCodeProblems.MostCommonWord("a, a, a, a, b,b,b,c, c", new string[] { "a" });
            //var output = leetCodeProblems.WordSplit("The quick brown fox jumps over the lazy dog", 10);
            //var output = leetCodeProblems.TopKFrequent(new int[] { -1, -1 }, 1);

            #endregion

            //Console.WriteLine(output);
            Console.ReadKey();
        }

        


        public struct Student : IEnumerable
        {
            string Name;
            double Maths;
            double Physics;
            double Chemistry;
            double Total;
            double Rank;
            public Student(string name, double maths, double physics, double chemistry, double total, double rank)
            {
                this.Name = name;
                this.Maths = maths;
                this.Physics = physics;
                this.Chemistry = chemistry;
                this.Total = total;
                this.Rank = rank;
            }

            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}
