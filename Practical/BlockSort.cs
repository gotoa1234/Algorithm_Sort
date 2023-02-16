namespace Algorithm_Sort.Practical
{
    /// <summary>
    /// 區塊排序 - Block Sort 全名(External Merge Sort)
    /// Time Complex : O(nlogn)
    ///        Space : O(1)
    ///    Best Time : O(n)
    ///   Worst Time : O(nlogn)
    ///         原理 : 一種將輸入數列，分散暫存到各個檔案中，然後各別計算完成後，在統一進行彙整
    ///                一種分散式計算的合併排序演算法，在資料量大時可以解決BigData無法一次合併完成的排序問題
    ///                情境：單一資料量超大時，一台PC只有16G記憶體，此時可以先拆成多個排序好的小檔案暫存，在讀取出來一一排序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BlockSort<T> where T : class
    {
        /// <summary>
        /// 偽代碼-區塊合併排序演算法流程
        /// </summary>
        /// <param name="inputFilePath"> 排序前輸入來源檔案位置</param>
        /// <param name="outputFilePath">排序後輸出結果檔案位置</param>
        /// <param name="blockLineSize">多個行的資料為一個區塊，預設100行</param>
        public void SudoCodeForBlockSorting(string inputFilePath, string outputFilePath, int blockLineSize = 100)
        {
            var sortedResult = new List<string>();

            // 1-1. 開始: 讀取一個檔案 or 輸入比較陣列 
            var tempBlockUnitPaths = new List<string>();
            // 設定一個保存檔案的路徑位址
            var tempBlockUnitPathTemplate = Path.GetTempFileName();
            // 1-2. 將檔案來源逐一讀取
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                int fileCount = 0;
                while (!reader.EndOfStream)
                {
                    //1-3-1. 這邊模擬讀取每行檔案，逐一排序
                    var blockUnit = new List<string>();
                    for (int loopCount = 0; loopCount < blockLineSize && !reader.EndOfStream; loopCount++)
                    {
                        blockUnit.Add(reader.ReadLine());
                    }
                    //1-3-2. 排序(C#這邊可以視為Quick Sort 時間複雜度: O(nlong) )
                    blockUnit.Sort();

                    //1-4. 保存排序的結果放到檔案中
                    string usePath = $"{tempBlockUnitPathTemplate}.{fileCount++}";
                    using (StreamWriter writer = new StreamWriter(usePath))
                    {
                        foreach (string line in blockUnit)
                        {
                            writer.WriteLine(line);
                        }
                    }
                    tempBlockUnitPaths.Add(usePath);
                }
            }

            //防呆 - 避免無資料情況
            if(!tempBlockUnitPaths.Any())
                return;

            //2.1. 再將1.步驟中分割的所有檔案合併起來，並且排序
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                //2.2. 每個資料塊從暫存檔案中逐一讀取出
                var blockReaders = new List<StreamReader>();
                foreach (string chunkPath in tempBlockUnitPaths)
                {
                    StreamReader chunkReader = new StreamReader(chunkPath);
                    blockReaders.Add(chunkReader);
                }

                //2.3-1. 依照我們切割的數量，先切割出Memory提供運算
                var buffer = new List<string>(tempBlockUnitPaths.Count);

                //2.3-2. 將值讀出放進記憶體中
                while (true)
                {
                    // Read a line from each chunk into the buffer
                    foreach (StreamReader blockReader in blockReaders)
                    {
                        buffer.Add(blockReader.ReadLine());
                    }

                    buffer.Sort();
                    if (buffer[0] == null)
                    {
                        break;
                    }
                    //2-3-3. 將排序結果匯出
                    writer.WriteLine(buffer[0]);
                    buffer.RemoveAt(0);
                }

                //2.4 釋放所有資源，並且將排序暫存的資料清空
                foreach (StreamReader blockReader in blockReaders)
                {
                    blockReader.Close();
                }
                foreach (string tempUnitPath in tempBlockUnitPaths)
                {
                    File.Delete(tempUnitPath);
                }
            }
        }
    }
}
