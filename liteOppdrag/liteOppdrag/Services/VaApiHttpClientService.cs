using liteOppdrag.Dtos;
using RestSharp;

namespace liteOppdrag.Services
{
    public class VaApiHttpClientService : IVaApiHttpClientService
    {
        private readonly RestClient _restClient;
        private readonly ILogger<VaApiHttpClientService> _logger;
        private readonly string? _apiToken;

        public VaApiHttpClientService(IConfiguration configuration, ILogger<VaApiHttpClientService> logger)
        {
            var baseUrl = configuration["BaseUrl"];
            _apiToken = configuration["ApiToken"];

            // Just to be sure! :| 
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentException("Base URL cannot be null or empty.", nameof(baseUrl));
            }

            if (string.IsNullOrWhiteSpace(_apiToken))
            {
                throw new ArgumentException("API token cannot be null or empty.", nameof(_apiToken));
            }


            _restClient = new RestClient(baseUrl);
            _logger = logger;

        }

        public async Task<List<DimensjonDto>> GetAlleDimensjonerAsync()
        {
            var request = new RestRequest("Dimensjon", Method.Get); // Update with the correct endpoint
            request.AddParameter("apitoken", _apiToken, ParameterType.QueryString);

            try
            {
                var response = await _restClient.ExecuteAsync<List<DimensjonDto>>(request);

                if (response is { IsSuccessful: true, Data: not null })
                {
                    return response.Data;
                }
                _logger.LogError("Error calling API: {StatusCode}, {Content}", response.StatusCode, response.Content);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while calling external API");
            }

            return null;
        }
    }

}
