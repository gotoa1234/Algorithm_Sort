using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Sort.NotPractical
{
    public class QuickSortExecute
    {
        public void Execute()
        {
            List<int> inputItem = new() { 57, 17, 38, 59, 26, 39 , 92 };
            var quickSort= new QuickSort<int>();
            var inputArray = inputItem.ToArray();
            quickSort.QuickAscendingSort(inputItem, 0 , inputItem.Count() - 1);
        }
    }

    /// <summary>
    /// 快速排序 - Quick Sort - 以下為原地交換版本，不用額外空間
    /// Time Complex : O(nlogn)
    ///        Space : O(1)
    ///    Best Time : O(nlogn)
    ///   Worst Time : O(n^2)
    ///         原理 : 1. 利用一個樞紐值，每次將小於樞紐值的放左邊，大於樞紐值的放右邊
    ///                2. 然後以樞紐值切割兩邊，左、右半邊都跑1.步驟
    ///                3. 直到所有排序都由小額大返回
    /// </summary>
    public class QuickSort<T> where T : IComparable, new()
    {
        /// <summary>
        /// 快速排序由小而大
        /// </summary>
        public void QuickAscendingSort(List<T> items, int leftIndex, int rightIndex)
        {
            if (leftIndex > rightIndex)
                return;

            //比樞紐小的在左邊，大的在右邊，找出樞紐的索引位置
            int pivotIndex = Partitions(items, leftIndex, rightIndex);

            if (pivotIndex > 1)//左半邊處理 (假設pivotIndex 在最左邊則不會進入)
            {
                QuickAscendingSort(items, leftIndex, pivotIndex - 1);
            }
            if (pivotIndex + 1 < rightIndex)//右半邊處理 (假設pivotIndex 在最右邊則不會進入)
            {
                QuickAscendingSort(items, pivotIndex + 1, rightIndex);
            }
        }

        /// <summary>
        /// 切割-讓樞紐值為中心，左邊都小於樞紐，右邊都大於樞紐
        /// </summary>
        /// <returns></returns>
        private int Partitions(List<T> items, int leftIndex, int rightIndex)
        {
            //1. 每次選定最左邊的索引當樞紐值
            var pivotValue = items[leftIndex];
            while (true)
            {
                //2. 比樞紐值小 - 合法
                while (items[leftIndex].CompareTo(pivotValue) < 0)
                {
                    leftIndex++;//所以左索引往右繼續檢核
                }

                //3. 比樞紐值大 - 合法
                while (items[rightIndex].CompareTo(pivotValue) > 0)
                {
                    rightIndex--;//所以右索引往左
                }

                //4. 當前左索引仍比又索引小，表示有值要替換 (必定是items[leftIndex] 的值大於等於 items[rightIndex] 才進來if中)
                if (leftIndex < rightIndex)
                {
                    //4-1. 且兩個值非相同的情況下 EX: 10 == 10
                    if (items[leftIndex].Equals(items[rightIndex]))
                    {
                        return rightIndex;
                    }

                    //4-2. 交換-使左值恆小於右值
                    var temp = items[leftIndex];
                    items[leftIndex] = items[rightIndex];
                    items[rightIndex] = temp;
                }
                else
                {
                    //4-3. 樞紐為中心，左邊都小於樞紐，右邊都大於樞紐，所以回傳右索引值
                    return rightIndex;
                }
            }
        }
    }
}
