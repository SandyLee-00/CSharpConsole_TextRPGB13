using B13_SpartaDungeon.GameObjects;
using B13_SpartaDungeon.Scene;

namespace B13_SpartaDungeon.Manager;

public class GameManager
{
    public static GameManager Instance { get; } = new();

    public Player Player = null!;
    public List<Monster> Monster = null!;

    public string IsScene = "";

    private GameManager()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        Player = new Player("르탄이", Job.전사, 1, 10, 5, 100, 1500);
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

    public static void StartGame()
    {
        Intro.PrintGameHeader();
        Player.EditPlayerName();
        Player.EditPlayerJob();
        Main.Instance.PrintScene();
    }
}