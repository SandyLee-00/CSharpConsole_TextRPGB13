using B13_SpartaDungeon.Manager;
using B13_SpartaDungeon.Util;

namespace B13_SpartaDungeon.GameObjects;

public enum Job
{
    전사,
    법사,
    궁수,
    닌자,
}

public class Player
{
    public string Name { get; private set; }
    public Job Job { get; private set; }
    public int Level { get; }
    public int Attack { get; }
    public int Defense { get; }
    public int MaxHp { get; }
    public int MaxMp { get; }
    public int Hp { get; set; }
    public int Mp { get; set; }
    public int Gold { get; set; }
    public int VictoryCount { get; set; }

    private const string DEFAULT_NAME = "르탄이";

    public Player(string name, Job job, int level, int attack, int defense, int maxHp, int maxMp, int gold,
        int victoryCount = 0)
    {
        Name = name;
        Job = job;
        Level = level;
        Attack = attack;
        Defense = defense;
        MaxHp = maxHp;
        MaxMp = maxMp;
        Hp = maxHp;
        Mp = maxMp;
        Gold = gold;
        VictoryCount = victoryCount;
    }

    public static void EditPlayerName()
    {
        CustomConsole.Clear();
        CustomConsole.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        CustomConsole.WriteLine("원하시는 이름을 설정해주세요.");
        CustomConsole.Write(">> ");
        GameManager.Instance.Player.Name = Console.ReadLine() ?? DEFAULT_NAME;
    }

    public static void EditPlayerJob()
    {
        CustomConsole.Clear();
        CustomConsole.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        CustomConsole.WriteLine("원하시는 직업을 설정해주세요.");
        Console.WriteLine();
        CustomConsole.WriteLine("1. 전사 ");
        CustomConsole.WriteLine("2. 법사");
        CustomConsole.WriteLine("3. 궁수");
        CustomConsole.WriteLine("4. 닌자");
        Console.WriteLine();

        GameManager.Instance.Player.Job = CustomConsole.PromptMenuChoice(1, 4) switch
        {
            1 => Job.전사,
            2 => Job.법사,
            3 => Job.궁수,
            4 => Job.닌자,
            _ => GameManager.Instance.Player.Job,
        };
    }

    public void Hit(ref List<Monster> targetMonster, int targetMonsterIndex, ref int playerAttackDamage)
    {
        var attackDamage = GetPlayerAttackDamage();
        var monster = targetMonster[targetMonsterIndex - 1];
        if (monster.Hp - attackDamage <= 0)
        {
            monster.Hp = 0;
            monster.IsAlive = false;
        }
        else
        {
            monster.Hp -= attackDamage;
        }
        targetMonster[targetMonsterIndex - 1] = monster;

        var random = new Random();
        var prob = random.NextDouble();

        playerAttackDamage = prob switch
        {
            <= 0.15f => playerAttackDamage = (int)Math.Ceiling(attackDamage * 1.6f), // 15% 확률로 치명타 발생 => 160% 데미지
            >= 0.9f and <= 1.0f => playerAttackDamage = 0, // 10% 확률로 공격 무효 => 몬스터 회피
            _ => playerAttackDamage = attackDamage,
        };
    }

    public string GetInfo()
    {
        var ret = $"Lv.{Level} {Name} ({Job})\n";
        ret += $"HP : {Hp} / {MaxHp}\n";
        ret += $"MP : {Mp} / {MaxMp}\n";
        return ret;
    }

    private int GetPlayerAttackDamage()
    {
        var rand = new Random();
        var errorRate = rand.NextDouble() * 0.2f - 0.1f;
        var damage = (int)Math.Ceiling(Attack + Attack * errorRate);
        return damage;
    }

    public static void RecoverMp(int recoveryNumber = 10)
    {
        if (GameManager.Instance.Player.Mp + recoveryNumber < GameManager.Instance.Player.MaxMp)
        {
            GameManager.Instance.Player.Mp += recoveryNumber;
        }
        else
        {
            GameManager.Instance.Player.Mp = GameManager.Instance.Player.MaxMp;
        }
    }
}