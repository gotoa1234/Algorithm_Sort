using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Sort.NotPractical
{
    public class SelectionSortExecute
    {
        /// <summary>
        /// Bogo排序執行實例: 預期回傳17, 26, 38, 39, 59, 92
        /// </summary>
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39 };
            var selectionSort = new SelectionSort<int>();
            var result = selectionSort.SelectionAscendingSort(inputItem);
        }
    }

    /// <summary>
    /// 選擇排序 -  Selection Sort
    /// Time Complex : O(n²)
    ///        Space : O(1)
    ///    Best Time : O(n²)
    ///   Worst Time : O(n²)
    ///         原理 : 
    ///                
    /// </summary>
    public class SelectionSort<T> where T : IComparable
    {
        /// <summary>
        /// Bogo排序 - Quantum bogodynamics / bozo sort / 猴子排序
        /// </summary>
        /// <param name="items">一串可比較的陣列 EX: [3,2,5,1,4]</param>
        /// <returns>倒序的陣列 EX: [5,4,3,2,1]</returns>
        public List<T> SelectionAscendingSort(List<T> items)
        {

            return items;
        }
    }
}