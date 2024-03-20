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
            const string CloseProgram = "Tancant el joc. Adeu!";
            const string DefaultName = "DefaultName";
            const string MsgPlayWithCharacter = "Amb quin personatge vols jugar? Hi han aquestas opcions:";
            const string MsgModifyCharacter = "Quin personatge vols modificar? Hi han aquestas opcions:";
            const string NameDefaultCharacter = "Pepe";
            const string MsgIntroduceNameGame = "Introdueix el seu nom, (en cas de equivocar-te amb el nom rebràs el personatge per defecte):";
            const string MsgPlayOrNot = "Que vols fer, per sortir (1), si vols seguir jugat pulsa qualsevol numero que no sigui el (1)";
            const string ClickToContinue = "Prem algun boto per continua";
            const string GoToMainMenu = "Tornan al menu principal...";
            const string NoCharacterCreatedByUser = "No hi ha cap personatge creat per el usuari si vols modificar valors d'algun personatge, te que ser creat per el usuari.\nEl personatge per defecte no es pot modificar.";
            const string MsgIntroduceNameModify = "Introdueix el seu nom, (en cas de equivocar-te amb el nom rebràs sortiras al programa principal):";
            const string CantModifyDefaultCharacter = "No pots modificar el personatge per defecte.";
            const string MsgExistCharacter = "Ja existeix un personatge amb aquest nom.";
            const string MsgTryAgain = "Intenta un altre cop.";
            const string MsgChangeNameCorrectly = "Nom canviat correctament.";
            const string MsgChangeLvlCorrectly = "Nivell canviat correctament.";
            const string MsgChangeAtkCorrectly = "Atac canviat correctament.";
            const string MsgChangeHpCorrectly = "Vida canviada correctament.";
            const string MsgChangeDefCorrectly = "Defensa canviada correctament.";
            const string MsgErrorInputLvl = "El nivell ha de ser major o igual a {0}.";
            const string MsgErrorInputAtk = "L'atac ha de ser major o igual a {0}.";
            const string MsgErrorInputHp = "La vida ha de ser major o igual a {0}.";
            const string MsgErrorInputDef = "La defensa ha de ser major o igual a {0}.";
            const string MsgModify = "Vols modificar el {0}? (si) o (no)";
            const string MsgModifyGet = "Introdueix el nou {0}:";
            const string MsgName = "nom";
            const string MsgLvl = "nivell";
            const string MsgAtk = "atac";
            const string MsgHp = "vida";
            const string MsgDef = "defensa";
            const string MsgCharacterModified = "Personatge modificat correctament.";
            const string MsgCreatingDefaultCharacter = "Creant un personatge per defecte.";
            const string MsgCurrentValue = "Valor actual: {0}";


            const int Zero = 0, MinHp = 10;
            int option;
            bool play = true;
            List<Character> characterList = xmlHandler.GetAllCharacters();
            if (characterList.Count == Zero)
            {
                xmlHandler.AddCharacter(new Character());
                Console.WriteLine(MsgCreatingDefaultCharacter);
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
                            // Jugar amb els personatges creats
                            Console.WriteLine(MsgPlayWithCharacter);
                            characterList = xmlHandler.GetAllCharacters();
                            foreach (Character character in characterList)
                            {
                                Console.WriteLine(character.Name);
                            }
                            Console.WriteLine(MsgIntroduceNameGame);
                            string name = Console.ReadLine() ?? "";
                            Character mycharacter = Methods.GetCharacterByName(xmlHandler, name);
                            //Character randomcharacter = Methods.GetRandomCharacter(xmlHandler);
                            Character character1 = Methods.GetCharacterByName(xmlHandler, "Pepe");
                            Methods.Fight(mycharacter, character1, xmlHandler);
                            int userOption;
                            Console.WriteLine(MsgPlayOrNot);
                            userOption = Convert.ToInt32(Console.ReadLine());
                            if (userOption == 1)
                            {
                                play = false;
                                Console.WriteLine(CloseProgram);
                            }
                            break;
                        }

                    case 2:
                        {
                            // Modificar un personatge
                            Console.WriteLine(MsgModifyCharacter);
                            characterList = xmlHandler.GetAllCharacters();
                            if (characterList.Count == Zero)
                            {
                                Console.WriteLine(NoCharacterCreatedByUser);
                                Console.WriteLine(GoToMainMenu);
                                Console.WriteLine(ClickToContinue);
                                Console.ReadKey();
                            }
                            else
                            {
                                foreach (Character character in characterList)
                                {
                                    if (character.Name != NameDefaultCharacter)
                                    {
                                        Console.WriteLine(character.Name);
                                    }
                                }
                                Console.WriteLine(MsgIntroduceNameModify);
                                string name = Console.ReadLine() ?? "";
                                Character mycharacter = Methods.GetCharacterByName(xmlHandler, name);
                                if (mycharacter.Name == NameDefaultCharacter)
                                {
                                    Console.WriteLine(CantModifyDefaultCharacter);
                                } else
                                {
                                    string optionModify;
                                    Console.WriteLine(MsgModify, MsgName);
                                    optionModify = Console.ReadLine() ?? "";
                                    if (Methods.CheckYesNo(optionModify))
                                    {
                                        bool correctName = false;
                                        do
                                        {
                                            Console.WriteLine(MsgCurrentValue, mycharacter.Name);
                                            Console.WriteLine(MsgModifyGet, MsgName);
                                            string newname = Console.ReadLine() ?? DefaultName;
                                            Character character = Methods.GetCharacterByName(xmlHandler, newname);
                                            if (character.Name != NameDefaultCharacter)
                                            {
                                                Console.WriteLine(MsgExistCharacter);
                                                Console.WriteLine(MsgTryAgain);
                                                correctName = true;
                                            }
                                            else
                                            {
                                                mycharacter.Name = newname;
                                                correctName = false;
                                            }
                                        } while (correctName);
                                        Console.WriteLine(MsgChangeNameCorrectly);
                                    }
                                    Console.WriteLine(MsgModify, MsgLvl);
                                    optionModify = Console.ReadLine() ?? "";
                                    if (Methods.CheckYesNo(optionModify))
                                    {
                                        bool correctLvl = false;
                                        do
                                        {
                                            Console.WriteLine(MsgCurrentValue, mycharacter.Lvl);
                                            Console.WriteLine(MsgModifyGet, MsgLvl);
                                            int newlvl = Convert.ToInt32(Console.ReadLine());
                                            if (Methods.CheckGreaterOrEqualThanNumber(Zero, newlvl))
                                            {
                                                mycharacter.Lvl = newlvl;
                                                correctLvl = false;
                                            }
                                            else
                                            {
                                                Console.WriteLine(MsgErrorInputLvl, Zero);
                                                Console.WriteLine(MsgTryAgain);
                                                correctLvl = true;
                                            }
                                        } while (correctLvl);                                       
                                        Console.WriteLine(MsgChangeLvlCorrectly);
                                    }
                                    Console.WriteLine(MsgModify, MsgAtk);
                                    optionModify = Console.ReadLine() ?? "";
                                    if (Methods.CheckYesNo(optionModify))
                                    {
                                        bool correctAtk = false;
                                        do
                                        {
                                            Console.WriteLine(MsgCurrentValue, mycharacter.Atk);
                                            Console.WriteLine(MsgModifyGet, MsgAtk);
                                            int newatk = Convert.ToInt32(Console.ReadLine());
                                            if (Methods.CheckGreaterOrEqualThanNumber(Zero, newatk))
                                            {
                                                mycharacter.Atk = newatk;
                                                correctAtk = false;
                                            }
                                            else
                                            {
                                                Console.WriteLine(MsgErrorInputAtk, Zero);
                                                Console.WriteLine(MsgTryAgain);
                                                correctAtk = true;
                                            }
                                        } while (correctAtk);
                                        Console.WriteLine(MsgChangeAtkCorrectly);
                                    }
                                    Console.WriteLine(MsgModify, MsgHp);
                                    optionModify = Console.ReadLine() ?? "";
                                    if (Methods.CheckYesNo(optionModify))
                                    {
                                        bool correctHp = false;
                                        do
                                        {
                                            Console.WriteLine(MsgCurrentValue, mycharacter.Hp);
                                            Console.WriteLine(MsgModifyGet, MsgHp);
                                            int newhp = Convert.ToInt32(Console.ReadLine());
                                            if (Methods.CheckGreaterOrEqualThanNumber(MinHp, newhp))
                                            {
                                                mycharacter.Hp = newhp;
                                                correctHp = false;
                                            }
                                            else
                                            {
                                                Console.WriteLine(MsgErrorInputHp, MinHp);
                                                Console.WriteLine(MsgTryAgain);
                                                correctHp = true;
                                            }
                                        } while (correctHp);
                                        Console.WriteLine(MsgChangeHpCorrectly);
                                    }
                                    Console.WriteLine(MsgModify, MsgDef);
                                    optionModify = Console.ReadLine() ?? "";
                                    if (Methods.CheckYesNo(optionModify))
                                    {
                                        bool correctDef = false;
                                        do
                                        {
                                            Console.WriteLine(MsgCurrentValue, mycharacter.Def);
                                            Console.WriteLine(MsgModifyGet, MsgDef);
                                            int newdef = Convert.ToInt32(Console.ReadLine());
                                            if (Methods.CheckGreaterOrEqualThanNumber(Zero, newdef))
                                            {
                                                mycharacter.Def = newdef;
                                                correctDef = false;
                                            }
                                            else
                                            {
                                                Console.WriteLine(MsgErrorInputDef, Zero);
                                                Console.WriteLine(MsgTryAgain);
                                                correctDef = true;
                                            }
                                        } while (correctDef);
                                        Console.WriteLine(MsgChangeDefCorrectly);
                                    }
                                    xmlHandler.ModifyCharacter(mycharacter);
                                    Console.WriteLine(MsgCharacterModified);
                                }
                            }
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

