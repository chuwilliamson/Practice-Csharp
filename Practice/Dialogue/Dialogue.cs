using System.Collections.Generic;
using System.Xml.Serialization;
namespace Dialogue
{
    [XmlRoot(ElementName = "DialogueRoot")]
    public class DialogueRoot
    {
        public DialogueRoot()
        {
            DialogueNodes = new List<DialogueNode>();
        }
        public DialogueRoot(List<DialogueNode> dns)
        {
            DialogueNodes = dns;
        }
        [XmlElement(ElementName = "DialogueNode")]
        public List<DialogueNode> DialogueNodes {
            get; set;
        }
    }
    [XmlRoot(ElementName = "DialogueNode")]
    public class DialogueNode
    {

        List<DialogueNode> _children;

        DialogueNode _current;

        public DialogueNode()
        {
            _children = new List<DialogueNode>();
            _current = this;
            _children.Add(this);
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


        public void AddChild(DialogueNode n)
        {
            _children.Add(n);
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
