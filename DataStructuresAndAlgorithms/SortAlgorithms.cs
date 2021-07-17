using System;

namespace DataStructuresAndAlgorithms
{
    public class SortAlgorithms
    {
        /// <summary>
        /// INSERTION SORT, uses playing card strategy
        /// j is the card on your right hand, i is the cards in your left hand.
        /// j will be constant and i will be changing in the loop
        /// </summary>
        /// <param name="ArrayToSort"></param>
        public void InsertionSort(int[] ArrayToSort)
        {
            for (int j = 1; j < ArrayToSort.Length; j++)
            {
                int i = j - 1;
                int key = ArrayToSort[j];
                while (i >= 0 && ArrayToSort[i] > key)
                {
                    ArrayToSort[i + 1] = ArrayToSort[i];
                    ArrayToSort[i] = key;
                    i = i - 1;
                }
                ArrayToSort[i + 1] = key;
            }
            Console.WriteLine("\n Sorted array:\n");
            for (int k = 0; k < ArrayToSort.Length; k++)
            {

                Console.Write(ArrayToSort[k]);
                Console.Write(" ");
            }
        }

        /// <summary>
        /// SELECTION SORT, uses index of minimum element.
        /// In the second loop, compare jth element with minimum index element.
        /// </summary>
        /// <param name="ArrayToSort"></param>
        public void SelectionSort(int[] ArrayToSort)
        {
            for (int i = 0; i < ArrayToSort.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < ArrayToSort.Length; j++)
                {
                    if (ArrayToSort[j] < ArrayToSort[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = ArrayToSort[i];
                ArrayToSort[i] = ArrayToSort[minIndex];
                ArrayToSort[minIndex] = temp;
            }
            Console.WriteLine("\n Sorted array:\n");
            for (int k = 0; k < ArrayToSort.Length; k++)
            {
                Console.Write(ArrayToSort[k]);
                Console.Write(" ");
            }
        }

        /// <summary>
        /// BUBBLE SORT, outer loop will continue till length of array.
        /// Compare j th with j+1 th element and swap.
        /// </summary>
        /// <param name="ArrayToSort"></param>
        public void BubbleSort(int[] ArrayToSort)
        {
            bool Swapped = false;
            int count = 1;
            for (int i = 0; i < ArrayToSort.Length; i++)
            {
                for (int j = 0; j < ArrayToSort.Length - 1; j++)
                {
                    if (ArrayToSort[j] > ArrayToSort[j + 1])
                    {
                        int temp = ArrayToSort[j];
                        ArrayToSort[j] = ArrayToSort[j + 1];
                        ArrayToSort[j + 1] = temp;
                        Swapped = true;
                        Console.WriteLine("\n Round {0}:", count);
                        for (int k = 0; k < ArrayToSort.Length; k++)
                        {
                            Console.Write(ArrayToSort[k]);
                            Console.Write(" ");
                        }
                        count++;
                    }
                }
                if (Swapped == false) break;
            }
            Console.WriteLine("\n Sorted array:\n");
            for (int k = 0; k < ArrayToSort.Length; k++)
            {
                Console.Write(ArrayToSort[k]);
                Console.Write(" ");
            }
        }

        public int[] Exchange(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            return arr;
        }

        public void PrintArrayElements(int[] arr)
        {
            Console.WriteLine("\n Sorted array:\n");
            for (int k = 0; k < arr.Length; k++)
            {
                Console.Write(arr[k]);
                Console.Write(" ");
            }
        }

        /// <summary>
        /// Uses PIVOT element and compares to sort array elements.
        /// </summary>
        /// <param name="ArrayToSort"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public int PartitionIndex(int[] ArrayToSort, int p, int r)
        {
            int x = ArrayToSort[r];
            int i = p - 1;
            for (int j = p; j < r; j++)
            {
                if (ArrayToSort[j] < x)
                {
                    i = i + 1;
                    //int[] arr = Exchange(ArrayToSort, i, j);
                    int temp = ArrayToSort[i];
                    ArrayToSort[i] = ArrayToSort[j];
                    ArrayToSort[j] = temp;
                }
            }
            //Exchange(ArrayToSort, i + 1, r);
            int temp2 = ArrayToSort[i + 1];
            ArrayToSort[i + 1] = ArrayToSort[r];
            ArrayToSort[r] = temp2;
            return i + 1;
        }

        /// <summary>
        /// QUICK SORT, uses partition index and partitions array.
        /// </summary>
        /// <param name="ArrayToSort"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        public void QuickSort(int[] ArrayToSort, int p, int r)
        {
            if (p < r)
            {
                int q = PartitionIndex(ArrayToSort, p, r);
                QuickSort(ArrayToSort, p, q - 1);
                QuickSort(ArrayToSort, q + 1, r);
            }
        }

        public void Merge(int[] arr, int p, int q, int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] L = new int[n1];
            int[] R = new int[n2];
            for (int i = 0; i <= n1 - 1; i++)
            {
                L[i] = arr[p + i];
            }
            for (int j = 0; j <= n2 - 1; j++)
            {
                R[j] = arr[q + 1 + j];
            }
            int k = 0, l = 0;
            int m = p;
            while (k < n1 && l < n2)
            {
                if (L[k] <= R[l])
                {
                    arr[m] = L[k];
                    k++;
                }
                else
                {
                    arr[m] = R[l];
                    l++;
                }
                m++;
            }
            while (k < n1)
            {
                arr[m] = L[k];
                m++;
                k++;
            }
            while (l < n2)
            {
                arr[m] = R[l];
                m++;
                l++;
            }
        }

        /// <summary>
        /// MERGE SORT, uses merge sort recursively and finally calls merge.
        /// </summary>
        /// <param name="ArrayToSort"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        public void MergeSort(int[] ArrayToSort, int p, int r)
        {
            if (p < r)
            {
                int middleIndex = (p + r) / 2;
                MergeSort(ArrayToSort, p, middleIndex);
                MergeSort(ArrayToSort, middleIndex + 1, r);
                Merge(ArrayToSort, p, middleIndex, r);
            }
        }

        /// <summary>
        /// COUNTING SORT, uses a auxilary input array C.
        /// B is the output array.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int[] CountingSort(int[] A)
        {
            int n = A.Length;
            int[] B = new int[n];
            int[] C = new int[256];
            for (int i = 0; i < C.Length; i++)
            {
                C[i] = 0;
            }
            for (int j = 0; j < A.Length; j++)
            {
                C[A[j]] = C[A[j]] + 1;
            }
            for (int i = 1; i < C.Length; i++)
            {
                C[i] = C[i] + C[i - 1];
            }
            for (int j = A.Length - 1; j >= 0; j--)
            {
                B[C[A[j]] - 1] = A[j];
                C[A[j]] = C[A[j]] - 1;
            }
            return B;
        }

        public int RadixMaximumValueInArray(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max) max = arr[i];
            }
            return max;
        }

