using B13_SpartaDungeon.Manager;
using B13_SpartaDungeon.Util;

namespace B13_SpartaDungeon.GameObjects;

public class Monster
{
    public int Id { get; set; }
    public int Level { get; set; }
    public string Name { get; set; }
    public int MaxHp { get; set; }
    public int Hp { get; set; }
    public bool IsAlive { get; set; }
    public int Attack { get; }

    public Monster(int id, int level, string name, int maxHp, bool isAlive, int attack)
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
        var randomMonsters = new List<Monster>();
        var randomLoopCount = new Random().Next(1, 5); // 1~4마리 랜덤으로 생성
        for (var i = 0; i < randomLoopCount; i++)
        {
            // 순서 랜덤 표시
            var randomIndex = new Random().Next(0, 3);
            randomMonsters.Add(GameManager.Instance.Monster[randomIndex]);
        }

        return randomMonsters;
    }

    public static void Generate(List<Monster> monsters, bool isAttackPhase)
    {
        var count = 0;
        foreach (var monster in monsters)
        {
            if (!isAttackPhase)
            {
                CustomConsole.WriteLine(monster.GetInfo());
                Thread.Sleep(250);
            }
            else
            {
                CustomConsole.WriteWithColor($"[{++count}] ", ConsoleColor.Green);
                CustomConsole.WriteLine(monster.GetInfo());
            }
        }
    }
}