using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StockManagementLibraries.Repositories;
using StockManagementLibraries;
using StockManagementLibraries.Models;



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
        [HttpGet("{id}", Name = "GetGPU")]
        public ActionResult<GPU> GetGPU(int id)
        {
            if (_gpuRepository.GetById(id) == null)
            {
                return NotFound("ID does not exist");
            }

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
                return NotFound("ID does not exist");
            }
            _gpuRepository.Delete(id);
            return Ok($"Item with ID number {id} has been deleted");

        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<GPU> patchDocument)
        {
            var item = _gpuRepository.GetById(id);
            if (item == null)
            {
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
                return BadRequest();
            }

            item.Name = newItem.Name;
            item.Brand = newItem.Brand;
            item.Description = newItem.Description;
            item.Quantity = newItem.Quantity;
            item.Price = newItem.Price;
            item.Vram = newItem.Vram;
            item.Cuda = newItem.Cuda;


            return NoContent();
        }


    }
}
