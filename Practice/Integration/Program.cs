using Integration.Tests;
using Utilities.Serialization; 
namespace Integration
{
    class Program
    { 
        static void Main(string[] arguments)
        {
            var json = Json.Load<Dialogue.Json.Conversation>("Dialogue");
            //var con1 = json.Where(x => x.ConversationID.Contains("001"));
            //var extractedModels = json.Where(m => m.ParticipantName == "Mutt");
            var f = new TestTrello();
            f.Run();
            
        }
    }
}