        public void RadixCountingSort(int[] A, int d)
        {
            int n = A.Length;
            int[] B = new int[n];
            int[] C = new int[10];
            for (int i = 0; i < C.Length; i++)
            {
                C[i] = 0;
            }
            for (int j = 0; j < A.Length; j++)
            {
                C[(A[j] / d) % 10] = C[(A[j] / d) % 10] + 1;
            }
            for (int i = 1; i < C.Length; i++)
            {
                C[i] = C[i] + C[i - 1];
            }
            for (int j = B.Length - 1; j >= 0; j--)
            {
                B[C[(A[j] / d) % 10] - 1] = A[j];
                C[(A[j] / d) % 10] = C[(A[j] / d) % 10] - 1;
            }
            for (int k = 0; k < n; k++)
            {
                A[k] = B[k];
            }
        }

        public void RadixSort(int[] ArrayToSort)
        {
            int max = RadixMaximumValueInArray(ArrayToSort);
            for (int d = 1; max / d > 0; d = d * 10)
            {
                RadixCountingSort(ArrayToSort, d);
            }
        }

        public void MaxHeapSort(int[] arr)
        {
            int length = arr.Length;
            BuildMaxHeap(arr, length);
            for (int i = length - 1; i >= 0; i--)
            {
                Exchange(arr, 0, i);
                MaxHeapify(arr, 0, i);
            }
        }

