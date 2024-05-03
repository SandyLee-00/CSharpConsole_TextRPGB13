using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Player
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int MaxHP { get; }
        public int HP { get; set; }
        public int Gold { get; set; }

        public Player(string name, string job, int level, int atk, int def, int maxHP, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            MaxHP = maxHP;
            HP = MaxHP;
            Gold = gold;
        }

        public String GetInfo()
        {
            string ret = $"Lv.{Level} {Name} ({Job})\n";
            ret += $"HP : {HP} / {MaxHP}\n";
            return ret;
        }

        public int GetPlayerAttackDamage()
        {
            Random rand = new Random();
            int damage = Atk;
            double diff = rand.NextDouble() * 0.2f - 0.1f;
            damage = (int)Math.Ceiling(damage + damage * diff);
            return damage;
        }
    }
}
