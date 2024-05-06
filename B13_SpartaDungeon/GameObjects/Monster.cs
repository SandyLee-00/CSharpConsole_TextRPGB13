using B13_SpartaDungeon.Manager;
using B13_SpartaDungeon.Scene;
using B13_SpartaDungeon.Util;

namespace B13_SpartaDungeon.GameObjects;

public struct Monster
{
    public int Id { get; set; }
    public int Level { get; set; }
    public string Name { get; set; }
    public int MaxHp { get; set; }
    public int Hp { get; set; }
    public bool IsAlive { get; set; }
    public int Attack { get; }

    public Monster(int id, int level, string name, int maxHp, int attack, bool isAlive = true)
    {
        Id = id;
        Level = level;
        Name = name;
        MaxHp = maxHp;
        Hp = MaxHp;
        IsAlive = isAlive;
        Attack = attack;
    }

    public string GetInfo()
    {
        var ret = $"Lv.{Level} {Name}";
        if (IsAlive)
        {
            ret += $" HP {Hp}";
        }
        else
        {
            ret += " Dead";
        }
        return ret;
    }

    // 몬스터 생성
    public static List<Monster> GetListByRandom()
    {
        List<Monster> randomMonsters = new();
        var random = new Random();
        var randomLoopCount = random.Next(1, 5); // 1~4마리 랜덤으로 생성
        for (var i = 0; i < randomLoopCount; i++)
        {
            // 순서 랜덤 표시
            var randomIndex = random.Next(0, GameManager.Instance.Monster.Count);
            randomMonsters.Add(GameManager.Instance.Monster[randomIndex]);
        }
        return randomMonsters;
    }

    public static void Generate(List<Monster> monsters)
    {
        var count = 0;
        foreach (var monster in monsters)
        {
            switch (Battle.Instance.IsBattleStart)
            {
                case true when Battle.Instance.IsBattleAttemptCount > 0:
                    if (monster.IsAlive)
                    {
                        CustomConsole.WriteWithColor($"[{++count}] ", ConsoleColor.Green);
                        CustomConsole.WriteLine(monster.GetInfo());
                    }
                    else
                    {
                        CustomConsole.WriteLineWithColor($"[{++count}] {monster.GetInfo()}", ConsoleColor.Gray);
                    }
                    break;
                default:
                    if (monster.IsAlive)
                    {
                        CustomConsole.WriteLine(monster.GetInfo());
                    }
                    else
                    {
                        CustomConsole.WriteLineWithColor(monster.GetInfo(), ConsoleColor.Gray);
                    }
                    break;
            }
        }
        Battle.Instance.IsBattleAttemptCount++;
    }

    public void Hit(Player player)
    {
        player.Hp -= Attack;
    }
}