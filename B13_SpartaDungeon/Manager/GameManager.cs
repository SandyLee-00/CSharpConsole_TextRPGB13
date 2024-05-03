using B13_SpartaDungeon.GameObjects;

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
        Player = new Player("B13", "광합성이필요해", 1, 10, 5, 100, 15000);
        Monster = new List<Monster>
        {
            new(1, 2, "미니언", 15, true, 1),
            new(2, 5, "대포미니언", 25, true, 2),
            new(3, 3, "공허충", 10, true, 5)
        };
    }

    public static void StartGame()
    {
        Lobby.Instance.PrintMenu();
    }
}