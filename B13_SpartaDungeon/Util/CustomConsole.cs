using B13_SpartaDungeon.Manager;
using B13_SpartaDungeon.Scene;

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

    // public static void WriteLine()
    // {
    //     Console.WriteLine();
    // }

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


    //Todo: 선택키 연속으로 눌렀을 때, 사전에 출력되는 현상 => 화면이 생성될 때 입력을 막아야 함 
    public static int PromptMenuChoice(int min, int max, string message = ChoiceMessage.BASIC)
    {
        var errorChoiceCount = 0;
        var errorCount = 0;
        var isInputError = false;

        Console.WriteLine(message);
        while (true)
        {
            if (Console.KeyAvailable)
            {
                var input = Console.ReadKey(true).KeyChar.ToString();
                if (int.TryParse(input, out var choice) && choice >= min && choice <= max)
                {
                    #region 죽은 몬스터 선택 시 에러 문구 출력

                    if (GameManager.Instance.IsScene == "battle" && Battle.Instance.IsBattleStart && choice != 0 &&
                        Battle.Instance.RandomMonsters[choice - 1].IsAlive == false)
                    {
                        if (errorChoiceCount++ > 0) continue;
                        PrintAlertMessage(AlertMessages.ERROR_INPUT);
                        continue;
                    }

                    #endregion

                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    return choice;
                }

                #region 선택지 외에 선택 시 에러 문구 출력

                if (isInputError || errorCount++ > 0 || errorChoiceCount > 0) continue;
                isInputError = true;

                PrintAlertMessage(AlertMessages.ERROR_INPUT);

                #endregion
            }
            Thread.Sleep(100);
        }
    }

    private static void PrintAlertMessage(string alertMessage, string choiceMessage = ChoiceMessage.BASIC)
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(' ');
        Console.SetCursorPosition(0, Console.CursorTop - 2);
        Console.WriteLine();
        WriteWithColor(alertMessage + AlertMessages.BLANK_LINE_COVER, COLOR_ERROR);
        Console.WriteLine();
        Console.WriteLine(choiceMessage);
        Console.SetCursorPosition(0, Console.CursorTop);
    }

    // public static void TwinkleWriteLine(string content, ConsoleColor originalColor, int twinkleCount = 3)
    // {
    //     var colors = new List<ConsoleColor>
    //     {
    //         originalColor,
    //         ConsoleColor.DarkYellow,
    //     };
    //
    //     for (var i = 0; i < twinkleCount; i++)
    //     {
    //         foreach (var color in colors)
    //         {
    //             WriteLineWithColor(content, color);
    //             Thread.Sleep(200);
    //             Clear();
    //         }
    //     }
    //     WriteLineWithColor(content, originalColor);
    // }

    public static void Clear()
    {
        Console.Clear();
        Console.WriteLine("\x1b[3J"); // 누적된 출력 내용 제거
    }
}