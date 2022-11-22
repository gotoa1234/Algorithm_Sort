namespace Algorithm_Sort.NotPractical
{
    public class BogoSortExecute
    {
        /// <summary>
        /// Bogo排序執行實例: 預期回傳17, 26, 38, 39, 59, 92
        /// </summary>
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39 };
            var bogoSort = new BogoSort<int>();
            var result = bogoSort.BogoSorting(inputItem);
        }
    }

    /// <summary>
    /// Bogo排序 - Quantum bogodynamics / bozo sort / 猴子排序
    /// Time Complex : O(n - n!)
    ///        Space : O(n)
    ///    Best Time : O(n)
    ///   Worst Time : 無限
    ///         原理 : 交給上帝，每次排序都是隨機，直到隨機到排序正確(升 or 降)為止
    ///                運氣好不用排序 O(n) 結束，運氣不好無限大
    /// </summary>
    public class BogoSort<T> where T : IComparable
    {
        /// <summary>
        /// Bogo排序 - Quantum bogodynamics / bozo sort / 猴子排序
        /// </summary>
        /// <param name="items">一串可比較的陣列 EX: [3,2,5,1,4]</param>
        /// <returns>倒序的陣列 EX: [5,4,3,2,1]</returns>
        public List<T> BogoSorting(List<T> items)
        {
            while (!IsDescendingSort(ref items))
            {
                Shuffle(ref items);
            }
            return items;
        }

        /// <summary>
        /// 洗牌-O(N)
        /// </summary>
        private static void Shuffle(ref List<T> items)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            for (int index = 0; index < items.Count - 1; index++)
            {
                //Swap
                int valA = random.Next(0, items.Count);
                int valB = new Random(random.Next(0, 1000)).Next(0, items.Count);
                T temp = items[valA];
                items[valA] = items[valB];
                items[valB] = temp;
            }
        }

        /// <summary>
        /// 是否為降序排序 Descending
        /// </summary>
        /// <returns></returns>
        private static bool IsDescendingSort(ref List<T> items)
        {
            for (int index = 0; index < items.Count - 1; index++)
            {
                if (items[index].CompareTo(items[index + 1]) > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
