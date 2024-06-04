using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Week15Playground.Models;
using Week15Playground.Services;
using Week15Playground.Services.Interfaces;

namespace Week15Playground.Controllers
{
    [ApiController]
    [Route("api/onepieceapi")]
    public class OnePieceController : ControllerBase
    {
        private readonly ILogger<OnePieceController> _logger;
        private readonly IOnePieceService _service;
        public OnePieceController(ILogger<OnePieceController> logger, IOnePieceService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        [Route("/getchapters")]
        public async Task<List<ChapterResponse>> GetChapters()
        {
            return await _service.GetChapters();
        }
        [HttpGet]
        [Route("/getdevilfruits")]
        public async Task<List<DevilFruitResponse>> GetDevilFruits()
        {
            return await _service.GetDevilFruits();
        }
        [HttpGet]
        [Route("/getsagas")]
        public async Task<List<SagaResponse>> GetSagas()
        {
            return await _service.GetSagas();
        }

        [HttpGet]
        [Route("/getepisodes")]
        public async Task<List<EpisodeResponse>> GetEpisodes()
        {
            return await _service.GetEpisodes();
        }
        [HttpGet]
        [Route("/getcharactersbycrewid")]
        public async Task<List<CharacterResponse>> GetCharactersByCrewId(int crewId)
        {
            return await _service.GetCharactersByCrewId(crewId);
        }
        [HttpGet]
        [Route("/getcharactersbycrewnameparallel")]
        public async Task<List<CharacterResponse>> GetCharactersByCrewNameParallel(string crewName)
        {
            return await _service.GetCharactersByCrewNameParallel(crewName);
        }
        [HttpGet]
        [Route("/getcharactersbycrewname")]
        public async Task<List<CharacterResponse>> GetCharactersByCrewName(string crewName)
        {
            return await _service.GetCharactersByCrewName(crewName);
        }

    }
}
