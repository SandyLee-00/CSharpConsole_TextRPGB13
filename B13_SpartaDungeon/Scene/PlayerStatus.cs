using B13_SpartaDungeon.GameObjects;
using B13_SpartaDungeon.Manager;
using B13_SpartaDungeon.Scene.Interfaces;
using B13_SpartaDungeon.Util;

namespace B13_SpartaDungeon.Scene;

public sealed class PlayerStatus : IScene
{
    public static PlayerStatus Instance { get; } = new();
    private Player _player = null!;

    public void PrintScene()
    {
        Init();

        #region 플레이어 상태 씬 출력

        CustomConsole.Clear();
        CustomConsole.WriteLineWithColor("상태 보기", CustomConsole.COLOR_TITLE);
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine();

        CustomConsole.WriteLine("Lv. " + _player.Level.ToString("00"));
        Console.WriteLine($"{_player.Name} ( {_player.Job} )");
        CustomConsole.WriteLine("공격력: " + _player.Attack);
        CustomConsole.WriteLine("방어력: " + _player.Defense);
        CustomConsole.WriteLine("체력 : " + _player.Hp);
        CustomConsole.WriteLine("Gold: " + _player.Gold);
        Console.WriteLine();
        CustomConsole.WriteLine("0. 뒤로가기");
        Console.WriteLine();

        #endregion

        SceneAction.PlayerStatusActions[CustomConsole.PromptMenuChoice(0, 0)]();
    }

    private void Init()
    {
        GameManager.Instance.IsScene = "playerStatus";
        _player = GameManager.Instance.Player;
    }
}