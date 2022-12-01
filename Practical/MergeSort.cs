using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Sort.Practical
{
    public class MergeSortExecute
    {
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39 };
            var execute = new MergeSort<int>();
            var result = execute.MergeAscendingSort(inputItem);
        }
    }


    /// <summary>
    /// 合併排序 - Merge Sort
    /// Time Complex : O(nlogn)
    ///        Space : O(n)
    ///    Best Time : O(nlogn)
    ///   Worst Time : O(nlogn)
    ///         原理 : 分而治之法，將陣列切割成最小的兩個陣列，然後進行排序，重組後再用這生成的陣列在
    ///           STEP 1:                     [92, 17, 38, 59, 26, 39]
    ///           STEP 2:                 [92, 17, 38]  與        [59, 26, 39]
    ///           STEP 3:             [92, 17] 與 [38]  與  [59, 26]  與  [39]
    ///           STEP 4:(排序)       [17, 92] 與 [38]  與  [26, 59]  與  [39]
    ///           STEP 5:(合併+排序)      [17, 38, 92]  與        [26, 39, 59]
    ///           STEP 6:(合併+排序)           [17, 26, 38, 39, 59, 92]
    ///           Step4開始排序時比較只要比O(1) 因為只要比1個元素，然後就可以組成最終的排序
    ///           Step5以後的兩個陣列排序最多只會耗費 O(n/2) 因為每個陣列至少有一半的值已經交換完畢
    ///           解決了當元素太多時需要不斷交換的問題，所以可以達到 O(nlog)的效能
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MergeSort<T> where T : IComparable
    {
        /// <summary>
        /// 主程式，合併排序
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<T> MergeAscendingSort(List<T> items)
        {
            if (items.Count <= 1)
                return items;
            //1. 切割一半的數量
            int mid = items.Count / 2;
            var leftItems = items.Take(mid).ToList();
            var rightItems = items.Skip(mid).Take(items.Count - mid).ToList();

            //2. 找出左邊陣列、右邊陣列的結果 (遞迴自己)
            leftItems =  MergeAscendingSort(leftItems);
            rightItems =  MergeAscendingSort(rightItems);

            //3. 將排序的結果返回
            return Sort(leftItems, rightItems);
        }

        /// <summary>
        /// 合併兩個陣列的值，並且由小到大組成回傳
        /// </summary>
        /// <returns></returns>
        private List<T> Sort(List<T> leftItems, List<T> rightItems)
        {
            var mergeSortResult = new List<T>();
            //2-1. 兩個陣列小的逐一放進結果中
            while(leftItems.Count> 0 && rightItems.Count>0)
            {
                if (leftItems[0].CompareTo(rightItems[0]) < 0)
                {
                    mergeSortResult.Add(leftItems[0]);
                    leftItems.RemoveAt(0);
                }
                else
                {
                    mergeSortResult.Add(rightItems[0]);
                    rightItems.RemoveAt(0);
                }
            }

            //跑到這必定是 rightItems.Count == 0 把剩下的值逐一丟進結果中
            if (leftItems.Count > 0)
            {
                mergeSortResult.AddRange(leftItems);
            }
            else if(rightItems.Count > 0)//跑到這必定是 leftItems.Count == 0 把剩下的值逐一丟進結果中
            {
                mergeSortResult.AddRange(rightItems);
            }

            return mergeSortResult;
        }
    }

}
