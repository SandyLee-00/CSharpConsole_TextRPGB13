using B13_SpartaDungeon.Interfaces;
using B13_SpartaDungeon.Manager;
using B13_SpartaDungeon.Util;

namespace B13_SpartaDungeon;

public sealed class PlayerStatus : IMenu
{
    public static PlayerStatus Instance { get; } = new();

    public void PrintMenu()
    {
        var player = GameManager.Instance.Player;

        #region 플레이어 정보 출력 부분

        Console.Clear();
        CustomConsole.WriteWithColor("상태 보기", CustomConsole.TITLE_COLOR);
        Console.WriteLine("캐릭터의 정보가 표시됩니다.");
        Console.WriteLine();

        CustomConsole.WriteLine("Lv. " + player.Level.ToString("00"));
        Console.WriteLine($"{player.Name} ( {player.Job} )");
        CustomConsole.WriteLine("공격력: " + player.Attack);
        CustomConsole.WriteLine("방어력: " + player.Defense);
        CustomConsole.WriteLine("체력 : " + player.Hp);
        CustomConsole.WriteLine("Gold: " + player.Gold);
        CustomConsole.WriteLine();
        CustomConsole.WriteLine("0. 뒤로가기");
        Console.WriteLine();

        #endregion

        var choice = CustomConsole.PromptMenuChoice(0, 0);

        SceneAction.CharacterStatusActions[choice]();
    }
}