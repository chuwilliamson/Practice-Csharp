using Integration.Interfaces;
using Manatee.Trello;
using Manatee.Trello.ManateeJson;
using Manatee.Trello.WebApi;
using System;
namespace Integration.Tests
{
    public class TestTrello : ITestable
    {
        public TestTrello()
        {

        }

        public void Run()
        {
            string appkey = "16dd83fb7ecf4ffcc19a19491674100f";
            string secret = "bd1a0e9339cddaa21c64895ecdd8748880e7c49fde99da99d4e07f9e456f7615";

            var serializer = new ManateeSerializer();
            TrelloConfiguration.Serializer = serializer;
            TrelloConfiguration.Deserializer = serializer;
            TrelloConfiguration.JsonFactory = new ManateeFactory();
            TrelloConfiguration.RestClientProvider = new WebApiClientProvider();
            TrelloAuthorization.Default.AppKey = appkey;
            TrelloAuthorization.Default.UserToken = secret;
            string studentworklogid = "5693dcababc42ff7503d8271";
            var board = new Board(studentworklogid);
            var cards = board.Cards;
            foreach(var card in board.Cards)
                Console.WriteLine(card);

        }
    }
}
