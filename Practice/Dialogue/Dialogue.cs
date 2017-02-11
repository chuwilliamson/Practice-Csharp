using System.Collections.Generic;
using System.Xml.Serialization;
namespace Dialogue
{
    [XmlRoot(ElementName = "DialogueTree")]
    public class DialogueTree
    {
        [XmlElement(ElementName = "DialogueRoot")]
        public List<DialogueRoot> DialogueRoots {
            get;
            set;
        }
    }
    [XmlRoot(ElementName = "DialogueRoot")]
    public class DialogueRoot
    {
        public DialogueRoot()
        {
            DialogueNodes = new List<DialogueNode>();
        }
        public DialogueRoot(List<DialogueNode> dialogueNodes)
        {
            DialogueNodes = dialogueNodes;
        }
        [XmlElement(ElementName = "DialogueNode")]
        public List<DialogueNode> DialogueNodes {
            get; set;
        }
    }
    [XmlRoot(ElementName = "DialogueNode")]
    public class DialogueNode
    {    

        DialogueNode _current;

        public DialogueNode()
        {    
            _current = this;     
            ConversationID = "";
            ParticipantName = "";
            EmoteType = "";
            Side = "";
            Line = "";
            SpecialityAnimation = "";
            SpecialtyCamera = "";
            Participants = "";
            ConversationSummary = "";
        }

        DialogueNode(string id, string p, string e, string side, string line) : this()
        {
            ConversationID = id;
            ParticipantName = p;
            EmoteType = "";
            Side = side;
            Line = line;
            SpecialityAnimation = "";
            SpecialtyCamera = "";
            Participants = "0";
            ConversationSummary = "";
        }
        
        public DialogueNode Next {
            get {
                return null;
            }
        }

        [XmlElement(ElementName = "ConversationID")]
        public string ConversationID {
            get; set;
        }
        [XmlElement(ElementName = "ParticipantName")]
        public string ParticipantName {
            get; set;
        }
        [XmlElement(ElementName = "EmoteType")]
        public string EmoteType {
            get; set;
        }
        [XmlElement(ElementName = "Side")]
        public string Side {
            get; set;
        }
        [XmlElement(ElementName = "Line")]
        public string Line {
            get; set;
        }
        [XmlElement(ElementName = "SpecialityAnimation")]
        public string SpecialityAnimation {
            get; set;
        }
        [XmlElement(ElementName = "SpecialtyCamera")]
        public string SpecialtyCamera {
            get; set;
        }
        [XmlElement(ElementName = "Participants")]
        public string Participants {
            get; set;
        }
        [XmlElement(ElementName = "ConversationSummary")]
        public string ConversationSummary {
            get; set;
        }
    }
}
