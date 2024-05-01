
namespace TextRPG
{
    // TODO :
    public class Monster
    {
        public Monster(int id, int level, string name, int maxHP, bool isAlive)
        {
            Id = id;
            Level = level;
            Name = name;
            MaxHP = maxHP;
            HP = MaxHP;
            IsAlive = isAlive;
        }

        public String GetInfo()
        {
            string ret = $"Lv.{Level} {Name}";
            if (IsAlive)
            {
                ret += $" HP {HP}";
            }
            else
            {
                ret += " Dead";
            }
            return ret;
        }

        public int Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public int MaxHP { get; set; }
        public int HP { get; set; }
        public bool IsAlive { get; set; }


    }
}