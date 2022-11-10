namespace Algorithm_Sort.NotPractical
{
    public class GnomeSortExecute
    {
        /// <summary>
        /// 侏儒排序執行實例: 預期回傳92, 59, 39, 38, 26 ,17
        /// </summary>
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39 };
            var bogoSort = new GnomeSort<int>();
            var result = bogoSort.GnomeDescendingSorting(inputItem);
        }
    }

    /// <summary>
    /// 侏儒排序 - Gnome Sort / Stupid Sort
    /// Time Complex : O(n^2)
    ///        Space : O(1)
    ///    Best Time : O(n)
    ///   Worst Time : O(n^2)
    ///         原理 : 從最小索引開始每個索引遍歷，每遍歷新的元素，就對之前已經算過的元素進行泡沫排序
    ///                直到最後一個索引時排序完成。多此一舉的作法，泡沫排序中用遍歷包裝
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GnomeSort<T> where T : IComparable
    {
        public List<T> GnomeDescendingSorting(List<T> items)
        {
            T temp;
            for (int index = 0; index < items.Count(); index++)
            {
               
                for (int innerIndex = 0; innerIndex < index + 1; innerIndex++)
                {
                    if (items[index].CompareTo(items[innerIndex]) > 0)
                    {
                        temp = items[index];
                        items[index] = items[innerIndex];
                        items[innerIndex] = temp;
                    }
                }
            }        
            return items;
        }

    }
}
