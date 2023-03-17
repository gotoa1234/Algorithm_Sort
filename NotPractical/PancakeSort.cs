#pragma warning disable CS8604 // 可能有 Null 參考引數。
namespace Algorithm_Sort.NotPractical
{
    public class PancakeSortExecute
    { 
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39 };            
            var pancakeSort = new PancakeSort<int>();
            var result = pancakeSort.PancakeAscendingSorting(inputItem);
        }
    }

    /// <summary>
    /// 煎餅排序 - PanCake Sort
    /// Time Complex : O(n²)
    ///        Space : O(1)
    ///    Best Time : O(n²)
    ///   Worst Time : O(n²)
    ///         原理 : Step1: 每次找出最大的值
    ///                Step2: 將最大的值放在最後面
    ///                Step3: 將剩下的值再重複 Step1 ~ Step2 直到全部跑過一次
    ///                Step4: 結果就是排序由小到大
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PancakeSort<T>
    {
        public List<T> PancakeAscendingSorting(List<T> items)
        {            
            //1. 翻滾所有的煎餅 O(N)
            for (int index = items.Count -1 ; index >= 0; index--)
            {
                //轉回Count
                var count = index + 1;
                //每次取當前全部可翻滾的項目 (每次都會把一個最大的值放在最後面)
                var findMaxIndex = items.IndexOf(items.Take(count).Max());
                var findMaxIndexCount = findMaxIndex + 1;

                //2. 從起點到最大的煎餅翻滾(反轉) => O(N/2)
                items.Reverse(0, findMaxIndexCount);
                //3. 再翻滾(反轉)當前全部可翻滾的項目 => O(N/2)
                items.Reverse(0, count);
            }
            //4. 最後將會得到由小到大的排序結果
            return items;
        }
    }
}
