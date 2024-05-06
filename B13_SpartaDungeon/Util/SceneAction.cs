using B13_SpartaDungeon.Manager;
using B13_SpartaDungeon.Scene;

namespace B13_SpartaDungeon.Util;

public static class SceneAction
{

    // 로비 선택지 액션
    public static readonly Dictionary<int, Action> MainActions = new()
    {
        [1] = () => PlayerStatus.Instance.PrintScene(),
        [2] = () =>
        {
            Battle.Instance.PlayerOriginalHp = GameManager.Instance.Player.Hp;
            Battle.Instance.PrintScene();
        },
    };

    // 캐릭터 정보 선택지 액션
    public static readonly Dictionary<int, Action> PlayerStatusActions = new()
    {
        [0] = () => Main.Instance.PrintScene(),
    };

    // 전투 선택지 액션
    public static readonly Dictionary<int, Action> BattleActions = new()
    {
        [0] = () =>
        {
            Battle.Instance.IsBattleAttemptCount = 0;
            Main.Instance.PrintScene();
        },
        [1] = () =>
        {
            Battle.Instance.IsBattleStart = true;
            Battle.Instance.PlayerAttackTurn();
        },
    };

    // 전투_플레이어 공격 차례 선택지 액션
    public static readonly Dictionary<int, Action> BattlePlayerTurn = new()
    {
        [0] = () =>
        {
            Battle.Instance.IsBattleStart = false;
            Main.Instance.PrintScene();
        },
    };
}