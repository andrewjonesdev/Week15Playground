namespace Week15Playground.Models
{
    public class ChapterResponse
    {
        public int Id { get; set; }
        public  string Chapter_number { get; set; }
        public string  Title { get; set; }
        public string Description { get; set; }
        public TomeResponse Tome { get; set; }
    }
}
