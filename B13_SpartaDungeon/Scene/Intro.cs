using B13_SpartaDungeon.Util;

namespace B13_SpartaDungeon.Scene;

public static class Intro
{
    // 원활한 테스트를 위해 프로젝트 마무리 단계에서 호출 추가
    public static void PrintGameHeader()
    {
        CustomConsole.Clear();
        Console.CursorVisible = false;
        Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⡄⡀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡶⢣⣾⣿⣿⣿⣿⣿⣿⣿⣿");
        Console.WriteLine("⣿⣿⣿⣿⣿⣿⣟⠦⠀⢹⣀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠋⠉⠀⠀⠀⠈⠙⠛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠋⠠⢚⣿⣿⣿⣿⣿⣿⣿");
        Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣷⡄⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠋⠁⠀⠀⠀⣀⣤⡶⣦⣄⠀⠀⠀⠀⠉⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⣴⣿⣿⣿⣿⣿⣿⣿⣿");
        Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠀⠀⢀⣀⣤⡶⠛⠉⠀⠀⠀⠈⠙⠷⣶⣤⣄⡀⠈⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿");
        Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢟⣁⣠⣴⣶⣿⠿⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⢿⣶⣶⣤⣈⣛⠿⣿⣿⣿⣿⣿⣿⢸⣿⣿⣿⣿⣿⣿⣿⣿");
        Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⡿⢿⣿⣿⡿⢻⣿⡿⠿⠿⠿⠟⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠿⠿⠿⠿⠿⣿⣿⣿⣿⣿⠈⠘⣿⣿⣿⣿⣿⣿⣿");
        Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⡇⠀⣿⣿⣿⣭⣭⣭⣥⣤⣄⠀⢀⣀⡤⠤⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠤⣤⣤⣤⢄⣀⣀⣠⣤⣭⣿⣿⣿⣿⠀⠀⣿⣿⣿⣿⣿⣿⣿");
        Console.WriteLine("⣿⣿⣿⣿⣿⣿⠹⠃⠀⣿⣿⣿⣿⣿⡏⡭⠭⠭⠍⠈⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⠋⡭⣭⢽⣹⣿⣿⣿⣿⡏⠀⠀⠁⣿⣿⣿⣿⣿⣿");
        Console.WriteLine("⣿⣿⣿⣿⣿⢹⠀⠀⠀⣿⣿⣿⣿⣿⡇⣇⡋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠭⠽⢽⣸⣿⣿⣿⣿⡇⠀⠀⠀⣿⣿⣿⣿⣿⣿");
        Console.WriteLine("⣿⣿⣿⣿⣿⢸⠀⠀⠀⢿⣿⣿⣿⡿⠓⠒⠒⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠛⠛⠛⠛⢿⣿⣿⣿⡇⠀⠀⠀⡏⣿⣿⣿⡿⠛");
        Console.Write(" ⠈⣿⣿⣿⡟⠀⠀⠀⠀⢸⣿⣿⣿⣷⡀");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("⠀⠀⠀  ⠀ Sparta Dungeon⠀⠀⠀⠀");
        Console.ResetColor();
        Console.WriteLine("⠀⠀⠉⣀⡿⠛⠃⠙⡇⠀⠀⠀⠃⢹⣿⡏⠀⠀");
        Console.WriteLine(" ⡀⢹⣿⣷⠁⠀⠀⠀⠀⠘⢿⡇⠙⢿⣷⣄⠀⠀⠀⠀⠀⠀⢀⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣤⠀⠀⠀⠀⠀⠀⣤⣶⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⢾⣿⣷⡀⠀");
        Console.WriteLine(" ⠀⠈⣿⡏⠀⠀⠀⠀⠀⠀⠀⠱⠤⠈⣿⡿⣿⡄⠀⠀⠀⠀⣿⣿⣿⣶⣶⣾⣶⣶⣿⣷⣾⣿⣿⡆⠀⠀⠀⠀⣼⠋⠉⣿⡄⠀⠀⢠⡄⠀⠀⠀⠀⢠⣿⣿⠃⠀");
        Console.WriteLine(" ⠀⠀⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠟⠀⠘⡇⠀⠀⠀⠰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠈⡷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠁⠀⠀");
        Console.WriteLine(" ⠀⢠⠟⠀⠀⠀⠀⠀⠀⠰⠶⠂⠀⠀⠀⠀⠀⠃⠀⠀⠀⠀⣿⣿⣿⣿⡿⠫⣹⢹⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine(" ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⡋⠀⠀⠘⠈⠉⢙⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine(" ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⡿⠁⠀⠀⠀⡀⠀⠀⢸⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine(" ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣟⡇⠀⠀⢐⡁⠀⠀⢸⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine(" ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣧⠀⠀⠘⠃⠀⠀⣾⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
        Console.WriteLine(" ⠀⠻⣿⣿⣶⠄⠀⠀⠀⠀⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⣦⣼⣀⣾⣾⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⣠⠀⠀⠀⠀⠀⠀⠰⣿⣿⣿⡟⠀⠀");
        Console.WriteLine(" ⠀⠀⣹⣿⣏⠀⠀⠀⠀⠀⣿⡀⢰⡆⠀⠀⠀⠀⠀⠀⠀⠀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⢹⠁⠀⠀⠀⠀⠀⠀⢹⣿⣿⠁⠀⢰");
        Console.WriteLine(" ⢠⠀⢸⣿⠛⠂⠀⠀⠀⠀⠈⠉⢹⡇⠀⠀⡀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⡇⠀⠀⣸⡄⠀⠀⠀⠀⠀⠀⢸⣿⡇⠀⠀⠺");
        Console.WriteLine(" ⣸⣿⣿⣿⣄⣀⠀⠀⠀⠀⠀⠀⢸⡇⠀⢰⣷⣆⣀⣠⣼⣿⠿⠟⠛⠛⠉⠉⠛⠛⠛⠛⠛⠛⠻⢧⣀⢀⠀⠀⣼⣷⣤⣤⣿⡧⣠⣄⣴⣄⣀⡄⢸⣿⡇⠀⠀⣀");
        Console.WriteLine(" ⣿⣿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⢹⡷⠠⣾⣯⣠⣤⣤⣤⡤⠤⠤⠤⠤⠤⢤⣤⡤⠤⠤⠀⠤⠤⢤⣤⣤⣤⣤⣸⣿⣿⣿⣿⡇⠛⠛⠻⠿⠋⠀⢸⣿⡇⠀⣰⣿");
        Console.WriteLine(" ⣿⣿⣿⣿⣿⣿⣿⣶⡀⠀⢀⠀⢻⣷⡶⢸⣿⣧⣤⣤⣤⣤⣤⣤⣤⣤⣀⣀⣀⣠⣀⣀⣠⣤⣤⣤⣤⣤⣤⣼⣿⣿⡟⠁⣿⡇⠀⠀⠀⠀⢠⣶⣾⣿⣿⣿⣿⣿");
        Console.WriteLine(" ⣿⣿⣿⣿⣿⣿⠿⠿⢿⣦⣼⣶⣿⣿⣶⠄⠛⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠈⠉⠉⠉⠉⠙⠻⠿⣷⣴⣿⣷⣼⣿⣿⣧⣾⣯⣼⣿⣿⣿⣿⣿");
        Console.Write(" ⣿⣿⣿⣿⣷⣾⣷⣶⣶⣾⣿⣿⣿⣿⣿⡀");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("⠀[Press any key to play]⠀ ");
        Console.ResetColor();
        Console.WriteLine("⢸⣿⣿⣿⣿⣿⠟⠉⠉⣸⣿⣿⣿⣿⣿⣿");
        Console.WriteLine(" ⣿⣿⣿⣿⣿⣄⣴⣿⣿⣿⣿⡿⠿⠿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⣿⣿⣿⣦⣄⣠⣿⣿⣿⣿⡟⠻⣿");
        Console.WriteLine(" ⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠀⠀⣀⠒⠀⠀⠀⠀⠀⠀⠀⠉⠉⠙⠛⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿");

        Console.ReadKey(true);
    }
}