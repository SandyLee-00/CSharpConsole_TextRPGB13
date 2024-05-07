using B13_SpartaDungeon.GameObjects;
using B13_SpartaDungeon.Manager;
using B13_SpartaDungeon.Scene.Interfaces;
using B13_SpartaDungeon.Util;

namespace B13_SpartaDungeon.Scene;

public class Battle : IScene
{
    public static Battle Instance { get; } = new();

    public List<Monster> RandomMonsters = new(capacity: 4);

    public bool IsBattleStart = false;
    public int IsBattleAttemptCount;

    private int _playerAttackDamage;
    public int PlayerOriginalHp;

    public void PrintScene()
    {
        Init();

        #region 전투 씬 출력

        CustomConsole.Clear();
        CustomConsole.WriteLineWithColor("Battle!!", CustomConsole.COLOR_TITLE);
        Console.WriteLine();

        RandomMonsters = Monster.GetListByRandom();

        Monster.Generate(RandomMonsters);
        Console.WriteLine();
        Console.WriteLine("[내 정보]");
        CustomConsole.WriteLine(GameManager.Instance.Player.GetInfo());
        CustomConsole.WriteLine("0. 도망");
        CustomConsole.WriteLine("1. 공격");
        Console.WriteLine();

        #endregion

        SceneAction.BattleActions[CustomConsole.PromptMenuChoice(0, 1)]();

        Console.WriteLine();
    }

    public void PlayerAttackTurn(int monsterIndex = 0)
    {
        if (monsterIndex == 0)
        {
            for (var i = 1; i <= RandomMonsters.Count; i++)
            {
                var index = i;
                SceneAction.BattlePlayerTurn[i] = () => PlayerAttackTurn(monsterIndex: index);
            }
        }
        else
        {
            GameManager.Instance.Player.Hit(ref RandomMonsters, monsterIndex, ref _playerAttackDamage);
            var monsterDeathCount = RandomMonsters.Count(monster => !monster.IsAlive);
            if (monsterDeathCount == RandomMonsters.Count)
            {
                BattleResultPlayerWin();
            }
            PlayerAttackInfo(monsterIndex);
        }

        CustomConsole.Clear();
        CustomConsole.WriteLineWithColor("Battle!! - 플레이어 공격 차례", CustomConsole.COLOR_TITLE);
        Console.WriteLine();
        Monster.Generate(RandomMonsters);
        Console.WriteLine();
        Console.WriteLine("[내 정보]");
        CustomConsole.WriteLine(GameManager.Instance.Player.GetInfo());
        CustomConsole.WriteLine("0. 도망");
        Console.WriteLine();

        SceneAction.BattlePlayerTurn[CustomConsole.PromptMenuChoice(0,
            RandomMonsters.Count,
            message: ChoiceMessage.TARGET)]();

        Console.WriteLine();
    }

    private void PlayerAttackInfo(int monsterIndex)
    {
        var monster = RandomMonsters[monsterIndex - 1];
        CustomConsole.Clear();
        CustomConsole.WriteLineWithColor("Battle!! - 플레이어 공격 정보", CustomConsole.COLOR_TITLE);
        Console.WriteLine();

        CustomConsole.WriteLine($"{GameManager.Instance.Player.Name} 의 공격!");
        if (_playerAttackDamage > 0)
        {
            CustomConsole.Write(
                $"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다.   ");
            CustomConsole.WriteLine($"[데미지: {_playerAttackDamage}]");
            Console.WriteLine();
            CustomConsole.WriteLine(
                $"Lv.{monster.Level} {monster.Name}");
            CustomConsole.WriteLine(
                $"HP {monster.Hp + _playerAttackDamage} -> {monster.Hp}");
        }
        else
        {
            CustomConsole.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.");
        }
        Console.WriteLine();
        CustomConsole.WriteLine("0. 다음");
        Console.WriteLine();

        switch (CustomConsole.PromptMenuChoice(0, 0))
        {
            case 0:
                MonsterAttackTurn();
                break;
        }
    }

    private void MonsterAttackTurn()
    {
        foreach (var monster in RandomMonsters.Where(monster => monster.IsAlive))
        {
            monster.Hit(player: GameManager.Instance.Player);
            CustomConsole.Clear();
            CustomConsole.WriteLineWithColor("Battle!! - 몬스터 공격 차례", CustomConsole.COLOR_TITLE);
            Console.WriteLine();
            CustomConsole.WriteLine($"Lv.{monster.Level} {monster.Name} 의 공격!");
            CustomConsole.Write($"{GameManager.Instance.Player.Name} 을(를) 맞췄습니다.   ");
            CustomConsole.WriteLine($"[데미지: {monster.Attack}]");
            Console.WriteLine();
            CustomConsole.WriteLine("0. 다음");
            Console.WriteLine();

            switch (CustomConsole.PromptMenuChoice(0, 0))
            {
                case 0:
                    if (GameManager.Instance.Player.Hp <= 0)
                    {
                        BattleResultPlayerLose();
                    }
                    continue;
            }
        }
    }

    public void BattleResultPlayerWin()
    {
        GameManager.Instance.Player.VictoryCount++;
        CustomConsole.Clear();
        CustomConsole.WriteLineWithColor("Battle!! - Result", CustomConsole.COLOR_TITLE);
        Console.WriteLine();
        CustomConsole.WriteLineWithColor("Victory", ConsoleColor.DarkGreen);
        Console.WriteLine();
        CustomConsole.WriteLine($"던전에서 몬스터 {RandomMonsters.Count}마리를 잡았습니다.");
        Console.WriteLine();
        CustomConsole.WriteLine($"Lv.{GameManager.Instance.Player.Level} {GameManager.Instance.Player.Name}");
        CustomConsole.WriteLine($"Hp {PlayerOriginalHp} -> {GameManager.Instance.Player.Hp}");
        Console.WriteLine();
        CustomConsole.WriteLine("0. 다음");
        Console.WriteLine();

        switch (CustomConsole.PromptMenuChoice(0, 0))
        {
            case 0:
                Main.Instance.PrintScene();
                break;
        }
    }

    public void BattleResultPlayerLose()
    {
        CustomConsole.Clear();
        CustomConsole.WriteLineWithColor("Battle!! - Result", CustomConsole.COLOR_TITLE);
        Console.WriteLine();
        CustomConsole.WriteLineWithColor("You Lose", ConsoleColor.Red);
        Console.WriteLine();
        CustomConsole.WriteLine($"Lv.{GameManager.Instance.Player.Level} {GameManager.Instance.Player.Name}");
        CustomConsole.WriteLine($"Hp {PlayerOriginalHp} -> {GameManager.Instance.Player.Hp}");
        Console.WriteLine();
        CustomConsole.WriteLine("0. 다음");
        Console.WriteLine();

        switch (CustomConsole.PromptMenuChoice(0, 0))
        {
            case 0:
                Main.Instance.PrintScene();
                break;
        }
    }

    private static void Init()
    {
        GameManager.Instance.IsScene = "battle";
    }
}