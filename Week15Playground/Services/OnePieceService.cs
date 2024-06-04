using Dasync.Collections;
using System.Collections.Concurrent;
using Week15Playground.Data.Interfaces;
using Week15Playground.Models;
using Week15Playground.Services.Interfaces;

namespace Week15Playground.Services
{
    public class OnePieceService : IOnePieceService
    {
        private readonly IOnePieceData _data;
        public OnePieceService(IOnePieceData data)
        {
            _data = data;
        }
        public async Task<List<ChapterResponse>> GetChapters()
        {
            return await _data.GetChapters();
        }
        public async Task<List<DevilFruitResponse>> GetDevilFruits()
        {
            return await _data.GetDevilFruits();
        }
        public async Task<List<SagaResponse>> GetSagas()
        {
            return await _data.GetSagas();
        }
        public async Task<List<EpisodeResponse>> GetEpisodes()
        {
            return await _data.GetEpisodes();
        }
        public async Task<List<CharacterResponse>> GetCharactersByCrewId(int crewId)
        {
            return await _data.GetCharactersByCrewId(crewId);
        }
        public async Task<List<CharacterResponse>> GetCharactersByCrewNameParallel(string crewName)
        {
            var result = new List<CharacterResponse>();
            var crews = await _data.GetCrews();
            var crewBag = crews;
            await crewBag.ParallelForEachAsync(async crew =>
            {
                if (crew.Name == crewName)
                {
                    result = await _data.GetCharactersByCrewId(crew.Id);
                }
            }, maxDegreeOfParallelism: crewBag.Count);
            return result ?? new List<CharacterResponse>();
        }
        public async Task<List<CharacterResponse>> GetCharactersByCrewName(string crewName)
        {
            var crews = await _data.GetCrews();
            foreach (var crew in crews)
            {
                if (crew.Name == crewName)
                {
                    return await _data.GetCharactersByCrewId(crew.Id);
                }
            }
            return new List<CharacterResponse>();
        }
    }
}
//GetCharactersByCrewId(int crewId)