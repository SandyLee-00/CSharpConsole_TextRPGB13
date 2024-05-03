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

    public string GetInfo()
    {
        var ret = $"Lv.{Level} {Name} ({Job})\n";
        ret += $"HP : {Hp} / {MaxHp}\n";
        return ret;
    }

    public int GetPlayerAttackDamage()
    {
        var rand = new Random();
        var damage = Attack;
        var diff = rand.NextDouble() * 0.2f - 0.1f;
        damage = (int)Math.Ceiling(damage + damage * diff);
        return damage;
    }
}