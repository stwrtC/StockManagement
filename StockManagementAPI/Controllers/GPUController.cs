using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StockManagementLibraries.Repositories;
using StockManagementLibraries;
using StockManagementLibraries.Models;
using StockManagementLibraries.Logging;

namespace StockManagement.API.Controllers
{
    [ApiController]
    [Route("api/gpus")]
    public class GPUController : Controller
    {
        public readonly IStockRepository<GPU> _gpuRepository;
        private readonly ILogger _log;

        public GPUController(IStockRepository<GPU> gpuRepository, ILogger<LaptopController> log)
        {
            _gpuRepository = gpuRepository;
            _log = log;
        }
        [HttpGet]
        public ActionResult<IEnumerable<GPU>> GetAll()
        {
            _log.LogInformation($"{LogStrings.DefaultMessage}{LogStrings.Http200}");
            return Ok(_gpuRepository.GetAll());
        }
        [HttpGet("{id}", Name = "GetGPU")]
        public ActionResult<GPU> GetGPU(int id)
        {
            if (_gpuRepository.GetById(id) == null)
            {
                _log.LogError($"{LogStrings.RequestFailed}{LogStrings.Http404}");
                return NotFound("ID does not exist");
            }
            _log.LogInformation($"{LogStrings.DefaultMessage}{LogStrings.Http200}");
            return Ok(_gpuRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult<GPU> Create([FromBody] GPU entity)
        {
            var newItem = new GPU()
            {
                Name = entity.Name,
                Brand = entity.Brand,
                Description = entity.Description,
                Quantity = entity.Quantity,
                Price = entity.Price,
                Vram = entity.Vram,
                Cuda = entity.Cuda
            };
            _gpuRepository.Add(newItem);
            
            if(ModelState.IsValid)
            {
                _log.LogInformation($"{LogStrings.RequestSuccessful}{LogStrings.Http201}");

            }

            return CreatedAtRoute("GetGPU",
                new
                {
                    id = newItem.Id
                },
                newItem);


        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_gpuRepository.GetById(id) == null)
            {
                _log.LogError($"{LogStrings.RequestFailed}{LogStrings.Http404}");
                return NotFound("ID does not exist");
            }
            _gpuRepository.Delete(id);
            _log.LogInformation($"{LogStrings.DefaultMessage}{LogStrings.Http200}");
            return Ok($"Item with ID number {id} has been deleted");

        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<GPU> patchDocument)
        {
            var item = _gpuRepository.GetById(id);
            if (item == null)
            {
                _log.LogError($"{LogStrings.RequestFailed}{LogStrings.Http404}");
                return NotFound();
            }

            var newItem = new GPU()
            {
                Name = item.Name,
                Brand = item.Brand,
                Quantity = item.Quantity,
                Price = item.Price,
                Vram = item.Vram,
                Cuda = item.Cuda

            };
            patchDocument.ApplyTo(newItem, ModelState);

            if (!ModelState.IsValid)
            {
                _log.LogError($"{LogStrings.RequestFailed}{LogStrings.Http400}");
                return BadRequest();
            }

            item.Name = newItem.Name;
            item.Brand = newItem.Brand;
            item.Description = newItem.Description;
            item.Quantity = newItem.Quantity;
            item.Price = newItem.Price;
            item.Vram = newItem.Vram;
            item.Cuda = newItem.Cuda;

            _log.LogInformation($"{LogStrings.RequestSuccessful}{LogStrings.Http204}");
            return NoContent();
        }


    }
}
