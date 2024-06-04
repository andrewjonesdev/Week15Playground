using Week15Playground.Models.Interfaces;

namespace Week15Playground.Models
{
    public class OnePieceApiSettings : IOnePieceApiSettings
    {
        public string? BaseUrl { get; set; } = string.Empty;
    }
}
