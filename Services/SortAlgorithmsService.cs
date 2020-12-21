using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ShenAlgorithms.Services
{
    public static class ArrayExt
    {
        public static T[] GetRow<T>(this T[,] array, int row)
        {
            if (!typeof(T).IsPrimitive)
                throw new InvalidOperationException("Not supported for managed types.");

            if (array == null)
                throw new ArgumentNullException("array");

            int cols = array.GetUpperBound(1) + 1;
            T[] result = new T[cols];

            int size;

            if (typeof(T) == typeof(bool))
                size = 1;
            else if (typeof(T) == typeof(char))
                size = 2;
            else
                size = Marshal.SizeOf<T>();

            Buffer.BlockCopy(array, row*cols*size, result, 0, cols*size);

            return result;
        }
   }
    public class SortAlgorithmsService
    {
        public SortAlgorithmsService()
        {            
        }
        public async Task<string> Quick_Sort(int arraySize)
        {
            var str = "";
            int[] arr = initArray(arraySize);
            PrintArr(arr);           
            
            QuickSort(ref arr, 0, arraySize);

            PrintArr(arr);
            return await Task.FromResult<string>(str);
        }
        public async Task<string> Merge_Sort(int arraySize)
        {
            var str = "";
            int[] arr = initArray(arraySize);
            PrintArr(arr);

            MergeSort(ref arr);

            PrintArr(arr);
            return await Task.FromResult<string>(str);
        }
        public async Task<string> Counting_Sort(int arraySize)
        {
            var str = "";
            int[] arr = initArray(arraySize);
            PrintArr(arr);           
            
            CountingSort(ref arr);

            PrintArr(arr);
            return await Task.FromResult<string>(str);
        }
        public async Task<string> Shaker_Sort(int arraySize)
        {
            var str = "";
            int[] arr = initArray(arraySize);
            PrintArr(arr);           
            
            ShakerSort(ref arr);

            PrintArr(arr);
            return await Task.FromResult<string>(str);
        }
        private void QuickSort(ref int[] arr, int begin, int end)
        {
            if(begin < end)
            {
                int compareItem = arr[begin];
                int i = begin + 1;
                int temp;
                for(int j = begin + 1; j < end; j++)
                {
                    if(arr[j] <= compareItem)
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                        i++;
                    }
                }
                
                    temp = arr[i - 1];
                    arr[i - 1] = arr[begin];
                    arr[begin] = temp;
                
                QuickSort(ref arr , begin, i - 1);
                QuickSort(ref arr, i, end);
            }
        }

        public async Task<string> GetMediannlogn(int arraySize)
        {
            var str = "";
            int[] arr = initArray(arraySize);
            PrintArr(arr);           
            
            QuickSort(ref arr, 0, arraySize);

            var median = GetMediannlogn(ref arr);
            str += $"{JsonConvert.SerializeObject(arr)}";
            str += $"median: {median}";
            PrintArr(arr);
            return await Task.FromResult<string>(str);
        }
        private int GetMediannlogn(ref int[] arr)
        {
            if(arr.Length % 2 == 1)
            {
                return arr[arr.Length/2];
            }
            else
            {
                var left = arr[arr.Length / 2 - 1];
                var right = arr[arr.Length / 2];
                return (left + right) / 2;
            }
        }
        public async Task<string> GetMedianOn(int arraySize)
        {
            var str = "";
            int[] arr = initArray(arraySize);
            PrintArr(arr);

            var median = GetMedianOn(ref arr);

            str += $"{JsonConvert.SerializeObject(arr)}";
            str += $"median: {median}";
            PrintArr(arr);
            return await Task.FromResult<string>(str);
        }
        private int GetMedianOn(ref int[] arr)
        {
            if(arr.Length % 2 == 1)
            {
                return quickselect(ref arr, arr.Length/2);
            }
            else
            {
                var left = quickselect(ref arr, arr.Length / 2 - 1);
                var right = quickselect(ref arr, arr.Length / 2);
                return (left + right) / 2;
            }
        }
        private int quickselect(ref int[] arr, int k)
        {
            if(arr.Length == 1)
            {
                return arr[k];
            }
            var pivot = pivot_fn(ref arr);

            int[] lows = new int[0];
            int[] hights = new int[0];
            int[] pivots = new int[0];

            lows = Array.FindAll(arr, p => p < pivot);
            hights = Array.FindAll(arr, p => p > pivot);
            pivots = Array.FindAll(arr, p => p == pivot);

            if(k < lows.Length)
            {
                return quickselect(ref lows, k);
            }
            else if(k < lows.Length + pivots.Length)
            {
                return pivots[0];
            }
            else
            {
                return quickselect(ref hights, k - lows.Length - pivots.Length);
            }
        }
        public async Task<string> GetMedian5(int arraySize)
        {
            var str = "";
            int[] arr = initArray(arraySize);
            PrintArr(arr);

            var median = median5median(ref arr);

            str += $"{JsonConvert.SerializeObject(arr)}";
            str += $"median: {median}";
            PrintArr(arr);
            return await Task.FromResult<string>(str);
        }
        private int median5median(ref int[] arr)
        {
            var chunkedArrays = chunked(ref arr);
            SortGroups(ref chunkedArrays);
            var medians = getMediansFromChunkedArrays(ref chunkedArrays);
            var median = quickselect(ref medians, medians.Length/2);
            return median;
        }
        private int[] getMediansFromChunkedArrays(ref int[,] arrays)
        {
            var numberOfColumns = arrays.Length / 5;
            int[] result = new int[numberOfColumns];
            for(int i = 0; i < numberOfColumns; i++)
            {
                result[i] = arrays[i,2];
            }
            return result;
        }
        private int[,] chunked(ref int[] arr)
        {
            var groupsCount = arr.Length / 5;
            var chunkedArray = new int[groupsCount, 5];
            for(int i = 0; i < arr.Length; i++)
            {
                var groupNumber = i / 5;
                var itemNumber = i % 5;
                chunkedArray[groupNumber, itemNumber] = arr[i];
            }
            return chunkedArray;
        }
        private void SortGroups(ref int[,] groups)
        {
            for(int i = 0; i < groups.Length/5; i++)
            {
                var subArr = groups.GetRow(i).OrderBy(p => p).ToArray();
                for(int j = 0; j < 5; j++)
                {
                    groups[i,j] = subArr[j];
                }
            }
        }
        private int pivot_fn(ref int[] arr)
        {
            var rand = new Random();
            var min = arr.Min();
            var max = arr.Max();
            var value = rand.Next(min, max + 1);
            return value;
        }
        private void MergeSort(ref int[] arr)
        {
            if(arr.Length > 1)
            {
                int leftCount = arr.Length/2;
                int rightCount = arr.Length - leftCount;

                int[] leftArray = new int[leftCount];
                int[] rightArray = new int[rightCount];

                Array.Copy(arr, 0, leftArray, 0, leftCount);
                Array.Copy(arr, leftCount, rightArray, 0, rightCount);

                MergeSort(ref leftArray);
                MergeSort(ref rightArray);
                arr = Merge(leftArray, rightArray);
            }
        }
        private int[] Merge(int[] leftArr, int[] rightArr)
        {
            int[] merge = new int[leftArr.Length + rightArr.Length];
            int i = 0, j = 0, k = 0;
            while(i < leftArr.Length && j < rightArr.Length)
            {
                if(leftArr[i] <= rightArr[j])
                {
                    merge[k] = leftArr[i];
                    i++;
                }
                else
                {
                    merge[k] = rightArr[j];
                    j++;
                }
                k++;
            }
            while(i < leftArr.Length)
            {
                merge[k] = leftArr[i];
                i++;
                k++;
            }
            while(j < rightArr.Length)
            {
                merge[k] = rightArr[j];
                j++;
                k++;
            }
            return merge;
        }
        private void CountingSort(ref int[] arr)
        {
            int maxElement = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i]>maxElement)
                    maxElement = arr[i];
            }
            int[] C = new int[maxElement + 1];
            for(int i = 0; i < C.Length; i++)
                C[i] = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                C[arr[i]]++;
            }
            int mainArrCounter = 0;
            for(int i = 1; i < C.Length; i++)
                for(int j = 0; j < C[i]; j++)
                {
                    arr[mainArrCounter++] = i;
                }
        }
        private void ShakerSort(ref int[] arr)
        {
            int leftMark = 0;
            int rightMark = arr.Length - 1;
            bool swapFlag = false;
            int temp = 0;
            while(leftMark < rightMark)
            {

                for(int i = rightMark; i > leftMark; i--)
                {
                    if(arr[i-1] > arr[i])
                    {
                        swapFlag = true;
                        temp = arr[i-1];
                        arr[i-1] = arr[i];
                        arr[i] = temp;
                    }
                }
                leftMark++;
                for(int i = leftMark; i <= rightMark; i++)
                {
                    if(arr[i-1] > arr[i])
                    {
                        swapFlag = true;
                        temp = arr[i-1];
                        arr[i-1] = arr[i];
                        arr[i] = temp;
                    }
                }
                rightMark--;
                if(!swapFlag)
                    break;
            }
        }
        private void PrintArr(int[] Arr)
        {
            var arraySize = Arr.Length;
            for (int i = 0; i < arraySize; i++)
            {
                Console.Write(Arr[i] + " ");
            }
            Console.WriteLine();
        }
        private int[] initArray(int len)
        {
            int[] Array = new int[len];
            Random myRand = new Random();
            int i = 0;
            int count = 0;
            int temp = 0;

            int j = 0;
            for (i = 0; i < len; i++)
            {
                temp = myRand.Next(1, len + 1);
                j = 0;
                while (j < count)
                {
                    if (Array[j] == temp)
                    {
                        temp = myRand.Next(1, len + 1);
                        j = -1;
                    }
                    j++;
                }
                Array[i] = temp;
                count++;
            }
            return Array;
        }
    }
}