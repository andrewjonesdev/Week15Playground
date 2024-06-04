using Flurl.Http;
using Polly.Retry;
using Polly;
using System.Net;
using Week15Playground.Data.Interfaces;
using Week15Playground.Models.Interfaces;
using Week15Playground.Models;
using Flurl;

namespace Week15Playground.Data
{
    public class OnePieceData : IOnePieceData
    {
        private readonly IOnePieceApiSettings _onePieceApiSettings;
        public OnePieceData(IOnePieceApiSettings onePieceApiSettings)
        {
            _onePieceApiSettings = onePieceApiSettings;
        }

        public async Task<List<ChapterResponse>> GetChapters()
        {
            var policy = BuildRetryPolicy();
            var url = String.IsNullOrEmpty(_onePieceApiSettings.BaseUrl) ? "https://api.api-onepiece.com".AppendPathSegments("v2", "chapters", "en") : _onePieceApiSettings.BaseUrl.AppendPathSegments("v2", "chapters", "en");
            var result = policy.ExecuteAsync(async () => await url.GetJsonAsync<List<ChapterResponse>>());
            return await result ?? new List<ChapterResponse>();

        }

        public async Task<List<DevilFruitResponse>> GetDevilFruits()
        {
            var policy = BuildRetryPolicy();
            var url = String.IsNullOrEmpty(_onePieceApiSettings.BaseUrl) ? "https://api.api-onepiece.com".AppendPathSegments("v2", "fruits", "en") : _onePieceApiSettings.BaseUrl.AppendPathSegments("v2", "fruits", "en");
            var result = policy.ExecuteAsync(async () => await url.GetJsonAsync<List<DevilFruitResponse>>());
            return await result ?? new List<DevilFruitResponse>();

        }

        public async Task<List<SagaResponse>> GetSagas()
        {
            var policy = BuildRetryPolicy();
            var url = String.IsNullOrEmpty(_onePieceApiSettings.BaseUrl) ? "https://api.api-onepiece.com".AppendPathSegments("v2", "sagas", "en") : _onePieceApiSettings.BaseUrl.AppendPathSegments("v2", "sagas", "en");
            var result = policy.ExecuteAsync(async () => await url.GetJsonAsync<List<SagaResponse>>());
            return await result ?? new List<SagaResponse>();

        }


        public async Task<List<EpisodeResponse>> GetEpisodes()
        {
            var policy = BuildRetryPolicy();
            var url = String.IsNullOrEmpty(_onePieceApiSettings.BaseUrl) ? "https://api.api-onepiece.com".AppendPathSegments("v2", "episodes", "en") : _onePieceApiSettings.BaseUrl.AppendPathSegments("v2", "episodes", "en");
            var result = policy.ExecuteAsync(async () => await url.GetJsonAsync<List<EpisodeResponse>>());
            return await result ?? new List<EpisodeResponse>();

        }
        public async Task<List<CrewResponse>> GetCrews()
        {
            var policy = BuildRetryPolicy();
            var url = String.IsNullOrEmpty(_onePieceApiSettings.BaseUrl) ? "https://api.api-onepiece.com".AppendPathSegments("v2", "crews", "en") : _onePieceApiSettings.BaseUrl.AppendPathSegments("v2", "crews", "en");
            var result = policy.ExecuteAsync(async () => await url.GetJsonAsync<List<CrewResponse>>());
            return await result ?? new List<CrewResponse>();

        }
        //https://api.api-onepiece.com/v2/characters/en/crew/{id}
        public async Task<List<CharacterResponse>> GetCharactersByCrewId(int crewId)
        {
            var policy = BuildRetryPolicy();
            var url = String.IsNullOrEmpty(_onePieceApiSettings.BaseUrl) ? "https://api.api-onepiece.com".AppendPathSegments("v2", "characters", "en", "crew", crewId) : _onePieceApiSettings.BaseUrl.AppendPathSegments("v2", "characters", "en", "crew", crewId);
            var result = policy.ExecuteAsync(async () => await url.GetJsonAsync<List<CharacterResponse>>());
            return await result ?? new List<CharacterResponse>();

        }

        private static bool IsTransientError(FlurlHttpException exception)
        {
            int[] httpStatusCodesWorthRetrying =
            {
            (int)HttpStatusCode.RequestTimeout,
            (int)HttpStatusCode.BadGateway,
            (int)HttpStatusCode.ServiceUnavailable,
            (int)HttpStatusCode.GatewayTimeout,
            (int)HttpStatusCode.TooManyRequests,
            (int)HttpStatusCode.BadRequest
        };

            return exception.StatusCode.HasValue && httpStatusCodesWorthRetrying.Contains(exception.StatusCode.Value);
        }

        private static AsyncRetryPolicy BuildRetryPolicy()
        {
            return Policy
                .Handle<FlurlHttpException>(IsTransientError)
                .WaitAndRetryAsync(10, retryAttempt =>
                {
                    var nextAttemptIn = TimeSpan.FromSeconds(Math.Pow(2, retryAttempt));
                    Console.WriteLine($"Retry attempt {retryAttempt} to make request. Next try on {nextAttemptIn.TotalSeconds} seconds.");
                    return nextAttemptIn;
                });
        }

    }
}
