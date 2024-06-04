namespace Week15Playground.Models
{
    public class CharacterResponse
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public string  Job { get; set; }
        public string Size { get; set; }
        public string Brithday { get; set; }
        public string Age { get; set; }
        public string Bounty { get; set; }
        public string Status { get; set; }
        public CrewResponse Crew { get; set; }
        public DevilFruitResponse DevilFruit { get; set; }

    }
}