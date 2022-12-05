namespace Algorithm_Sort.Practical
{
    public class LibrarySortExecute
    {
        public void Execute()
        {
            List<int> inputItem = new() { 18, 17, 38, 59, 26, 39 };
            int peddingValue = 0;
            var librarySort = new LibrarySort<int>();
            var result = librarySort.LibraryAsecdingSoring(inputItem , peddingValue);
        }

    }
       

    /// <summary>
    /// 圖書館排序 - Library Sort
    /// Time Complex : O(nlogn)
    ///        Space : O(n)
    ///    Best Time : O(nlogn)
    ///   Worst Time : O(n²)
    ///         原理 : 插入排序的變形，原本的插入排序後需要位移，如果在插入前就先有空間的話，那就省去插入排序時的"位移"只要放進去即可
    ///                缺點是要額外的空間
    ///                演算法根據以下三個重要的步驟(出自Wiki)：
    ///                1. 二分尋找：我們在已經插入的元素中，二分尋找這個元素應該插入的位置。這可以通過線性移動到陣列的左側或右側，如果您點擊中間元素中的空格。
    ///                2. 插入: 將元素插入到正確的位置，並且通過交換把後面的元素向右移動，直到空格。
    ///                3. 重新平衡：在陣列中的每對元素之間插入空格。這需要線性時間，並且由於演算法只執行log n輪，總重新平衡只需要O（n log n）時間。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LibrarySort <T> where T : IComparable, new()
    {
        public List<T> LibraryAsecdingSoring(List<T> items, T peddingItem)
        {
            int valueCount = items.Count;
            //1. 每個元素後面插入1個空間
            for (int index = items.Count - 1; index >= 0; index--)
            {
                items.Insert(index + 1, new T());
            }

            for (int index = 1,interval = 2; interval < valueCount; interval = interval + 1 ,index++)
            {
                //2. 二分搜尋法 + 插入
                var temmp = items.Take(index * 2)
                                      .Where(item => item.CompareTo(peddingItem) > 0)
                                      .ToList();
                var findResult = items.Take(index * 2)
                                      .Where(item => item.CompareTo(peddingItem) > 0)
                                      .ToList()
                                      .BinarySearch(items[interval]);

                //4. 重新配置

            }

            items.BinarySearch(items[0]);

            return items;
        }

    }
}
