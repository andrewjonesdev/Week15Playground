//     "arc": {
//       "id": "int",
//       "title": "string",
//       "description": "string",


namespace Week15Playground.Models
{
    public class ArcResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ArcResponse()
        {

        }
        public ArcResponse(int Id, string Title, string Description)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
        }
    }
}