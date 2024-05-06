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
        Player = new Player("르탄이", "전사", 1, 10, 5, 100, 1500);
        MonsterInit();
    }

    public void MonsterInit()
    {
        Monster = new List<Monster>
        {
            new(1, 2, "미니언", 15, 1),
            new(2, 5, "대포미니언", 25, 2),
            new(3, 3, "공허충", 10, 5),
        };
    }

    public static void StartGame()
    {
        Intro.PrintGameHeader();
        Main.Instance.PrintScene();
    }
}