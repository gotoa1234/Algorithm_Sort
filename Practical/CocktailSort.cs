namespace Algorithm_Sort.Practical
{
    /// <summary>
    /// 執行實例: 預期回傳17, 26, 38, 39, 59, 92
    /// </summary>
    public class CocktailSortExecute
    {
        public void Execute()
        {
            List<int> inputItem = new() { 92, 17, 38, 59, 26, 39 };
            var cocktailSort = new CocktailSort<int>();
            var result = cocktailSort.CocktailAscsendingSorting(inputItem);
        }
    }

    /// <summary>
    /// 雞尾酒排序 - Cocktail Sort (攪拌排序)
    /// Time Complex : O(n^2)
    ///        Space : O(1)
    ///    Best Time : O(n)
    ///   Worst Time : O(n^2)
    ///         原理 : 像是攪拌依一樣，由最左再往最右邊，並且依照以下規則
    ///                1. 往右時，將最大值放到最右邊，並且最右上限-1
    ///                2. 然後再往左，將最小值放到最左邊，並且最左上限+1
    ///                3. 重複1、2直到左與右距離等於1 ，表示跑完
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CocktailSort<T> where T : IComparable
    {
        public List<T> CocktailAscsendingSorting(List<T> items)
        { 
            int right = items.Count - 1;
            int left = 0;
            T temp;
            while (left < right)
            {
                //往右 - 取大
                for (int index = left; index < right; index++)
                {
                    if (items[index].CompareTo(items[index + 1]) > 0)
                    {
                        temp = items[index];
                        items[index] = items[index + 1];
                        items[index + 1] = temp;
                    }
                
                }
                right--;
                //往左 - 取小
                for (int index = right; index > left; index--)
                {
                    if (items[index].CompareTo(items[index - 1]) < 0)
                    {
                        temp = items[index];
                        items[index] = items[index - 1];
                        items[index - 1] = temp;
                    }
                }
                left++;
            }
            return items;
        }
    }
}
