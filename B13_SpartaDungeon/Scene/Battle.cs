using B13_SpartaDungeon.GameObjects;
using B13_SpartaDungeon.Manager;
using B13_SpartaDungeon.Scene.Interfaces;
using B13_SpartaDungeon.Util;

namespace B13_SpartaDungeon.Scene;

public class Battle : IScene
{
    public static Battle Instance { get; } = new();

    private List<Monster> _monsters = null!;

    public bool IsBattleStart = false;
    public int IsBattleAttemptCount;

    public void PrintScene()
    {
        CustomConsole.Clear();
        if (!IsBattleStart && IsBattleAttemptCount == 0)
        {
            CustomConsole.TwinkleWriteLine("Battle!!", ConsoleColor.Red);
            _monsters = Monster.GetListByRandom();
        }
        else
        {
            CustomConsole.WriteLineWithColor("Battle!!", ConsoleColor.Red);
        }
        Console.WriteLine();

        Monster.Generate(_monsters);
        Console.WriteLine();

        Console.WriteLine("[내 정보]");
        CustomConsole.WriteLine(GameManager.Instance.Player.GetInfo());

        CustomConsole.WriteLine("0. 도망");
        CustomConsole.WriteLine("1. 공격");
        Console.WriteLine();

        var choice = CustomConsole.PromptMenuChoice(0, 1);

        SceneAction.BattleActions[choice]();

        Console.WriteLine();
    }

    public void BattlePlayerTurn(int monsterNumber = 0)
    {
        if (monsterNumber != 0)
        {
            GameManager.Instance.Player.Hit(ref _monsters, monsterNumber);
        }
        
        CustomConsole.Clear();
        CustomConsole.WriteLineWithColor("Battle!! - 플레이어 차례", ConsoleColor.Red);
        Console.WriteLine();

        Monster.Generate(_monsters);
        Console.WriteLine();

        Console.WriteLine("[내 정보]");
        CustomConsole.WriteLine(GameManager.Instance.Player.GetInfo());

        CustomConsole.WriteLine("0. 취소");
        Console.WriteLine();

        if (monsterNumber == 0)
        {
            for (var i = 1; i <= _monsters.Count; i++)
            {
                var number = i;
                SceneAction.BattlePlayerTurn[i] = () => BattlePlayerTurn(monsterNumber: number);
            }
        }


        var choice = CustomConsole.PromptMenuChoice(0, _monsters.Count);

        SceneAction.BattlePlayerTurn[choice]();

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