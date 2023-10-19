using Microsoft.AspNetCore.Mvc;

namespace StockManagement.API.Controllers
{
    [ApiController]
    [Route("api/gpus")]
    public class GPUController : Controller
    {
        public readonly IStockRepository<GPU> _gpuRepository;

        public GPUController(IStockRepository<GPU> gpuRepository)
        {
            _gpuRepository = gpuRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<GPU>> GetAll()
        {
            return Ok(_gpuRepository.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<GPU> GetGPU(int id)
        {
            if (_gpuRepository.GetById(id) == null)
            {
                return NotFound("GPU ID not found");
            }

            return Ok(_gpuRepository.GetById(id));
        }
    }
}
