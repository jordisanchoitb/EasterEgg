using System;

namespace EasterEgg
{
    public class Program
    {
        public static void Main()
        {
            const string MsgNom = "Quin es el nom del personatge?";
            const string MsgNivell = "Quin es el nivell del personatge?";
            const string MsgAtac = "Quin es l'atac del personatge?";
            const string MsgVida = "Quina es la vida del personatge?";
            const string MsgDefensa = "Quina es la defensa del personatge?";
            const string MsgOpcio = "Que vols fer crear un personatge nou (0), jugar amb un ja creat (1) o modificar un ja creat (2)";
            const string MsgOpcioNoValida = "Opcio no valida";
            const string StartCreateCharacter = "Començem amb la creacio del personatge.";
            int option;
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
                        Character character = new Character(name, lvl, atk, hp, def);
                        break;
                    }

                case 1:
                    {
                        // Jugar amb el personatje creat
                        Character character = new Character();
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

                default:
                    Console.WriteLine(MsgOpcioNoValida);
                    break;
            }
        }
    }
}

