namespace Algorithm_Sort.NotPractical
{
    public class HeapSortExecute
    { 
        public void Execute()
        {
            List<int> inputItem = new() { 57, 17, 38, 59, 26, 39, 92 };
            var heapSort = new HeapSort<int>();
            var inputArray = inputItem.ToArray();
            heapSort.HeapAscendingSort(inputItem);
        }
    
    }

    /// <summary>
    /// 堆積排序 - Heap Sort - 以下為原地交換版本，不用額外空間
    /// Time Complex : O(nlogn)
    ///        Space : O(1) 
    ///    Best Time : O(nlogn)
    ///   Worst Time : O(nlogn)
    ///         原理 : 利用二元樹 index = 0 的子節點為 1, 2 而 index = 1的子節點3,4  且 index = 2 的節點為5,6 ......
    ///                每個節點視為根節點時底下的子節點都必須要小於當前根節點，否則就替換Value
    ///                Step 1. 構建Heap樹 (由高度最底層的開始往上堆積直到根)
    ///                Step 2. 由最底層開始遍歷每個節點，每個被遍歷時的節點視為"根"節點，找出比自己小的節點做替換
    ///                Step 3. 不斷重複2. 直到所有節點跑完即是排序結果
    ///         備註 : Quick sort 時間複雜度雖然輸給 Heap Sort 但Heap 最大問題在頻繁"交換"，交換對程式是一件很傷的事情
    ///                每交換一次是值與對應記憶體的位置變換，而Quick則是會進行檢核有必要時才"交換"，因此QuickSort仍會是
    ///                較快的原因
    /// </summary>
    public class HeapSort<T> where T : IComparable
    {
        /// <summary>
        /// 堆積排序由小而大 - 主函式
        /// </summary>
        public List<T> HeapAscendingSort(List<T> items)
        {
            int maxCount = items.Count;
            //1. 建構Heap樹
            for (int index = maxCount / 2 - 1; index >= 0; index--)
            {
                HeapSorting(items, maxCount, index);
            }

            //2. 遍歷所有節點，目標是根節點最小
            for (int index = maxCount - 1; index > 0; index--)
            {
                // Move current root to end
                var temp = items[0];
                items[0] = items[index];
                items[index] = temp;

                //3. 不斷交換讓根節點是最小的值
                HeapSorting(items, index, 0);
            }

            return items;
        }

        /// <summary>
        /// 堆積排序法
        /// </summary>
        /// <param name="items"></param>
        /// <param name="maxCount"></param>
        /// <param name="currentRootIndex"></param>
        private void HeapSorting(List<T> items, int maxCount, int currentRootIndex)
        {
            int rootIndex = currentRootIndex;
            int leftNode = 2 * currentRootIndex + 1;
            int rightNode = 2 * currentRootIndex + 2;

            // 探索左子節點是否更小
            if (leftNode < maxCount && items[leftNode].CompareTo(items[rootIndex]) > 0)
                rootIndex = leftNode;

            // 探索右子節點是否更小
            if (rightNode < maxCount && items[rightNode].CompareTo(items[rootIndex]) > 0)
                rootIndex = rightNode;

            // 發現更小的子節點->做交換位置
            if (rootIndex != currentRootIndex)
            {
                var swap = items[currentRootIndex];
                items[currentRootIndex] = items[rootIndex];
                items[rootIndex] = swap;

                // 因為當前根節點異動，所以連動底下子節點
                HeapSorting(items, maxCount, rootIndex);
            }
        }
    }
}
