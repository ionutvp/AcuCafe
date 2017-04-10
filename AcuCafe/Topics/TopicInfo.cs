namespace AcuCafe.Topics
{
    public class TopicInfo
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public string Name { get; set; }
        public string WithoutMessage => $"without {Name}";
        public string WithMessage => $"with {Name}";
    }
}