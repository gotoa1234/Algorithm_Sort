namespace Algorithm_Sort.NotPractical
{
    public class StoogeSortExecute
    {
        /// <summary>
        /// Stooge 排序執行實例: 預期回傳6, 17, 26, 38, 39, 41, 59, 75, 92
        /// </summary>
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39, 41, 75, 6 };
            var stoogeSort = new StoogeSort<int>();
            var result = stoogeSort.StoogeAscendingSorting(inputItem);

        }
    }

    /// <summary>
    /// 臭皮匠排序 - Stooge Sort
    /// Time Complex : O(n²·⁷⁰⁹)
    ///        Space : O(n)
    ///    Best Time : O(n²·⁷⁰⁹)
    ///   Worst Time : O(n²·⁷⁰⁹)
    ///         原理 : 規則1 ：如果最後一個值小於第一個值，則交換這兩個數
    ///                規則2 ：如果當前集合元素數量大於等於3，依序以下順序處理
    ///                        2-1.     使用臭皮匠排序法 "排序前2/3" 的元素
    ///                        2-2.     使用臭皮匠排序法 "排序後2/3" 的元素
    ///                        2-3. 再次使用臭皮匠排序法 "排序前2/3" 的元素
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StoogeSort<T> where T : IComparable
    {
        public List<T> StoogeAscendingSorting(List<T> items)
        {
            //將排序的起訖丟入，進行排序
            return StoogeSortMethod(items, 0, items.Count() - 1);
        }

        public List<T> StoogeSortMethod(List<T> items, int startIndex, int endIndex)
        {
            //規則1. 如果最後一個值小於第一個值，則交換這兩個數
            if (items[startIndex].CompareTo(items[endIndex]) > 0)
            {
                var temp = items[startIndex];
                items[startIndex] = items[endIndex];
                items[endIndex] = temp;
            }

            //規則2. 如果當前集合元素數量大於等於3，依序以下順序處理
            if ((endIndex - startIndex) > 1)
            {
                var length = (endIndex - startIndex + 1) / 3;//索引由0開始，所以+1
                StoogeSortMethod(items, startIndex, endIndex - length);//排序前2/3
                StoogeSortMethod(items, startIndex + length, endIndex );//排序後2/3
                StoogeSortMethod(items, startIndex, endIndex - length);//排序前2/3
            }
            return items;
        }

        public void Swap(ref T valueA, ref T valueB)
        {
            var temp = valueA;
            valueA = valueB;
            valueB = temp;
        }
    }
}
