using System.Runtime.Serialization;
using System.Collections.Generic;
namespace Utilities.Feedback
{
    [DataContract]
    public class FeedBack
    {
        [DataMember(Name = "Feedback")]
       public List<FeedBackItem> FeedBackItems { get; set; }
    }
    [DataContract]
    public class FeedBackItem
    {
        [DataMember(Order = 1)]
        public string Type { get; set; }
        [DataMember(Order = 2)]
        public string Location { get; set; }
        [DataMember(Order = 3)]
        public string Description { get; set; }
        [DataMember(Order = 4)]
        public string Recommendation { get; set; }
    }
}
