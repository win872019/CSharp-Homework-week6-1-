namespace 抽值日生_關程式重抽_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\temp\hw-抽值日生2.txt";       // 內容: 學生名單 
            string path2 = @"C:\temp\hw-抽值日生-list.txt";  // 內容: 記錄被抽過的


            string[] student = File.ReadAllLines(path);        // 讀取: 學生明單
            string[] finishedList = File.ReadAllLines(path2);  // 讀取: 被抽過的


            Console.WriteLine("學生名單\n");
            foreach (string stu in student)
            {
                Console.WriteLine(stu);
            }

            Random random = new Random();
            string studentOnDuty = student[random.Next(0, student.Length)];

            // 判斷抽到的index是否在記錄檔裡
            while (Array.IndexOf(finishedList, studentOnDuty) != -1)
            {
                studentOnDuty = student[random.Next(0, student.Length)];
            }
            


            File.AppendAllText(path2,studentOnDuty+ "\r\n");       // append 至記錄檔裡

            Console.WriteLine($"\n值日生 {studentOnDuty}");


            //  重要** 沒有再讀入一次append後的內容，底下讀到的會是未append前的檔案內容
            finishedList = File.ReadAllLines(path2);


            //foreach (string f in finishedList)
            //{
            //    Console.WriteLine($"finshedList = {f}");
            //}


            // Observation for 上面是否再讀入一次append後的內容 的差異
            //Console.WriteLine($"finishedList[0]={finishedList[0]}");
            //Console.WriteLine($"finishedList.Length={finishedList.Length}");


            // 記錄檔的長度 = 原名單長度時，刪除記錄檔
            // 產生新的空白記錄檔
            if (finishedList.Length % student.Length == 0)
            {
                File.Delete(path2);
                File.Create(path2);
            }


            Console.ReadKey();

        }
    }
}