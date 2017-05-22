using Integration.Interfaces;
using Utilities.Feedback;
using System.Collections.Generic;
namespace Integration.Tests
{
    public class TestFeedback : ITestable
    {
        public TestFeedback() { }
        public void Run()
        {
            var f1 = new FeedBackItem()
            {
                Type = "Feature",
                Location = "Character Sheet  ",
                Description = "Tooltips for the selected items",
                Recommendation = "Not clear what i'm selecting when highlighting the items in the dropdown lists."
            };
            var f2 = new FeedBackItem()
            {
                Type = "Feature",
                Location = "Game Rules",
                Description = "Number of Players box label field is too long. Is it required for the box to accommodate for a number of players that would fill this box.",
                Recommendation = "Make the box large enough to only allow a player amount from the ranges 0-9"
            };
            var f3 = new FeedBackItem()
            {
                Type = "Feature",
                Location = "Game Rules",
                Description = "Player can click in the Description box. Is the user supposed to be able to type here?",
                Recommendation = "Make the box readonly without interaction or make it a label."
            };
            var f4 = new FeedBackItem()
            {
                Type = "Bug",
                Location = "Entire Program",
                Description = "Going from Character Sheet to Main Menu does not close out the Character Sheet... This will make multiple instances of the game....",
                Recommendation = "lol... "
            };
            var fb = new FeedBack() { FeedBackItems = new List<FeedBackItem>() { f1, f2, f3, f4 } };
            Utilities.Serialization.Json.Save("jbarzas01", fb );
        }
    }
}
