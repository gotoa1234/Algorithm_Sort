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
        /// ShellSort 排序執行實例: 預期回傳6, 17, 26, 38, 39, 41, 59, 75, 92
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
    ///         原理 : 設定一個自定義間隔數(interval)，然後數列中間隔數之間進行比較，小的進行交換
    ///                然後每次縮減間隔數，直到最後排序完成
    ///    不穩定原因：最壞的情況下，會是插入排序演算法(遍歷X 比較 X-1)，但運氣好在間隔數未縮減的情況下剛好排序完成    
    ///    演算步驟(Interval = 3 ; 總元素 = 9):    
    ///     
    ///     STEP   1:  92, 17, 38, 59, 26, 39, 41, 75, 6   => 一開始 Array[4] 與 Array[0] 比較 ，進行交換
    ///     STEP 2-1:  26, 17, 38, 59,  6, 39, 41, 75, 92  => 第二輪 Array[8] 與 Array[4] 比較，進行交換
    ///     STEP 2-2:   6, 17, 38, 59, 26, 39, 41, 75, 92  =>   繼續 Array[4] 與 Array[0] 比較，進行交換
    ///     STEP 3-1:   6, 17, 38, 59, 26, 39, 41, 75, 92  => 第三輪 gap /= 3 縮減間隔(gap = 1) 開始進行比較，此時為插入排序，遇到26插入到前方適合位置
    ///     STEP 3-2:   6, 17, 26, 38, 59, 39, 41, 75, 92  =>   繼續 39插入到合適位置  
    ///     STEP 3-3:   6, 17, 26, 38, 39, 59, 41, 75, 92  =>   繼續 41插入到合適位置
    ///     STEP 3-4:   6, 17, 26, 38, 39, 41, 59, 75, 92  =>   直到92都沒有需要插入，所以排序完成
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
}
