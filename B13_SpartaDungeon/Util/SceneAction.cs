namespace B13_SpartaDungeon.Util;

public static class SceneAction
{
    static SceneAction()
    {
        LobbyActions[1] = () => PlayerStatus.Instance.PrintMenu();
        LobbyActions[2] = () => Battle.Instance.PrintMenu();

        CharacterStatusActions[0] = () => Lobby.Instance.PrintMenu();

        // BattleActions[0] = () => Lobby.Instance.PrintMenu();
        // BattleActions[1] = () => ;
    }

    public static readonly Dictionary<int, Action> LobbyActions = new();

    public static readonly Dictionary<int, Action> CharacterStatusActions = new();

    // public static readonly Dictionary<int, Action> BattleActions = new();
}