using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

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
            player = new Player("서영", "광합성이필요해", 1, 10, 5, 100, 15000);
            monsters = new List<Monster>()
            {
                new Monster(1, 2, "미니언", 15, true, 1),
                new Monster(2, 5, "대포미니언", 25, true, 2),
                new Monster(3, 3, "공허충", 10, true, 5)
            };
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
            Utility.PrintTextHighlights("체 력 : ", (player.HP).ToString());

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

            foreach (Monster monster in monsters)
            {
                Console.WriteLine($"{monster.GetInfo()}");
            }

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

            foreach (Monster monster in monsters)
            {
                if (monster.IsAlive)
                {
                    Console.WriteLine($"[{count++}] {monster.GetInfo()}");
                }
                else
                {
                    Utility.PrintTextGray($"[{count++}] {monster.GetInfo()}");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("[내정보]");
            Console.WriteLine($"{player.GetInfo()}");
            Console.WriteLine("");

            Console.WriteLine("0. 나가기");

            // TODO : 잘못된 입력했을 때 보이게 하기
            switch (Utility.PromptMenuChoice(0, count))
            {
                case 0:
                    MainMenu();
                    break;
                case 1:
                    if (monsters[0] != null && monsters[0].IsAlive)
                    {
                        BattlePlayerAttack(0);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                    break;
                case 2:
                    if (monsters[1] != null && monsters[1].IsAlive)
                    {
                        BattlePlayerAttack(1);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                    break;
                case 3:
                    if (monsters[2] != null && monsters[2].IsAlive)
                    {
                        BattlePlayerAttack(2);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                    break;
            }

        }
        public void BattlePlayerAttack(int monsterNumber)
        {
            int damage = player.GetPlayerAttackDamage(monsters[0]);

            Console.Clear();
            Utility.ShowTitle("■ Battle!! 3 - 1. 플레이어의 공격 ■");
            Console.WriteLine("");

            Console.WriteLine($"{player.Name} 의 공격!");
            Console.WriteLine($"Lv.{monsters[monsterNumber].Level} {monsters[monsterNumber].Name} 을(를) 맞췄습니다. [데미지 : {damage}]");
            Console.WriteLine("");


            Console.WriteLine($"Lv.{monsters[monsterNumber].Level} {monsters[monsterNumber].Name}");
            Console.Write($"HP {monsters[monsterNumber].HP} -> ");
            if (monsters[monsterNumber].HP <= damage)
            {
                monsters[monsterNumber].HP = 0;
                monsters[monsterNumber].IsAlive = false;
                Console.WriteLine("Dead");
            }
            else
            {
                monsters[monsterNumber].HP -= damage;
                Console.WriteLine(monsters[monsterNumber].HP);
            }

            Console.WriteLine("");
            Console.WriteLine("0. 다음");
            Console.WriteLine("");
            switch (Utility.PromptMenuChoice(0, 0))
            {
                case 0:
                    foreach (Monster monster in monsters)
                    {
                        if (monster.IsAlive)
                        {
                            BattleMonsterAttack(monster);
                        }
                    }
                    if (monsters[0].IsAlive == false && monsters[1].IsAlive == false && monsters[2].IsAlive == false)
                    {
                        BattleResultPlayerWin();
                    }
                    else
                    {
                        BattleMenu();
                    }

                    BattleMenu();

                    break;
            }

        }

        public void BattleMonsterAttack(Monster monster)
        {
            Console.Clear();
            Utility.ShowTitle("■ Battle!! 3 - 2. 몬스터의 공격 ■");
            Console.WriteLine("");

            Console.WriteLine($"Lv.{monster.Level} {monster.Name} 의 공격!");
            Console.WriteLine($"{player.Name} 을(를) 맞췄습니다. [데미지 : {monster.Atk}]");

            Console.WriteLine($"Lv.{player.Level} {player.Name}");
            Console.Write($"HP {player.HP} -> ");
            if (player.HP <= monster.Atk)
            {
                player.HP = 0;
                Console.WriteLine("Dead");
            }
            else
            {
                player.HP -= monster.Atk;
                Console.WriteLine(player.HP);
            }

            Console.WriteLine("");
            Console.WriteLine("0. 다음");
            Console.WriteLine("");
            switch (Utility.PromptMenuChoice(0, 0))
            {
                case 0:
                    if (player.HP <= 0)
                    {
                        BattleResultPlayerLose();
                    }
                    else
                    {
                        return;
                    }

                    break;
            }
        }

        public void BattleResultPlayerLose()
        {
            if (player.HP <= 0)
            {
                Console.Clear();
                Utility.ShowTitle("■ Battle!! - Result ■");
                Console.WriteLine("");
                Console.WriteLine("You Lose");
                Console.WriteLine("");

                Console.WriteLine($"Lv.{player.Level} {player.Name}");
                Console.Write($"HP {player.HP} -> 0");

                player.HP = player.MaxHP;

                Console.WriteLine("0. 다음");
                Console.WriteLine("");


                switch (Utility.PromptMenuChoice(0, 0))
                {
                    case 0:
                        MainMenu();
                        break;
                }
            }
        }

        public void BattleResultPlayerWin()
        {
            /*
             Battle!! - Result

Victory

던전에서 몬스터 3마리를 잡았습니다.

Lv.1 Chad
HP 100 -> 74

0. 다음

>>*/
            Console.Clear();
            Utility.ShowTitle("■ Battle!! - Result ■");
            Console.WriteLine("");
            Console.WriteLine("Victory");
            Console.WriteLine("");
            Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.");

            Console.WriteLine($"Lv.{player.Level} {player.Name}");
            Console.WriteLine($"HP {player.MaxHP} -> {player.HP}");

            player.HP = player.MaxHP;

            Console.WriteLine("0. 다음");
            Console.WriteLine("");

            player.Gold += 1000;

            switch (Utility.PromptMenuChoice(0, 0))
            {
                case 0:
                    MainMenu();
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
