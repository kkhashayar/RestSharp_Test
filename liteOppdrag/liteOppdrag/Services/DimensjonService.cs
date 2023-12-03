using liteOppdrag.Dtos;

namespace liteOppdrag.Services
{
    public class DimensjonService : IDimensjonService
    {
        private readonly IVaApiHttpClientService _httpClientService;

        public DimensjonService(IVaApiHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<List<DimensjonDto>> GetDimensjonerAsync()
        {
            return await _httpClientService.GetAlleDimensjonerAsync();
        }
    }
}
