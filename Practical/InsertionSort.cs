namespace Algorithm_Sort.Practical
{
    /// <summary>
    /// InsertionSort 執行實例: 預期回傳17, 26, 38, 39, 59, 92
    /// </summary>
    public class InsertionSortExecute
    {
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39 };
            var insertionSort = new InsertionSort<int>();
            var result = insertionSort.InsertionAscendingSorting(inputItem);
        }
    }

    /// <summary>
    /// 插入排序 - Insertion Sort
    /// Time Complex : O(n^2)
    ///        Space : O(1) or O(n)
    ///    Best Time : O(n)
    ///   Worst Time : O(n^2)
    ///         原理 : 遍歷n，由第2個元素(X)開始，比對前(X-1)元素，當比當前X小的值，則進行元素往前遞移 
    ///                最後排序將會由小至大
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InsertionSort<T> where T : IComparable
    {
        public List<T> InsertionAscendingSorting(List<T> items)
        {
            for (int keyIndex = 1; keyIndex < items.Count; keyIndex ++)
            {
                T keyValue = items[keyIndex];
                for (int index = keyIndex - 1; index >= 0; index--)
                {
                    if (keyValue.CompareTo(items[index]) < 0)
                    {
                        items[index + 1] = items[index];
                        items[index] = keyValue;
                    }
                    else
                        break;
                }
            }

            return items;
        }


    }
}
