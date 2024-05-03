namespace CSharpConsole_TextRPGB13.Util;

public class AlertMessage
{
    public static AlertMessage Instance { get; } = new();

    public const string INPUT_ERROR = "\n잘못된 입력입니다";
    // public const string COMPLETE_PURCHASE = "\n구매를 완료했습니다.";
    // public const string LACKED_GOLD = "\nGold 가 부족합니다.";
    // public const string PURCHASED = "\n이미 구매한 아이템입니다.";
    // public const string IMPOSSIBLE_SELL = "\n판매할 수 없습니다.";
}
