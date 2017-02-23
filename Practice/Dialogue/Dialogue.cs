using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace Dialogue.Json
{
    [DataContract]
    public class Conversation
    {
        [DataMember(Name = "Converstaion")]
        public List<Dialogue> DialogueConversation { get; set; }
    }
    [DataContract]
    public class Dialogue
    {

        [DataMember(Name = "Conversation ID")]
        public string ConversationID { get; set; }

        [DataMember(Name = "Participant Name")]
        public string ParticipantName { get; set; }

        [DataMember(Name = "Emote Type")]
        public string EmoteType { get; set; }

        [DataMember(Name = "Side")]
        public string Side { get; set; }

        [DataMember(Name = "Line")]
        public string Line { get; set; }

        [DataMember(Name = "Speciality Animation")]
        public string SpecialityAnimation { get; set; }

        [DataMember(Name = "Specialty Camera")]
        public string SpecialtyCamera { get; set; }

        [DataMember(Name = "Participants")]
        public object Participants { get; set; }

        [DataMember(Name = "Conversation Summary")]
        public string ConversationSummary { get; set; }
    }
}

namespace Dialogue.Xml
{
    [XmlRoot(ElementName = "DialogueTree")]
    public class DialogueTree
    {

        [XmlElement(ElementName = "DialogueRoot")]
        public List<DialogueRoot> DialogueRoots
        {
            get;
            set;
        }
        int _index = 0;
        public DialogueRoot GetRoot(int index)
        {
            _index = index;
            return DialogueRoots[index];
        }
        public DialogueRoot Current
        {
            get { return DialogueRoots[_index]; }
        }
        public DialogueRoot Next
        {
            get
            {
                _index = _index + 1;
                if(_index >= DialogueRoots.Count)
                {
                    _index = DialogueRoots.Count;
                }
                return DialogueRoots[_index];
            }
        }
    }

    [XmlRoot(ElementName = "DialogueRoot")]
    public class DialogueRoot
    {
        public DialogueRoot()
        {
            _dialogueIndex = 0;
            DialogueNodes = new List<DialogueNode>();
        }

        public DialogueRoot(List<DialogueNode> dialogueNodes) : this()
        {
            DialogueNodes = dialogueNodes;
        }

        [XmlElement(ElementName = "DialogueNode")]
        public List<DialogueNode> DialogueNodes
        {
            get; set;
        }

        private int _dialogueIndex = 0;

        public DialogueNode Next
        {
            get
            {
                _dialogueIndex = _dialogueIndex + 1;
                if(_dialogueIndex >= DialogueNodes.Count)
                    _dialogueIndex = DialogueNodes.Count - 1;

                return DialogueNodes[_dialogueIndex];
            }
        }

        public DialogueNode Current
        {
            get
            {
                return DialogueNodes[_dialogueIndex];
            }
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


        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}", ConversationID, ParticipantName, EmoteType, Line);
        }

        [XmlElement(ElementName = "ConversationID")]
        public string ConversationID
        {
            get; set;
        }
        [XmlElement(ElementName = "ParticipantName")]
        public string ParticipantName
        {
            get; set;
        }
        [XmlElement(ElementName = "EmoteType")]
        public string EmoteType
        {
            get; set;
        }
        [XmlElement(ElementName = "Side")]
        public string Side
        {
            get; set;
        }
        [XmlElement(ElementName = "Line")]
        public string Line
        {
            get; set;
        }
        [XmlElement(ElementName = "SpecialityAnimation")]
        public string SpecialityAnimation
        {
            get; set;
        }
        [XmlElement(ElementName = "SpecialtyCamera")]
        public string SpecialtyCamera
        {
            get; set;
        }
        [XmlElement(ElementName = "Participants")]
        public string Participants
        {
            get; set;
        }
        [XmlElement(ElementName = "ConversationSummary")]
        public string ConversationSummary
        {
            get; set;
        }
    }
}
