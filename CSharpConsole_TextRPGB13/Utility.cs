using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextRPG
{
    public class Utility
    {
        public static int PromptMenuChoice(int min, int max)
        {
            while (true)
            {
                Console.Write("원하시는 번호를 입력해주세요: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
            }
        }

        internal static void ShowTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(title);
            Console.ResetColor();
        }

        public static void PrintTextHighlights(string s1, string s2, string s3 = "")
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }
    }
}
