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
        var targetMonsterHp = targetMonster[targetMonsterNumber - 1].Hp;
        if (targetMonsterHp - attackDamage <= 0)
        {
            targetMonster[targetMonsterNumber - 1].Hp = 0;
            targetMonster[targetMonsterNumber - 1].IsAlive = false;
        }
        else
        {
            targetMonster[targetMonsterNumber - 1].Hp -= attackDamage;
        }
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