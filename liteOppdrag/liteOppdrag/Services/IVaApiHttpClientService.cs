using liteOppdrag.Dtos;

namespace liteOppdrag.Services
{
    public interface IVaApiHttpClientService
    {
        Task<List<DimensjonDto>> GetAlleDimensjonerAsync();
    }
}
