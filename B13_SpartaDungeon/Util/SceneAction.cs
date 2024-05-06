using B13_SpartaDungeon.Manager;
using B13_SpartaDungeon.Scene;

namespace B13_SpartaDungeon.Util;

public static class SceneAction
{

    // 로비 선택지 액션
    public static readonly Dictionary<int, Action> LobbyActions = new()
    {
        [1] = () => PlayerStatus.Instance.PrintScene(),
        [2] = () => Battle.Instance.PrintScene(),
    };

    // 캐릭터 정보 선택지 액션
    public static readonly Dictionary<int, Action> CharacterStatusActions = new()
    {
        [0] = () => Lobby.Instance.PrintScene(),
    };

    // 사냥터 선택지 액션
    public static readonly Dictionary<int, Action> BattleActions = new()
    {
        [0] = () =>
        {
            GameManager.Instance.MonsterInit();
            Battle.Instance.IsBattleAttemptCount = 0;
            Lobby.Instance.PrintScene();
        },
        [1] = () =>
        {
            Battle.Instance.IsBattleStart = true;
            Battle.Instance.BattlePlayerTurn();
        },
    };

    // 사냥터(플레이어 차례) 선택지 액션
    public static readonly Dictionary<int, Action> BattlePlayerTurn = new()
    {
        [0] = () =>
        {
            Battle.Instance.IsBattleStart = false;
            Battle.Instance.PrintScene();
        },
    };

    // 사냥터(몬스터 차례) 선택지 액션
    public static readonly Dictionary<int, Action> BattleMonsterTurn = new();
}