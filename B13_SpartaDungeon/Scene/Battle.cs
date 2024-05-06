using B13_SpartaDungeon.GameObjects;
using B13_SpartaDungeon.Manager;
using B13_SpartaDungeon.Scene.Interfaces;
using B13_SpartaDungeon.Util;

namespace B13_SpartaDungeon.Scene;

public class Battle : IScene
{
    public static Battle Instance { get; } = new();

    private List<Monster> _monsters = null!;

    public void PrintScene()
    {
        #region 전투 씬 출력 부분

        CustomConsole.ClearVisibleRegion();
        CustomConsole.TwinkleWriteLine("Battle!!", ConsoleColor.Red);
        Console.WriteLine();

        _monsters = Monster.GetListByRandom();
        Monster.Generate(_monsters, false);
        Console.WriteLine();

        Console.WriteLine("[내 정보]");
        CustomConsole.WriteLine(GameManager.Instance.Player.GetInfo());

        #endregion

        var choice = CustomConsole.PromptMenuChoice(0, 1);

        SceneAction.BattleActions[choice]();

        Console.WriteLine();
    }

    public void BattlePlayerTurn()
    {
        #region 전투 씬(플레이어 공격 차례) 출력 부분

        CustomConsole.ClearVisibleRegion();
        CustomConsole.WriteLineWithColor("Battle!!", ConsoleColor.Red);
        Console.WriteLine();

        Monster.Generate(_monsters, true);
        Console.WriteLine();

        Console.WriteLine("[내 정보]");
        CustomConsole.WriteLine(GameManager.Instance.Player.GetInfo());

        #endregion

        var choice = CustomConsole.PromptMenuChoice(0, 0);

        SceneAction.BattleActions[choice]();

        Console.WriteLine();
    }

    public void BattleMonsterAttack()
    {
    }

    public void BattleResultPlayerWin()
    {
    }

    public void BattleResultPlayerLose()
    {
    }
}