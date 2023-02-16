using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Sort.NotPractical
{
    public class ShellSortExecute
    {
        /// <summary>
        /// Stooge 排序執行實例: 預期回傳6, 17, 26, 38, 39, 41, 59, 75, 92
        /// </summary>
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39, 41, 75, 6 };
            var shellSort = new ShellSort<int>();
            var result = shellSort.ShellSorting(inputItem);

        }
    }

    /// <summary>
    /// 希爾排序 - ShellSort  (遞減增量排序演算法)
    /// Time Complex : O(nlong) ~ O(n²)
    ///        Space : O(1)
    ///    Best Time : O(nlong)
    ///   Worst Time : O(n²)
    ///         原理 : 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ShellSort<T> where T : IComparable
    {
        public List<T> ShellSorting(List<T> items)
        {
            int interval = 3;
            int gap = items.Count() / interval > 1 ? interval + 1
                                                   : 1;
            while (gap >= 1)
            {
                for (int index = gap; index < items.Count(); index++)
                {
                    for (int compareIndex = index; 
                        gap <= compareIndex && items[compareIndex].CompareTo(items[compareIndex-gap]) < 0; 
                        compareIndex = compareIndex - gap
                        )
                    {
                        // 交換元素位置
                        T temp = items[compareIndex];
                        items[compareIndex] = items[compareIndex - gap];
                        items[compareIndex - gap] = temp;
                    }
                }
                gap /= interval;
            }
            return items;
        }
    }

//    int n = arr.Length;

//    // 選擇希爾序列
//    int gap = 1;
//    while (gap<n / 3)
//    {
//        gap = 3 * gap + 1;
//    }

//while (gap >= 1)
//{
//    for (int i = gap; i < n; i++)
//    {
//        for (int j = i; j >= gap && arr[j] < arr[j - gap]; j -= gap)
//        {
//            // 交換元素位置
//            int temp = arr[j];
//            arr[j] = arr[j - gap];
//            arr[j - gap] = temp;
//        }
//    }
//    gap /= 3;
//}
}
