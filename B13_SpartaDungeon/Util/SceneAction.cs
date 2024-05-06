using B13_SpartaDungeon.Scene;

namespace B13_SpartaDungeon.Util;

public static class SceneAction
{

    public static readonly Dictionary<int, Action> LobbyActions = new()
    {
        [1] = () => PlayerStatus.Instance.PrintScene(),
        [2] = () => Battle.Instance.PrintScene(),
    };

    public static readonly Dictionary<int, Action> CharacterStatusActions = new()
    {
        [0] = () => Lobby.Instance.PrintScene(),
    };

    public static readonly Dictionary<int, Action> BattleActions = new()
    {
        [0] = () => Lobby.Instance.PrintScene(),
        [1] = () => Battle.Instance.BattlePlayerTurn(),
    };

    public static readonly Dictionary<int, Action> BattlePlayerTurn = new()
    {
        [0] = () => Battle.Instance.PrintScene(),
    };

    public static readonly Dictionary<int, Action> BattleMonsterTurn = new()
    {
        
    };
}