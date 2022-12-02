namespace Algorithm_Sort.Practical
{

    public class RadixSortExecute
    {
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 8, 159, 26, 39 };
            var execute = new RadixSort();
            execute.RadixAsendingSorting(inputItem);
        }
    }

    /// <summary>
    /// 基數排序 - Radix Sort 非比較型整數排序演算法，
    /// Time Complex : O(k*n)
    ///        Space : O(k+n)
    ///    Best Time : O(k*n)
    ///   Worst Time : O(k*N)
    ///         原理 : 非比較排序，找出最大值的位數，假設位數為3 個位數開始 -> 十位數 -> 百位數
    ///                每次都 %10 找到對應的桶子放進，再將桶子從最大的依序取出，重組Array
    ///                最後可以取出由小到大的排序組合。
    ///                關鍵在"位數" 每次位數放入對應的桶子時已經同時在排序了，在十位數階段個位數的值會永遠在最小的區塊。
    ///                因為十位數階段輪不到個位數去排，也相當於最小排序已完成
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public class RadixSort 
    { 
        public List<int> RadixAsendingSorting(List<int> items)
        {
            //1. 找出最大值的位數
            var radixBaseCount = GetRadixMaxBase(items.Max());
            //2. 初始化10個桶子
            var newBuckets = new List<Stack<int>>();
            for (int index = 0; index <= 9; index++)
            {
                newBuckets.Add(new Stack<int>());
            }

            int findIndex = 0;
            int multipuleValue = 1;
            //3. 重複進行Radix Sort 演算法
            while(radixBaseCount > 0)
            {
                //4. 第一次是個位數 、 第二次十位數 ...重複將值放進桶子
                for (int index = 0; index < items.Count(); index++)
                {
                    findIndex = (items[index] / multipuleValue) % 10;
                    newBuckets[findIndex].Push(items[index]);
                }
                items.Clear();
                //5 .將桶子內的值依序取出
                for(int index = newBuckets.Count -1 ; index >= 0; index--)
                {
                    while (newBuckets[index].Any())
                    {
                        items.Insert(0, newBuckets[index].Pop());
                    }
                }
                radixBaseCount--;
                multipuleValue *= 10;
            }
            return items;
        }

        /// <summary>
        /// 取得基數上限 EX: 100 是3位數
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private int GetRadixMaxBase(int item)
        {
            int resultMax = 0;
            while (item > 0)
            {
                item /= 10;
                resultMax++;
            }
            return resultMax;
        }
    }
}
