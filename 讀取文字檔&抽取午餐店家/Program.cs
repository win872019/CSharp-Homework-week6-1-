namespace 讀取文字檔_抽取午餐店家
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Chung\Desktop\C# Courses\C# homework\week6-hw-檔案處理\hw-txt文字檔\restaurant.txt";

            string restaurant = File.ReadAllText(path);
            string[] list = restaurant.Split("\n");

            Random rand = new Random();
            int chosenNum = rand.Next(0, 10);
            string chosenRestaurant = "";

            //刪除顯示編號
            if (chosenNum < 9)
            {
                chosenRestaurant = list[chosenNum].Remove(0, 2);
            }
            else if (chosenNum >= 9)
            {
                chosenRestaurant = list[chosenNum].Remove(0, 3);
            }

            Console.WriteLine($"~店家名單~\n\n{restaurant}");
            Console.WriteLine($"\n今天中午吃 {chosenRestaurant}");
            Console.ReadKey();



        }
    }
}