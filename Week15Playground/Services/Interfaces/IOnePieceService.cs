using Week15Playground.Models;

namespace Week15Playground.Services.Interfaces
{
    public interface IOnePieceService
    {
        public Task<List<ChapterResponse>> GetChapters();
        public Task<List<DevilFruitResponse>> GetDevilFruits();
        public Task<List<SagaResponse>> GetSagas();
        public Task<List<EpisodeResponse>> GetEpisodes();
        public Task<List<CharacterResponse>> GetCharactersByCrewId(int crewId);
        public Task<List<CharacterResponse>> GetCharactersByCrewNameParallel(string crewName);
        public Task<List<CharacterResponse>> GetCharactersByCrewName(string crewName);
    }
}
