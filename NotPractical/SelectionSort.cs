namespace Algorithm_Sort.NotPractical
{
    public class SelectionSortExecute
    {
        /// <summary>
        /// Bogo排序執行實例: 預期回傳17, 26, 38, 39, 59, 92
        /// </summary>
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39 };
            var selectionSort = new SelectionSort<int>();
            var result = selectionSort.SelectionAscendingSort(inputItem);
        }
    }

    /// <summary>
    /// 選擇排序 -  Selection Sort
    /// Time Complex : O(n²)
    ///        Space : O(1)
    ///    Best Time : O(n²)
    ///   Worst Time : O(n²)
    ///         原理 : 泡沫排序的變形，但不用頻繁交換，每次找出最小值才做交換
    ///                雖然是時間複雜度O(n²)但效能會比泡沫好很多，因為實際交換次數為n次
    /// </summary>
    public class SelectionSort<T> where T : IComparable
    {
        /// <summary>
        /// Bogo排序 - Quantum bogodynamics / bozo sort / 猴子排序
        /// </summary>
        /// <param name="items">一串可比較的陣列 EX: [3,2,5,1,4]</param>
        /// <returns>倒序的陣列 EX: [5,4,3,2,1]</returns>
        public List<T> SelectionAscendingSort(List<T> items)
        {
            int index = 0;
            //1. 遍歷 
            for (int keyIndex = 0; keyIndex < items.Count() - 1; keyIndex++)
            {
                //2. 找出最小值 
                var minIndex = keyIndex + 1;
                for (index = keyIndex + 1; index < items.Count; index++)
                {                    
                    if (items[index].CompareTo(items[keyIndex]) < 0 &&
                        items[index].CompareTo(items[minIndex]) < 0)
                    {
                        minIndex = index;
                    }
                }
                //3. 如果當前keyIndex 已經是最小值則不用交換
                if (items[keyIndex].CompareTo(items[minIndex]) < 0)
                    continue;

                //4. 發現最小值進行minIndex 與 keyIndex交換
                var temp = items[keyIndex];
                items[keyIndex] = items[minIndex];
                items[minIndex] = temp;
            }
            return items;
        }
    }
}