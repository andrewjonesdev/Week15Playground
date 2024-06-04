using Week15Playground.Models;

namespace Week15Playground.Data.Interfaces
{
    public interface IOnePieceData
    {
        public Task<List<ChapterResponse>> GetChapters();
        public Task<List<DevilFruitResponse>> GetDevilFruits();
        public Task<List<SagaResponse>> GetSagas();
        public Task<List<EpisodeResponse>> GetEpisodes();
        public Task<List<CharacterResponse>> GetCharactersByCrewId(int crewId);
        public Task<List<CrewResponse>> GetCrews();
    }
}
