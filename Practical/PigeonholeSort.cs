namespace Algorithm_Sort.Practical
{
    public class PigeonholeExecute
    {
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 8, 159, 26, 39 };
            var execute = new PigeonholeSort<int>();
            execute.PigeonholeSorting(inputItem);
        }
    }

    /// <summary>
    /// 鴿巢排序 - Pigeon hole Sort (基數分類)
    /// Time Complex : O(n)
    ///        Space : O(k)  k => 陣列元素中的最大值-最小值
    ///    Best Time : O(n)
    ///   Worst Time : O(n)
    ///         原理 : 根據輸入的陣列中取最大值和最小值，建立一个額外空間，當計算時將值對應索引的位置+=1
    ///                最後遍歷這個額外空間(已排序完成)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PigeonholeSort<T> where T : IComparable
    {
        public List<int> PigeonholeSorting(List<int> items)
        {
            //1. 建立範圍空間
            int min = items.Min();
            int max = items.Max();
            int range = max - min + 1;
            int[] phole = new int[range];

            //2. 塞入對應的值
            for (int index = 0; index < items.Count(); index++)
                phole[items[index] - min]++;

            //3. 取出索引位置作為值的排序結果
            for (int index = 0, innerIndex = 0; innerIndex < range; innerIndex++)
                while (phole[innerIndex]-- > 0)
                    items[index++] = innerIndex + min;

            return items;
        }

    }
}
