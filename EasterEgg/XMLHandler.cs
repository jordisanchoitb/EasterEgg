using System.Xml;

namespace EasterEgg
{
    public class XMLHandler
    {
        const bool DEBUG = false;

        public static string PATH { get; set; }
        public static XmlDocument xmlDocument { get; set; }

        public XMLHandler(string path) 
        {
            PATH = path;
            xmlDocument = new XmlDocument();
            try {
                xmlDocument.Load(PATH);
            }
            catch (Exception e)
            {
                if (DEBUG)
                {
                    Console.WriteLine("Could not load the XML document.");
                    Console.WriteLine(e.Message);
                }
                return;
            }
        }

        public void AddCharacter(Character character)
        {
            if (xmlDocument == null)
            {
                Console.WriteLine("XML document is not initialized.");
                return;
            }

            XmlNode entitiesNode = xmlDocument.SelectSingleNode("/entities");
            if (entitiesNode == null)
            {
                Console.WriteLine("Entities node not found in the XML document.");
                return;
            }

            XmlElement characterElement = xmlDocument.CreateElement("character");

            XmlElement nameElement = xmlDocument.CreateElement("Name");
            nameElement.InnerText = character.Name;
            characterElement.AppendChild(nameElement);

            XmlElement lvlElement = xmlDocument.CreateElement("Lvl");
            lvlElement.InnerText = character.Lvl.ToString();
            characterElement.AppendChild(lvlElement);

            XmlElement atkElement = xmlDocument.CreateElement("Atk");
            atkElement.InnerText = character.Atk.ToString();
            characterElement.AppendChild(atkElement);

            XmlElement hpElement = xmlDocument.CreateElement("Hp");
            hpElement.InnerText = character.Hp.ToString();
            characterElement.AppendChild(hpElement);

            XmlElement defElement = xmlDocument.CreateElement("Def");
            defElement.InnerText = character.Def.ToString();
            characterElement.AppendChild(defElement);

            entitiesNode.AppendChild(characterElement);

            xmlDocument.Save(PATH);
            xmlDocument.Load(PATH);
        }

        public List<Character> GetAllCharacters()
        {
            List<Character> characters = new List<Character>();

            if (xmlDocument == null)
            {
                Console.WriteLine("XML document is not initialized.");
                return characters;
            }

            XmlNodeList characterNodes = xmlDocument.SelectNodes("/entities/character");
            if (characterNodes == null || characterNodes.Count == 0)
            {
                Console.WriteLine("No character nodes found in the XML document.");
                return characters;
            }

            foreach (XmlNode node in characterNodes)
            {
                Character character = new Character();
                character.Name = node.SelectSingleNode("Name").InnerText;
                character.Lvl = int.Parse(node.SelectSingleNode("Lvl").InnerText);
                character.Atk = int.Parse(node.SelectSingleNode("Atk").InnerText);
                character.Hp = int.Parse(node.SelectSingleNode("Hp").InnerText);
                character.Def = int.Parse(node.SelectSingleNode("Def").InnerText);
                characters.Add(character);
            }

            return characters;
        }

        public void ModifyCharacter(Character character)
        {
            if (xmlDocument == null)
            {
                Console.WriteLine("XML document is not initialized.");
                return;
            }

            XmlNodeList characterNodes = xmlDocument.SelectNodes("/entities/character");
            if (characterNodes == null || characterNodes.Count == 0)
            {
                Console.WriteLine("No character nodes found in the XML document.");
                return;
            }

            foreach (XmlNode node in characterNodes)
            {
                if (node.SelectSingleNode("Name").InnerText == character.Name)
                {
                    node.SelectSingleNode("Name").InnerText = character.Name.ToString();
                    node.SelectSingleNode("Lvl").InnerText = character.Lvl.ToString();
                    node.SelectSingleNode("Atk").InnerText = character.Atk.ToString();
                    node.SelectSingleNode("Hp").InnerText = character.Hp.ToString();
                    node.SelectSingleNode("Def").InnerText = character.Def.ToString();
                    break;
                }
            }

            xmlDocument.Save(PATH);
            xmlDocument.Load(PATH);
        }
    }
}
