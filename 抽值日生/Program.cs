namespace 抽值日生
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\temp\hw-抽值日生.txt";

            string[] student = File.ReadAllLines(path);
            foreach (string stu in student)
            {
                Console.WriteLine(stu);
            }

            string[] finishedList = new string[student.Length];
            string studentOnDuty="";
            int num,i,count=0;
            string input;
            Random random = new Random();

            Console.WriteLine("\n準備抽取值日生，如要終止程式，請輸入e\n");
            
            //抽取值日生
            while (true)
            {
                Console.Write("輸入n，開始抽取值日生：");
                input = Console.ReadLine();
                if (input == "n")
                {
                    if(count%finishedList.Length==0)
                    {
                        count = 0;
                        for (i=0;i< finishedList.Length;i++)
                        {
                            finishedList[i] = null;
                        }
                    }

                    num = random.Next(0, student.Length);
                    studentOnDuty = student[num];

                    //檢查是否已抽過
                    while (finishedList[0] != null && Array.IndexOf(finishedList, student[num]) != -1)
                    {
                        num = random.Next(0, student.Length);
                        studentOnDuty = student[num];
                    }
                    finishedList[count]= student[num];
                    count++;

                    Console.WriteLine($"值日生是 {studentOnDuty}\n");

                }else if (input == "e")
                {
                    break;
                }


            }
            Console.WriteLine("---Good Bye---");
            Console.ReadKey();
        }

    }
}