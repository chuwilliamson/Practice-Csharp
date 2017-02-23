using Dialogue.Xml;
using System.Xml.Serialization;
using System.IO;
using System;
namespace CombatForms
{
    class DialogueManager
    {
        DialogueManager()
        {
            tree = new DialogueTree();
            XmlSerializer serializer = new XmlSerializer(typeof(DialogueTree));

            using(Stream reader = new FileStream(inFile, FileMode.Open))
            {
                tree = (DialogueTree)serializer.Deserialize(reader);

            }
        }
        public string inFile
        {
            get { return "/Saves/NewDialogue.xml"; }
        }
        public static DialogueManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new DialogueManager();

                }
                return instance;
            }
        }

        private static DialogueManager instance;
        public DialogueTree tree
        {
            get; set;
        }

    }
}
