using B13_SpartaDungeon.Manager;
using B13_SpartaDungeon.Scene.Interfaces;
using B13_SpartaDungeon.Util;

namespace B13_SpartaDungeon.Scene;

public sealed class Main : IScene
{
    public static Main Instance { get; } = new();

    public void PrintScene()
    {
        Init();

        #region 로비 씬 출력

        CustomConsole.Clear();
        Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        Console.WriteLine("이제 전투를 시작할 수 있습니다.");
        Console.WriteLine();
        CustomConsole.WriteLine("1. 상태 보기");
        CustomConsole.WriteLine("2. 전투 시작");
        Console.WriteLine();

        #endregion

        SceneAction.MainActions[CustomConsole.PromptMenuChoice(1, 2)]();
    }

    private static void Init()
    {
        GameManager.Instance.IsScene = "main";
    }
}