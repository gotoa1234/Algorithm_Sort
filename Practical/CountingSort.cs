namespace Algorithm_Sort.Practical
{
    public class CountingSortExecute
    {
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39 };
            var execute = new CountingSort();
            execute.CountingAsedingSort(inputItem);
        }
    }


    /// <summary>
    /// 計數排序 - Counting Sort  其中 k 是元素最大值的空間
    /// EX: [1,57, 49, 99] 在這個陣列中99就是額外空間k 
    /// Time Complex : O(n+k)
    ///        Space : O(n+k)
    ///    Best Time : O(n+k)
    ///   Worst Time : O(n+k)
    ///         原理 : 不需要排序的一種排序，先找出陣列中最大值，然後得到一組空間Space，遍歷該陣列，將值放入對應的Space[Index] 中累進+1
    ///                最後再遍歷Space全部，由小到大有多少計數就添加該索引到結果中。
    /// </summary>
    public class CountingSort
    {
        public List<int> CountingAsedingSort(List<int> items)
        {
            int maxValue = (dynamic)items.Max() + 1;

            //1. 配置元素最大值的空間 O(k)
            var extraSpace = new List<int>();
            for (int index = 0; index < maxValue; index++)
            {
                extraSpace.Add(0);
            }

            //2. 遍歷找出空間 O(n)
            for (int index = 0; index < items.Count; index++)
            {
                extraSpace[items[index]] += 1;
            }

            //3. 將值組成最後的結果由小到大
            items.Clear();
            for (int index = 0; index < extraSpace.Count; index++)
            {
                while (extraSpace[index] > 0)
                {
                    items.Add(index);
                    extraSpace[index]--;
                }
            }
            return items;
        }
    }
}
