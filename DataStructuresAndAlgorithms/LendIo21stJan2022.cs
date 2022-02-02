using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{ // Interviewer Brandon Barry
    class LendIo21stJan2022
    {
		private static void Main()
		{
			void RunTests(params Expression<Action>[] expressions)
			{
				var numErrors = 0; foreach (var expression in expressions) { try { expression.Compile()(); } catch (Exception ex) { ++numErrors; Console.Error.WriteLine(((MethodCallExpression)expression.Body).Method.Name + ": " + ex.Message + Environment.NewLine); } }
				if (numErrors == 0) Console.WriteLine("All tests completed successfully"); else Console.WriteLine("" + numErrors + " error(s) ocurred");
			}

			RunTests(
				() => Test1(),
				() => Test2());
		}

		private static void Test1()
		{
			var list1 = new[] { "love", "wandering", "goofy", "sweet", "mean", "show", "fade", "scissors", "shoes", "gainful", "wind", "warn" };
			var list2 = new[] { "wacky", "fabulous", "arm", "rabbit", "force", "wandering", "scissors", "fair", "homely", "wiggly", "thankful", "ear" };

			//LongestCommonWord(list1, list2).ShouldBe("wandering");
			// if a word is there in both the list, that is the result;
		}

		private static string LongestCommonWord(IList<string> list1, IList<string> list2)
		{
			HashSet<string> set = new HashSet<string>();
			int i = 0;
			while (i < list1.Count)
			{
				if (!set.Contains(list1[i]))
				{
					set.Add(list1[i]);
				}
				i++;
			}
			i = 0;
			string result = "";
			while (i < list2.Count)
			{
				if (result == "" && set.Contains(list2[i]))
				{
					result = list2[i];
				}
				else if (result.Length < list2[i].Length && set.Contains(list2[i]))
				{
					result = list2[i];
				}
				i++;
			}
			return result;
		}





		private static void Test2()
		{
			//RotateLeft(new[] { 1, 2, 3, 4, 5 }, 2).ShouldBe(new[] { 3, 4, 5, 1, 2 });
			//RotateLeft(new[] { 1, 2, 3, 4, 5 }, 5).ShouldBe(new[] { 1, 2, 3, 4, 5 });
			//RotateLeft(new[] { 1, 2, 3, 4, 5 }, 7).ShouldBe(new[] { 3, 4, 5, 1, 2 });
		}

		private static IList<int> RotateLeft(IList<int> list, int times)
		{
			times = times % list.Count;
			List<int> result = new List<int>();
			int i = times; //2 - 
			while (i < list.Count)
			{ // 2 - last index
				result.Add(list[i]);
				//list.Remove(list[i]);
				i++;
			}
			i = 0;
			while (i < times)
			{ // 0- <2
				result.Add(list[i]);
				//list.Remove(list[i]);
				i++;
			}

			return result;
		}
	}
}
