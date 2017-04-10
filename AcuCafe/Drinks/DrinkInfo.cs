using System.Collections.Generic;
using AcuCafe.Topics;

namespace AcuCafe.Drinks
{
    public class DrinkInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public IEnumerable<TopicInfo> AllowedTopics { get; set; } 
    }
}