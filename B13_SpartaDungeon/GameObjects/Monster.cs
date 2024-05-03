using B13_SpartaDungeon.Manager;
using B13_SpartaDungeon.Util;

namespace B13_SpartaDungeon.GameObjects;

public class Monster
{
    public int Id { get; set; }
    public int Level { get; set; }
    public string Name { get; set; } = null!;
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

    // 몬스터 랜덤 생성(1~4마리)
    public static void RandomGenerate()
    {
        var randomLoopCount = new Random().Next(1, 5);
        for (var i = 0; i < randomLoopCount; i++)
        {
            var randomIndex = new Random().Next(0, 3);
            CustomConsole.WriteLine(GameManager.Instance.Monster[randomIndex].GetInfo());
        }
    }
}