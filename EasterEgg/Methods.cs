using System;
using System.Linq;

namespace EasterEgg
{
    public static class Methods
    {
        /// <summary>
        /// Returns a character by its name
        /// </summary>
        /// <param name="name">Character Name</param>
        /// <returns>Character</returns>
        public static Character GetCharacterByName(XMLHandler xmlHandler, string name)
        {
            Character character = xmlHandler.GetAllCharacters().FirstOrDefault(c => c.Name == name);
            if (character == null)
            {
                return xmlHandler.GetAllCharacters().FirstOrDefault(c => c.Name == "Pepe");
            }
            return character;
        }

        /// <summary>
        /// Battle between two characters
        /// </summary>
        /// <param name="character1">Your character</param>
        /// <param name="character2">Aleatori character</param>
        public static void Fight(Character character1, Character character2, XMLHandler xmlHandler)
        {
            const string MsgStartFight = "Comença la batalla entre {0} i {1}";
            const string MsgTie = "Empat!";
            const string MsgWin = "{0} ha guanyat la batalla!";
            const string MsgLevelUp = "{0} ha pujat de nivell!";
            const string MsgBattle = "Ataca {0} a {1}, amb un atac que li treu {2} de vida.\nVida restant a {3}: {4}";
            const int DefaultAtk = 5, Zero = 0;

            Console.WriteLine(MsgStartFight, character1.Name , character2.Name);
            int tempHp1 = character1.Hp;
            int tempHp2 = character2.Hp;
            int calcAtkCharacter1 = (character1.Atk - character2.Def) == Zero ? DefaultAtk : (character1.Atk - character2.Def);
            int calcAtkCharacter2 = (character2.Atk - character1.Def) == Zero ? DefaultAtk : (character2.Atk - character1.Def);

            while (tempHp1 > Zero && tempHp2 > Zero)
            {
                Console.WriteLine(MsgBattle, character2.Name, character1.Name, calcAtkCharacter2, character1.Name, tempHp1 - calcAtkCharacter2);
                tempHp1 -= calcAtkCharacter2;
                Console.WriteLine(MsgBattle, character1.Name, character2.Name, calcAtkCharacter1, character2.Name, tempHp2 - calcAtkCharacter1);
                tempHp2 -= calcAtkCharacter1;
            }
            if (tempHp1 <= Zero && tempHp2 <= Zero)
            {
                Console.WriteLine(MsgTie);
            }
            else if (tempHp1 <= Zero)
            {
                Console.WriteLine(MsgWin, character2.Name);
                character2.Lvl++;
                Console.WriteLine(MsgLevelUp, character2.Name);
                xmlHandler.ModifyCharacter(character2);
            }
            else
            {
                Console.WriteLine(MsgWin, character1.Name);
                character1.Lvl++;
                Console.WriteLine(MsgLevelUp, character1.Name);
                xmlHandler.ModifyCharacter(character1);
            }
        }

        /// <summary>
        /// Returns a random character
        /// </summary>
        /// <returns>Character</returns>
        public static Character GetRandomCharacter(XMLHandler xmlHandler)
        {
            List<Character> characters = xmlHandler.GetAllCharacters();
            var random = new Random();
            return characters[random.Next(characters.Count)];
        }

        /// <summary>
        /// Returns a boolean if the message is yes or no
        /// </summary>
        /// <param name="message">user text</param>
        /// <returns>bool</returns>
        public static bool CheckYesNo(string message)
        {
            if (message.ToLower() == "yes" || message.ToLower() == "y" || message.ToLower() == "s" || message.ToLower() == "si")
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Returns a boolean if the value is greater or equal than the number especified
        /// </summary>
        /// <param name="number">Number comparable</param>
        /// <param name="value">User value</param>
        /// <returns></returns>
        public static bool CheckGreaterOrEqualThanNumber(int number, int value)
        {
            return value >= number;
        }
    }
}
