using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Sort.Practical
{
    public class BubbleSortExecute
    {
        /// <summary>
        ///
        /// </summary>
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39 };
            var bubbleSort = new BubbleSort<int>();
            //var result = bubbleSort.BubbleAscendingSorting(inputItem);
        }
    }

    /// <summary>
    /// 泡沫排序 - Bubble Sort
    /// Time Complex : O(n^2)
    ///        Space : O(1)
    ///    Best Time : O(n)
    ///   Worst Time : O(n^2)
    ///         原理 : 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BubbleSort<T> where T : IComparable
    {
        public List<T> BubbleAscendingSorting(List<T> items)
        { 
            return new List<T>();
        }
    }
}
