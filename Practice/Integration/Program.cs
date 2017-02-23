 
using Utilities.Serialization;
using System.Collections.Generic;
using System.Linq;
namespace Integration
{
    class Program
    { 
        static void Main(string[] arguments)
        {
            var json = Json.Load<Dialogue.Json.Conversation>("Dialogue");
            //var con1 = json.Where(x => x.ConversationID.Contains("001"));
            //var extractedModels = json.Where(m => m.ParticipantName == "Mutt");

        }
    }
}
