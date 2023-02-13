namespace Algorithm_Sort.Practical
{
    public class LibrarySortExecute
    {
        public void Execute()
        {
            List<int> inputItem = new() { 18, 17, 38, 59, 26, 39 };
            List<int> peddingItems = new List<int>(inputItem);            
            var librarySort = new LibrarySort<int>();
            var result = librarySort.LibraryAsecdingSoring(inputItem, peddingItems);
        }
    }


    /// <summary>
    /// 圖書館排序 - Library Sort
    /// Time Complex : O(n²)
    ///        Space : O(n)
    ///    Best Time : O(n)
    ///   Worst Time : O(n²)
    ///         原理 : 插入排序的變形，原本的插入排序後需要位移，如果在插入前就先有空間的話，那就省去插入排序時的"位移"只要放進去即可
    ///                缺點是要額外的空間，但在現在實作上仍需要對額外的空間做位移
    ///                演算法根據以下三個重要的步驟(出自Wiki截錄2006年論文訊息)：
    ///                1. 二分尋找：我們在已經插入的元素中，二分尋找這個元素應該插入的位置。這可以通過線性移動到陣列的左側或右側，如果您點擊中間元素中的空格。
    ///                2. 插入: 將元素插入到正確的位置，並且通過交換把後面的元素向右移動，直到空格。
    ///                3. 重新平衡：在陣列中的每對元素之間插入空格。這需要線性時間，並且由於演算法只執行log n輪，總重新平衡只需要O（n log n）時間。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LibrarySort<T> where T : IComparable, new()
    {
        public List<T> LibraryAsecdingSoring(List<T> items, List<T> peddingItems)
        {
            //1. 插入排序法將得到的值放進額外空間 peddingItems 中
            for (int index = 0; index < items.Count(); index++)
            {
                int tempIndex = index;
                while (tempIndex > 0 && peddingItems[tempIndex - 1].CompareTo(items[index]) > 0)
                {
                    peddingItems[tempIndex] = peddingItems[tempIndex - 1];
                    tempIndex--;
                }

                peddingItems[tempIndex] = items[index];
            }           
            //2. 最後額外空間所放入的資料為排序後的結果
            return peddingItems;
        }

    }
}