        public void MaxHeapify(int[] A, int i, int length)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < length && A[left] > A[largest])
            {
                largest = left;
            }
            if (right < length && A[right] > A[largest])
            {
                largest = right;
            }
            if (largest != i)
            {
                Exchange(A, i, largest);
                MaxHeapify(A, largest, length);
            }
        }

        public void BuildMaxHeap(int[] A, int length)
        {
            for (int i = (A.Length / 2) - 1; i >= 0; i--)
            {
                MaxHeapify(A, i, length);
            }
        }

        public void MinHeapSort(int[] A)
        {
            int length = A.Length;
            BuildMinHeap(A, length);
            for (int i = length - 1; i >= 0; i--)
            {
                Exchange(A, 0, i);
                MinHeapify(A, 0, i);
            }
        }

        public void MinHeapify(int[] A, int i, int length)
        {
            int smallest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < length && A[left] < A[smallest])
            {
                smallest = left;
            }
            if (right < length && A[right] < A[smallest])
            {
                smallest = right;
            }
            if (smallest != i)
            {
                Exchange(A, i, smallest);
                MinHeapify(A, smallest, length);
            }
        }

        public void BuildMinHeap(int[] A, int length)
        {
            for (int i = (A.Length / 2) - 1; i >= 0; i--)
            {
                MinHeapify(A, i, length);
            }
        }

        public void BucketSort(float[] arr, int size)
        {
            System.Collections.Generic.LinkedList<float>[] Bucket = new System.Collections.Generic.LinkedList<float>[size];
            for (int i = 0; i < Bucket.Length; i++)
            {
                Bucket[i] = new System.Collections.Generic.LinkedList<float>();
            }

            // size*arr[i]
            for (int i = 0; i < arr.Length; i++)
            {
                int bindex = (int)(size * arr[i]);
                Bucket[bindex].AddLast(arr[i]);
            }

            // Sort linkedlist
            for (int i = 0; i < Bucket.Length; i++)
            {
                if (Bucket[i].Count > 0)
                {
                    // Sort individual bucket
                }
            }

            // copy sorted elements to array
            int index = 0;
            for (int i = 0; i < Bucket.Length; i++)
            {
                if (Bucket[i].Count > 0)
                {
                    foreach (float x in Bucket[i])
                    {
                        arr[index] = x;
                        index++;
                    }
                }
            }
        }

        public void ShellSort(int[] arr)
        {
            int n = arr.Length;
            for (int gap = n / 2; gap > 0; gap = gap / 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int j = i;
                    int temp = arr[i];
                    while (j >= i && arr[j - gap] > temp)
                    {
                        arr[j] = arr[j - gap];
                        j = j - gap;
                    }
                    arr[j] = temp;
                }
            }
        }

        public int GetCombSortGap(int gap)
        {
            if (gap == 1)
            {
                return 1;
            }
            gap = (int)(gap / 1.3);
            return gap;
        }

        public void CombSort(int[] arr)
        {
            int gap = arr.Length;
            bool swapped = true;
            while (swapped == true || gap != 1)
            {
                gap = GetCombSortGap(gap);
                swapped = false;
                for (int i = 0; i < arr.Length - gap; i++)
                {
                    if (arr[i] > arr[i + gap])
                    {
                        Exchange(arr, i, i + gap);
                        swapped = true;
                    }
                }
            }
        }

        public void PigeonHoleSort(int[] arr)
        {
            int min = arr[0];
            int max = arr[0];
            for (int m = 0; m < arr.Length; m++)
            {
                if (arr[m] < min)
                    min = arr[m];
                if (arr[m] > max)
                    max = arr[m];
            }
            int range = max - min + 1;
            int[] PigeonHole = new int[range];
            for (int i = 0; i < PigeonHole.Length; i++)
            {
                PigeonHole[i] = 0;
            }
            for (int j = 0; j < arr.Length; j++)
            {
                PigeonHole[arr[j] - min] = PigeonHole[arr[j] - min] + 1;
            }
            int index = 0;
            for (int m = 0; m < range; m++)
            {
                while (PigeonHole[m]-- > 0)
                {
                    arr[index] = m + min;
                    index++;
                }
            }
        }

        public void CocktailSort(int[] arr)
        {
            int start = 0;
            int end = arr.Length;
            bool swapped = true;
            while (swapped == true)
            {
                swapped = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Exchange(arr, i, i + 1);
                        swapped = true;
                    }
                }
                if (swapped == false) break;

                swapped = false;
                end -= 1;
                for (int j = end - 1; j >= start; j--)
                {
                    if (arr[j] > arr[j - 1])
                    {
                        Exchange(arr, j, j - 1);
                        swapped = true;
                    }
                }
                start += 1;
            }
        }

        public void BitonicSort(int[] arr, int startIndex, int arrLength, int directionToSort)
        {
            if (arrLength > 1)
            {
                int k = arrLength / 2;
                BitonicSort(arr, startIndex, k, 1);
                BitonicSort(arr, startIndex + k, k, 0);
                BitonicMerge(arr, startIndex, arrLength, directionToSort);
            }
        }

        public void BitonicMerge(int[] arr, int startIndex, int arrLength, int directionToSort)
        {
            if (arrLength > 1)
            {
                int k = arrLength / 2;
                for (int i = startIndex; i < startIndex + k; i++)
                {
                    CompareAndSwap(arr, i, i + k, directionToSort);
                }
                BitonicMerge(arr, startIndex, k, directionToSort);
                BitonicMerge(arr, startIndex + k, k, directionToSort);
            }
        }

        public void CompareAndSwap(int[] arr, int i, int j, int directionToSort)
        {
            int d;
            if (arr[i] > arr[j])
            {
                d = 1;
            }
            else { d = 0; }
            if (directionToSort == d)
            {
                Exchange(arr, i, j);
            }
        }

        public void PanCakeSort(int[] arr)
        {
            int len = arr.Length;
            for (int i = len; i > 1; i--)
            {
                int maxIndex = findMaxIndexInArray(arr, i);
                if (maxIndex != i - 1)
                {
                    Flip(arr, maxIndex); //moving max element to front
                    Flip(arr, len - 1); // moving max element to end
                }
            }
        }

        public void Flip(int[] arr, int i)
        {
            int start = 0;
            while (start < i)
            {
                Exchange(arr, start, i);
                start++;
                i--;
            }
        }

        public int findMaxIndexInArray(int[] arr, int n)
        {
            int maxIndex = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[maxIndex] < arr[i])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public void StructureSort()
        {

        }

        public void ComputeLPS(string pat, int[] lps)
        {
            int j = 0, i = 1;
            int M = pat.Length;
            lps[0] = 0;
            while (i < M)
            {
                if (pat[i] == pat[j])
                {
                    j++;
                    lps[i] = j;
                    i++;
                }
                else
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        lps[i] = j;
                        i++;
                    }
                }
            }
        }

        public int KMPSearch(string text, string pat)
        {
            int M = pat.Length;
            int N = text.Length;
            int[] lps = new int[M];
            if (pat != "") ComputeLPS(pat, lps);
            int i = 0;
            int j = 0;
            while (i < N && j < M)
            {
                if (pat[j] == text[i])
                {
                    i++;
                    j++;
                }
                else
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            if (j == pat.Length)
            {
                return i - pat.Length;
            }
            return -1;
        }
    }
}
