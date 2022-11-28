using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_Sort.Practical
{
    /// <summary>
    /// 執行實例: 預期回傳17, 26, 38, 39, 59, 92
    /// </summary>
    public class BucketSortExecute
    {
        public void Execute()
        { 
        
        }
    }

    /// <summary>
    /// 桶排序 - Bucket Sort
    /// Time Complex : O(n + k) k = 桶子數
    ///        Space : O(n * k)
    ///    Best Time : O(n)
    ///   Worst Time : O(n^2) ※最壞所有的值都丟入同一個桶
    ///         原理 : 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BucketSort<T> where T : IComparable
    { 
    
    }
}
