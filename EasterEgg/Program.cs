using System;

namespace EasterEgg
{
    public class Program
    {
        public static void Main()
        {
            XMLHandler xmlHandler = new XMLHandler(@"..\..\..\characters.xml");
            const string MsgNom = "Quin es el nom del personatge?";
            const string MsgNivell = "Quin es el nivell del personatge?";
            const string MsgAtac = "Quin es l'atac del personatge?";
            const string MsgVida = "Quina es la vida del personatge?";
            const string MsgDefensa = "Quina es la defensa del personatge?";
            const string MsgOpcio = "Que vols fer crear un personatge nou (0), jugar amb un ja creat (1) o modificar un ja creat (2). Per a sortir (3)";
            const string MsgOpcioNoValida = "Opcio no valida, torna a posar el valor";
            const string StartCreateCharacter = "Començem amb la creacio del personatge.";
            const string CloseProgram = "Tancant el joc.Adeu!";
            int option;
            bool play = true;
            List<Character> characterList = xmlHandler.GetAllCharacters();
            if (characterList.Count == 0)
            {
                xmlHandler.AddCharacter(new Character());
            }
            while (play)
            {
                Console.WriteLine(MsgOpcio);
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        {
                            // Crear un personatge nou
                            Console.WriteLine(StartCreateCharacter);
                            Console.WriteLine(MsgNom);
                            string name = Console.ReadLine() ?? "";
                            Console.WriteLine(MsgNivell);
                            int lvl = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(MsgAtac);
                            int atk = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(MsgVida);
                            int hp = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(MsgDefensa);
                            int def = Convert.ToInt32(Console.ReadLine());
                            xmlHandler.AddCharacter(new Character(name, lvl, atk, hp, def));
                            break;
                        }

                    case 1:
                        {
                            // Jugar amb el personatje creat
                            Console.WriteLine("Amb quin personatge vols jugar?");
                            Console.WriteLine("Introdueix el seu nom:");
                            string name = Console.ReadLine() ?? "";
                            Character mycharacter = Methods.GetCharacterByName(xmlHandler, name);
                            Character randomcharacter = Methods.GetRandomCharacter(xmlHandler);
                            Methods.Fight(mycharacter, randomcharacter);
                            break;
                        }

                    case 2:
                        {
                            Character character = new Character();
                            Console.WriteLine(MsgNom);
                            character.Name = Console.ReadLine() ?? "";
                            Console.WriteLine(MsgNivell);
                            character.Lvl = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(MsgAtac);
                            character.Atk = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(MsgVida);
                            character.Hp = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(MsgDefensa);
                            character.Def = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                    case 3:
                        Console.WriteLine(CloseProgram);
                        play = false;
                        break;

                    default:
                        Console.WriteLine(MsgOpcioNoValida);
                        break;
                }
            }
        }
    }
}

