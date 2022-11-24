namespace Algorithm_Sort.Practical
{
    public class BubbleSortExecute
    {
        /// <summary>
        /// Bubble 排序執行實例: 預期回傳17, 26, 38, 39, 59, 92
        /// </summary>
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39 };
            var bubbleSort = new BubbleSort<int>();
            var result = bubbleSort.BubbleAscendingSorting(inputItem);
        }
    }

    /// <summary>
    /// 泡沫排序 - Bubble Sort
    /// Time Complex : O(n^2)
    ///        Space : O(1)
    ///    Best Time : O(n)
    ///   Worst Time : O(n^2)
    ///         原理 : 利用兩個迴圈，每次選定一個值與其他值做比對，最小的放前面，重複約 n^2 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BubbleSort<T> where T : IComparable
    {
        public List<T> BubbleAscendingSorting(List<T> items)
        {
            T temp = default;
            for (int index = 0; index < items.Count(); index++)
            {
                for (int indexSecond = index + 1; indexSecond < items.Count; indexSecond++)
                {
                    if (items[index].CompareTo(items[indexSecond]) > 0)
                    { 
                        temp = items[index];
                        items[index] = items[indexSecond];
                        items[indexSecond] = temp;
                    }
                }
            }
            return items;
        }
    }
}
