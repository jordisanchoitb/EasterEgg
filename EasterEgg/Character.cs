using System;

namespace EasterEgg
{
    public class Character
    {
        public string Name { get; set; }
        public int Lvl { get; set; }
        public int Atk { get; set; }
        public int Hp { get; set; }
        public int Def { get; set; }
        public Character(string name, int lvl, int atk, int hp, int def)
        {
            Name = name;
            Lvl = lvl;
            Atk = atk;
            Hp = hp;
            Def = def;
        }
        public Character() : this("Inutil", 1, 5, 1, 4) { }
    }
}
