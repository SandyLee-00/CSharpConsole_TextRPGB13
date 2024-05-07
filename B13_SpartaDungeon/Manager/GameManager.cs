using B13_SpartaDungeon.GameObjects;
using B13_SpartaDungeon.Scene;
using B13_SpartaDungeon.Util;

namespace B13_SpartaDungeon.Manager;

public class GameManager
{
    public static GameManager Instance { get; } = new();

    public Player Player = null!;
    public List<Monster> Monster = null!;

    private const string DEFAULT_NAME = "르탄이";
    private string _name = DEFAULT_NAME;

    public string IsScene = "";

    private GameManager()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        Player = new Player(_name, "전사", 1, 10, 5, 100, 1500);
        MonsterInit();
    }

    public void MonsterInit()
    {
        Monster = new List<Monster>
        {
            new(1, 2, "미니언", 15, 1),
            new(2, 5, "대포미니언", 25, 2),
            new(3, 3, "공허충", 10, 5),
            new(1, 10, "B반 미카엘 대천사 혁매", 10, 5),
            new(2, 11, "공포의 TIL 쓰셨나요? 진매", 20, 9),
            new(3, 20, "북미서버 챌린저 / 한국서버 다이아 후다닭", 15, 8),
        };
    }

    private static void EditPlayerName()
    {
        CustomConsole.Clear();
        CustomConsole.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
        CustomConsole.WriteLine("원하시는 이름을 설정해주세요.");
        CustomConsole.Write(">> ");
        Instance.Player.Name = Console.ReadLine() ?? DEFAULT_NAME;
    }

    public static void StartGame()
    {
        Intro.PrintGameHeader();
        EditPlayerName();
        Main.Instance.PrintScene();
    }
}