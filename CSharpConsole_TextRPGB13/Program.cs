using System.Numerics;

namespace TextRPG
{
    public class GameManager
    {
        private Player player;
        private List<Monster> monsters;

        public GameManager()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            player = new Player("Jiwon", "Programmer", 1, 10, 5, 100, 15000);
        }

        public void StartGame()
        {
            Console.Clear();
            MainMenu();
        }

        private void MainMenu()
        {
            // 구성
            // 0. 화면 정리
            Console.Clear();

            // 1. 선택 멘트를 줌
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("");

            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 전투 시작");
            Console.WriteLine("");

            // 2. 선택한 결과를 검증함
            int choice = Utility.PromptMenuChoice(1, 2);

            // 3. 선택한 결과에 따라 보내줌
            switch (choice)
            {
                case 1:
                    StatusMenu();
                    break;
                case 2:
                    BattleStartMenu();
                    break;
                
            }
            MainMenu();
        }

        private void StatusMenu()
        {
            Console.Clear();

            Utility.ShowTitle("■ 상태보기 ■");
            Console.WriteLine("캐릭터의 정보가 표기됩니다.");

            Utility.PrintTextHighlights("Lv. ", player.Level.ToString("00"));
            Console.WriteLine("");
            Console.WriteLine($"{player.Name} ( {player.Job} )");

            Utility.PrintTextHighlights("공격력 : ", (player.Atk).ToString());
            Utility.PrintTextHighlights("방어력 : ", (player.Def).ToString());
            Utility.PrintTextHighlights("체 력 : ", (player.Hp).ToString());

            Utility.PrintTextHighlights("Gold : ", player.Gold.ToString());
            Console.WriteLine("");

            Console.WriteLine("0. 뒤로가기");
            Console.WriteLine("");

            switch (Utility.PromptMenuChoice(0, 0))
            {
                case 0:
                    MainMenu();
                    break;
            }
        }
        private void BattleStartMenu()
        {
            Console.Clear();
            Utility.ShowTitle("■ Battle!! 3. 전투 시작 ■");
            Console.WriteLine("");
            
            // TODO : 몬스터 정보 출력
            /*foreach (Monster monster in monsters)
            {
                Console.WriteLine($"{monster.GetInfo()}");
            }*/

            Console.WriteLine("");
            Console.WriteLine("[내정보]");
            Console.WriteLine($"{player.GetInfo()}");
            Console.WriteLine("");

            Console.WriteLine("0. 나가기");
            Console.WriteLine("1. 공격");
            Console.WriteLine("");

            switch (Utility.PromptMenuChoice(0, 1))
            {
                case 0:
                    MainMenu();
                    break;
                case 1:
                    BattleMenu();
                    break;
            }
        }

        public void BattleMenu()
        {
            Console.Clear();
            Utility.ShowTitle("■ Battle!! 3 - 1. 공격 ■");
            Console.WriteLine("");

            int count = 1;

            // TODO : 몬스터 정보 출력
            /*foreach (Monster monster in monsters)
            {
                Console.WriteLine($"{count++} {monster.GetInfo()}");
            }*/

            Console.WriteLine("");
            Console.WriteLine("[내정보]");
            Console.WriteLine($"{player.GetInfo()}");
            Console.WriteLine("");

            Console.WriteLine("0. 취소");

            // TODO : 몬스터 선택
            switch (Utility.PromptMenuChoice(0, 1))
            {
                case 0:
                    MainMenu();
                    break;
                case 1:
                    BattleMenu();
                    break;
            }
        }
    }
    

    public class Program
    {
        public static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.StartGame();
        }
    }
}
