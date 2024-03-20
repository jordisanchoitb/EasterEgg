using System;
using System.Linq;

namespace EasterEgg
{
    public static class Methods
    {
        public static Character GetCharacterByName(XMLHandler xmlHandler, string name)
        {
            return xmlHandler.GetAllCharacters().FirstOrDefault(c => c.Name == name);
        }

        public static void Fight(Character character1, Character character2)
        {
            Console.WriteLine("Comença la batalla entre " + character1.Name + " i " + character2.Name);
            int tempHp1 = character1.Hp;
            int tempHp2 = character2.Hp;
            while (tempHp1 > 0 && tempHp2 > 0)
            {
                tempHp1 -= character2.Atk - character1.Def;
                tempHp2 -= character1.Atk - character2.Def;
            }
            if (tempHp1 <= 0 && tempHp2 <= 0)
            {
                Console.WriteLine("Empat!");
            }
            else if (tempHp1 <= 0)
            {
                Console.WriteLine(character2.Name + " ha guanyat la batalla!");
                character2.Lvl++;
            }
            else
            {
                Console.WriteLine(character1.Name + " ha guanyat la batalla!");
                character1.Lvl++;
            }

        }

        public static Character GetRandomCharacter(XMLHandler xmlHandler)
        {
            List<Character> characters = xmlHandler.GetAllCharacters();
            var random = new Random();
            return characters[random.Next(characters.Count)];
        }
    }
}
