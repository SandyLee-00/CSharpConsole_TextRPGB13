using B13_SpartaDungeon.Scene;

namespace B13_SpartaDungeon.GameObjects;

public class Player
{
    public string Name { get; }
    public string Job { get; }
    public int Level { get; }
    public int Attack { get; }
    public int Defense { get; }
    public int MaxHp { get; }
    public int Hp { get; set; }
    public int Gold { get; set; }

    public Player(string name, string job, int level, int attack, int defense, int maxHp, int gold)
    {
        Name = name;
        Job = job;
        Level = level;
        Attack = attack;
        Defense = defense;
        MaxHp = maxHp;
        Hp = maxHp;
        Gold = gold;
    }

    public void Hit(ref List<Monster> targetMonster, int targetMonsterNumber)
    {
        var attackDamage = GetPlayerAttackDamage();
        var monster = targetMonster[targetMonsterNumber - 1];
        if (monster.Hp - attackDamage <= 0)
        {
            monster.Hp = 0;
            monster.IsAlive = false;
        }
        else
        {
            monster.Hp -= attackDamage;
        }
        targetMonster[targetMonsterNumber - 1] = monster;
    }

    public string GetInfo()
    {
        var ret = $"Lv.{Level} {Name} ({Job})\n";
        ret += $"HP : {Hp} / {MaxHp}\n";
        return ret;
    }

    private int GetPlayerAttackDamage()
    {
        var rand = new Random();
        var errorRate = rand.NextDouble() * 0.2f - 0.1f;
        var damage = (int)Math.Ceiling(Attack + Attack * errorRate);
        return damage;
    }
}