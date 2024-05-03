namespace B13_SpartaDungeon.Util;

public static class CustomConsole
{
    public const ConsoleColor PRIMARY_COLOR = ConsoleColor.White;
    public const ConsoleColor TITLE_COLOR = ConsoleColor.Red;
    public const ConsoleColor ERROR_COLOR = ConsoleColor.DarkRed;
    public const ConsoleColor NUMBER_COLOR = ConsoleColor.DarkMagenta;
    public const ConsoleColor SIGN_COLOR = ConsoleColor.DarkYellow;
    public const ConsoleColor MARK_COLOR = ConsoleColor.DarkGray;
    public const ConsoleColor ALERT_COLOR = ConsoleColor.DarkBlue;

    public static void Write(int content)
    {
        Console.ForegroundColor = NUMBER_COLOR;
        Console.Write(content);
        Console.ForegroundColor = PRIMARY_COLOR;
    }

    public static void Write(string content)
    {
        foreach (var c in content)
        {
            if (c == ' ')
            {
                Console.Write(' ');
                continue;
            }
            Console.ForegroundColor = c switch
            {
                >= '0' and <= '9' => NUMBER_COLOR,
                ':' or '.' => MARK_COLOR,
                '>' or '!' or '|' or '+' or '-' => SIGN_COLOR,
                _ => PRIMARY_COLOR,
            };
            Console.Write(c);
            Console.ForegroundColor = PRIMARY_COLOR;
        }
    }

    public static void WriteWithColor(string content, ConsoleColor consoleColor)
    {
        Console.ForegroundColor = consoleColor;
        Console.WriteLine(content);
        Console.ForegroundColor = PRIMARY_COLOR;
    }

    public static void WriteLine()
    {
        Console.WriteLine();
    }

    public static void WriteLine(int content)
    {
        Console.ForegroundColor = NUMBER_COLOR;
        Console.WriteLine(content);
        Console.ForegroundColor = PRIMARY_COLOR;
    }

    public static void WriteLine(string content)
    {
        foreach (var c in content)
        {
            if (c == ' ')
            {
                Console.Write(' ');
                continue;
            }
            Console.ForegroundColor = c switch
            {
                >= '0' and <= '9' => NUMBER_COLOR,
                ':' or '.' => MARK_COLOR,
                '>' or '!' or '|' or '+' or '-' => SIGN_COLOR,
                _ => PRIMARY_COLOR,
            };
            Console.Write(c);
            Console.ForegroundColor = PRIMARY_COLOR;
        }
        Console.WriteLine();
    }

    public static void WriteLineWithColor(string content, ConsoleColor consoleColor)
    {
        Console.ForegroundColor = consoleColor;
        Console.WriteLine(content);
        Console.ForegroundColor = PRIMARY_COLOR;
    }

    private static int GetPrintableLength(string str)
    {
        var length = 0;
        foreach (var c in str)
        {
            if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
            {
                length += 2; // 한글과 같은 넓은 문자에 대해 길이를 2로 취급
            }
            else
            {
                length += 1; // 나머지 문자에 대해 길이를 1로 취급
            }
        }

        return length;
    }

    public static string PadRightForMixedText(string str, int totalLength)
    {
        var currentLength = GetPrintableLength(str);
        var padding = totalLength - currentLength;
        return str.PadRight(str.Length + padding);
    }

    public static void ConsoleClearByLine(int lineFromBottom)
    {
        Console.SetCursorPosition(0, Console.CursorTop - lineFromBottom);
        for (var i = 0; i < Console.WindowWidth * lineFromBottom; i++)
        {
            Console.Write(' ');
        }
        Console.SetCursorPosition(0, Console.CursorTop - lineFromBottom);
    }

    public static int PromptMenuChoice(int min, int max)
    {
        var isInputCorrect = true;
        while (true)
        {
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");

            if (int.TryParse(Console.ReadLine(), out var choice) && choice >= min && choice <= max)
            {
                return choice;
            }

            if (isInputCorrect)
            {
                isInputCorrect = false;
                Console.WriteLine();
            }

            ConsoleClearByLine(3);
            WriteLineWithColor("잘못된 입력입니다.", ERROR_COLOR);
        }
    }
}