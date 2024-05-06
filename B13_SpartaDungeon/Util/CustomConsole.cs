namespace B13_SpartaDungeon.Util;

public static class CustomConsole
{
    public const ConsoleColor COLOR_PRIMARY = ConsoleColor.White;
    public const ConsoleColor COLOR_TITLE = ConsoleColor.Red;
    public const ConsoleColor COLOR_ERROR = ConsoleColor.DarkRed;
    public const ConsoleColor COLOR_NUMBER = ConsoleColor.DarkMagenta;
    public const ConsoleColor COLOR_SIGN = ConsoleColor.DarkYellow;
    public const ConsoleColor COLOR_MARK = ConsoleColor.DarkGray;
    public const ConsoleColor COLOR_ALERT = ConsoleColor.DarkBlue;

    public static void Write(int content)
    {
        Console.ForegroundColor = COLOR_NUMBER;
        Console.Write(content);
        Console.ForegroundColor = COLOR_PRIMARY;
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
                >= '0' and <= '9' => COLOR_NUMBER,
                ':' or '.' => COLOR_MARK,
                '>' or '!' or '|' or '+' or '-' => COLOR_SIGN,
                _ => COLOR_PRIMARY,
            };
            Console.Write(c);
            Console.ForegroundColor = COLOR_PRIMARY;
        }
    }

    public static void WriteWithColor(string content, ConsoleColor consoleColor)
    {
        Console.ForegroundColor = consoleColor;
        Console.Write(content);
        Console.ForegroundColor = COLOR_PRIMARY;
    }

    public static void WriteLine()
    {
        Console.WriteLine();
    }

    public static void WriteLine(int content)
    {
        Console.ForegroundColor = COLOR_NUMBER;
        Console.WriteLine(content);
        Console.ForegroundColor = COLOR_PRIMARY;
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
                >= '0' and <= '9' => COLOR_NUMBER,
                ':' or '.' => COLOR_MARK,
                '>' or '!' or '|' or '+' or '-' => COLOR_SIGN,
                _ => COLOR_PRIMARY,
            };
            Console.Write(c);
            Console.ForegroundColor = COLOR_PRIMARY;
        }
        Console.WriteLine();
    }

    public static void WriteLineWithColor(string content, ConsoleColor consoleColor)
    {
        Console.ForegroundColor = consoleColor;
        Console.WriteLine(content);
        Console.ForegroundColor = COLOR_PRIMARY;
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

    public static void ClearCurrentConsoleLine()
    {
        var currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

    public static int PromptMenuChoice(int min, int max)
    {
        var errorCount = 0;
        var isInputError = false;

        Console.WriteLine("원하시는 행동을 입력해주세요.");

        while (true)
        {
            var input = Console.ReadKey(true).KeyChar.ToString();
            if (int.TryParse(input, out var choice)
                && choice >= min && choice <= max)
            {
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                return choice;
            }

            if (isInputError || errorCount++ >= 1) continue;
            isInputError = true;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(' ');
            Console.SetCursorPosition(0, Console.CursorTop - 2);
            Console.WriteLine();
            WriteWithColor(AlertMessage.ERROR_INPUT + AlertMessage.BLANK_LINE_COVER, COLOR_ERROR);
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }

    //Todo: 선택키 연속으로 눌렀을 때, 오랫동안 반복되는 현상
    public static void TwinkleWriteLine(string content, ConsoleColor originalColor, int twinkleCount = 3)
    {
        var colors = new List<ConsoleColor>
        {
            originalColor,
            ConsoleColor.DarkYellow,
        };

        for (var i = 0; i < twinkleCount; i++)
        {
            foreach (var color in colors)
            {
                WriteLineWithColor(content, color);
                Thread.Sleep(200);
                Clear();
            }
        }
        WriteLineWithColor(content, originalColor);
    }

    public static void Clear()
    {
        Console.Clear();
        Console.WriteLine("\x1b[3J"); // 누적된 출력 내용 제거
    }
}