using B13_SpartaDungeon.Manager;
using B13_SpartaDungeon.Scene.Interfaces;
using B13_SpartaDungeon.Util;

namespace B13_SpartaDungeon.Scene;

public sealed class PlayerStatus : IScene
{
    public static PlayerStatus Instance { get; } = new();

    public void PrintScene()
    {
        var player = GameManager.Instance.Player;

        #region 플레이어 정보 씬 출력 부분

        CustomConsole.Clear();
        CustomConsole.WriteLineWithColor("상태 보기", CustomConsole.COLOR_TITLE);
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine();

        CustomConsole.WriteLine("Lv. " + player.Level.ToString("00"));
        Console.WriteLine($"{player.Name} ( {player.Job} )");
        CustomConsole.WriteLine("공격력: " + player.Attack);
        CustomConsole.WriteLine("방어력: " + player.Defense);
        CustomConsole.WriteLine("체력 : " + player.Hp);
        CustomConsole.WriteLine("Gold: " + player.Gold);
        Console.WriteLine();
        CustomConsole.WriteLine("0. 뒤로가기");
        Console.WriteLine();

        #endregion

        var choice = CustomConsole.PromptMenuChoice(0, 0);

        SceneAction.CharacterStatusActions[choice]();
    }
}