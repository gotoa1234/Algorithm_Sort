namespace Algorithm_Sort.Practical
{
    /// <summary>
    /// 執行實例: 預期回傳17, 26, 38, 39, 59, 92
    /// </summary>
    public class BucketSortExecute
    {
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39 };
            var execute = new BucketSort<int>();
            execute.BuckAscendingSorting(inputItem);
        }
    }

    /// <summary>
    /// 桶排序 - Bucket Sort 
    ///   注意 => k = 桶子數
    /// Time Complex : O(n + k) 
    ///        Space : O(n * k)
    ///    Best Time : O(n)
    ///   Worst Time : O(n^2) ※最壞所有的值都丟入同一個桶
    ///         原理 : 自行定義"桶子的數量" 、"桶子內的區間"，然後將值放進對應的桶子內
    ///                桶子內在各自排序(Quick sort 每個約 O(nlogn) )，然後在將排序結果組成
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BucketSort<T> where T : IComparable, IConvertible
    {
        private readonly static int _bucketCount = 10;

        public List<T> BuckAscendingSorting(List<T> items)
        {
            //1. 決定每個桶子放的區間
            var min = (dynamic)items.Min();
            var bucketSize = GetRegionSize(ref items);
            var buckets = new List<List<T>>();
            for (int index = 0; index < _bucketCount; index++)
                buckets.Add(new List<T>());
            //2. 將所有值放進對應的桶子內
            for (int index = 0; index < items.Count; index++)
            {
                var value = Convert.ToInt32(items[index]) - min;
                var putIndex = (value / bucketSize - 1) < 0 ? 0 : (value / bucketSize - 1);
                buckets[putIndex].Add(items[index]);
            }
            //3. 所有桶子內排序 + 組成所有桶子排序後的結果
            items.Clear();
            foreach (var bucketItem in buckets)
            {
                //Quick sort 排序每個桶子 耗費 O( k * nlogn)
                bucketItem.Sort();
                items.AddRange(bucketItem);
            }
            return items;
        }

        private int GetRegionSize(ref List<T> items)
        {
            try
            {
                var max = items.Max();
                var min = items.Min();
                return ((dynamic)max - (dynamic)min) / _bucketCount;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
