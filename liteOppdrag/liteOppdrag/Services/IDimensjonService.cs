using liteOppdrag.Dtos;

namespace liteOppdrag.Services
{
    public interface IDimensjonService
    {
        Task<List<DimensjonDto>> GetDimensjonerAsync();
    }
}
