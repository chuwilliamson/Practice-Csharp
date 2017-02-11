using Abilities;
using System;
using Stats;
using Utilities;
using Dialogue;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Integration
{ 
    class Program
    {
        static void Main(string[] arguments)
        {
            DialogueRoot dr;
            XmlSerializer serializer = new XmlSerializer(typeof(DialogueRoot));
            string file = Environment.CurrentDirectory + "/Dialogue.xml";
            using(Stream reader = new FileStream(file, FileMode.Open)) {
                dr = (DialogueRoot)serializer.Deserialize(reader);                
            }
            
            Dictionary<string, List<DialogueNode>> dialogueTree = new Dictionary<string, List<DialogueNode> >();
            foreach(DialogueNode d in dr.DialogueNodes) {
                if(dialogueTree.ContainsKey(d.ConversationID)) {
                    dialogueTree[d.ConversationID].Add(d);
                }
                else {
                    dialogueTree.Add(d.ConversationID, new List<DialogueNode>() { d });
                }               
            }

            List<DialogueRoot> drs = new List<DialogueRoot>();
            foreach(KeyValuePair<string, List<DialogueNode>> kvp in dialogueTree) {                
                drs.Add(new DialogueRoot(kvp.Value)); 
            }
            DialogueTree dt = new DialogueTree();
            dt.DialogueRoots = drs;
            serializer = new XmlSerializer(typeof(DialogueTree));
            string newfile = Environment.CurrentDirectory + "/../../NewDialogue.xml";
            TextWriter writer = new StreamWriter(newfile);
            serializer.Serialize(writer, dt);
        }
       
    }
}
