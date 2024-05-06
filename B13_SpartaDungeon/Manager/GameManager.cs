using B13_SpartaDungeon.GameObjects;
using B13_SpartaDungeon.Scene;

namespace B13_SpartaDungeon.Manager;

public class GameManager
{
    public static GameManager Instance { get; } = new();

    public Player Player = null!;
    public List<Monster> Monster = null!;

    private GameManager()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        Player = new Player("비십삼", "코딩전사", 1, 10, 5, 100, 1500);
        MonsterInit();
    }

    public void MonsterInit()
    {
        Monster = new List<Monster>
        {
            new(1, 2, "미니언", 15, 1),
            new(2, 5, "대포 미니언", 25, 2),
            new(3, 3, "공허충", 10, 5),
        };
    }

    public static void StartGame()
    {
        // Intro.PrintGameHeader();
        Lobby.Instance.PrintScene();
    }
}