using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringHW5
{
    class Program
    {
        static void inputOrder(out int time, out int adult, out int child)
        {
            time = 0;
            adult = 0;
            child = 0;
            string input = "";
            while (true)
            {
                Console.WriteLine("請依編號輸入時段：");
                Console.WriteLine("1.平日中午\t2.平日晚上\t3.假日中午\t4.假日晚上");
                input = Console.ReadLine();
                Console.Clear();
                try
                {
                    time = Convert.ToInt32(input);
                    if (time < 1 || time > 4) Console.WriteLine("輸入有誤唷！\n");
                    else break;
                }
                catch
                {
                    Console.WriteLine("輸入有誤唷！\n");
                }
            }
            while (true)
            {
                Console.WriteLine("請輸入大人人數：");
                input = Console.ReadLine();
                Console.Clear();
                try
                {
                    adult = Convert.ToInt32(input);
                    if (adult < 0) Console.WriteLine("輸入有誤唷！\n");
                    else break;
                }
                catch
                {
                    Console.WriteLine("輸入有誤唷！\n");
                }
            }
            while (true)
            {
                Console.WriteLine("請輸入小孩人數：");
                input = Console.ReadLine();
                Console.Clear();
                try
                {
                    child = Convert.ToInt32(input);
                    if (child < 0) Console.WriteLine("輸入有誤唷！\n");
                    else break;
                }
                catch
                {
                    Console.WriteLine("輸入有誤唷！\n");
                }
            }
        }
        static void inputDetermine(int time, int adult, int child, out int determine, out double price)
        {
            determine = 0;
            price = 0;
            string input = "";
            while (true)
            {
                Console.WriteLine("============================================================");
                Console.WriteLine("\t為您做最後的確認");
                Console.WriteLine("============================================================");
                Console.Write("您選擇的時段：");
                switch (time)
                {
                    case 1:
                        Console.WriteLine("平日中午");
                        break;
                    case 2:
                        Console.WriteLine("平日晚上");
                        break;
                    case 3:
                        Console.WriteLine("假日中午");
                        break;
                    case 4:
                        Console.WriteLine("假日晚上");
                        break;
                }
                Console.WriteLine("您的大人人數： " + adult);
                Console.WriteLine("您的小孩人數： " + child + "\n");
                calculatePrice(time, adult, child, out price);
                Console.WriteLine("總價格： " + price);
                Console.WriteLine("============================================================");
                Console.WriteLine("請依編號輸入：");
                Console.WriteLine("1.沒問題，確定交易\t2.取消交易，退回主畫面");
                input = Console.ReadLine();
                Console.Clear();
                if (input != "1" && input != "2") Console.WriteLine("輸入有誤唷！\n");
                else
                {
                    determine = Convert.ToInt32(input);
                    break;
                }
            }
        }
        static void calculatePrice(int time, int adult, int child, out double price)
        {
            price = 0;
            int priceA, priceC;
            if (time == 1)
            {
                priceA = 268;
                priceC = 120;
            }
            else
            {
                priceA = 368;
                priceC = 150;
            }

            bool isTen = false;
            if (adult + child >= 10)
            {
                Console.WriteLine("***** 10人以上打95折 *****");
                isTen = true;
            }

            int threeFree = (adult + child) / 3;
            if (threeFree > 0)
            {
                Console.WriteLine("***** 三人同行一人免費活動，共折抵 " + threeFree + " 人 *****");
            }
            for (int i = 0; i < threeFree; i++)
            {
                if (child > 0) child--;
                else adult--;
            }
            price = (adult * priceA + child * priceC) * 1.1;
            if (isTen) price = price * 0.95;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("============================================================");
                Console.WriteLine("\t歡迎來到brabrabra日本料理餐廳！");
                Console.WriteLine("============================================================");
                Console.WriteLine("本店收費方式：");
                Console.WriteLine("平日中午\t大人 268\t 小孩 120\t(+10%服務費)");
                Console.WriteLine("晚上 & 假日\t大人 368\t 小孩 150\t(+10%服務費)");
                Console.WriteLine("============================================================");
                Console.WriteLine("周年特價活動：\t三人同行，一人免費！10人以上，再打95折！");
                Console.WriteLine("============================================================");
                Console.WriteLine("\n請按 Enter 進入訂單系統");
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine("============================================================");
                Console.WriteLine("\t歡迎光臨！");
                Console.WriteLine("============================================================");

                int time, adult, child, determine;
                double price;
                while (true)
                {
                    inputOrder(out time, out adult, out child);
                    if (adult + child == 0)
                    {
                        Console.WriteLine("您輸入的人數為零，是不是哪裡輸入錯了呢？");
                        Console.WriteLine("請按 Enter 重新輸入");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        inputDetermine(time, adult, child, out determine, out price);
                        Console.Clear();
                        break;
                    }
                }

                if (determine == 1)
                {
                    Console.WriteLine("已成功交易，記得取出發票唷。");
                }
                else
                {
                    Console.WriteLine("已取消交易。");
                }
                Console.WriteLine("歡迎再次光臨。");
                Console.WriteLine("\n請按 Enter 回到主畫面");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
