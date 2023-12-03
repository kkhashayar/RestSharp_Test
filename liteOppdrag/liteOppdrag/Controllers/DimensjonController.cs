using liteOppdrag.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace liteOppdrag.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DimensjonController : ControllerBase
    {
        private readonly IDimensjonService _dimensjonService;

        public DimensjonController(IDimensjonService dimensjonService)
        {
            this._dimensjonService = dimensjonService;
        }


        [HttpGet]
        public async Task<IActionResult> GetDimensjoner()
        {
            var dimensions = await _dimensjonService.GetDimensjonerAsync();
            return Ok(dimensions);
        }
    }
}
