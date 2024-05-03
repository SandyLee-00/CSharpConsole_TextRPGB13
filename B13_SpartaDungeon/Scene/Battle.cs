using B13_SpartaDungeon.GameObjects;
using B13_SpartaDungeon.Interfaces;
using B13_SpartaDungeon.Util;

namespace B13_SpartaDungeon;

public class Battle : IMenu
{
    public static Battle Instance { get; } = new();

    public void PrintMenu()
    {
        Console.Clear();
        CustomConsole.WriteLineWithColor("Battle!!", ConsoleColor.Red);
        Console.WriteLine();

        Monster.Generate();
        Thread.Sleep(100);
        Console.WriteLine();
    }
}