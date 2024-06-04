namespace Week15Playground.Models
{
    public class EpisodeResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string Chapter { get; set; }
        public DateTime release_date {get;set;}
        public SagaResponse Saga {get;set;}
        public ArcResponse Arc {get;set;}
    }
}
