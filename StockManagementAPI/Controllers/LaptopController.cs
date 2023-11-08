using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StockManagementLibraries.Repositories;
using StockManagementLibraries;
using StockManagementLibraries.Models;
using log4net;
using StockManagementLibraries.Logging;

namespace StockManagement.API.Controllers
{
    [ApiController]
    [Route("api/laptops")]
    public class LaptopController : ControllerBase
    {
        public readonly IStockRepository<Laptop> _laptopRepository;
        private readonly ILogger _log;

        public LaptopController(IStockRepository<Laptop> laptopRepository, ILogger<LaptopController> log)
        {
            _laptopRepository = laptopRepository;
            _log = log;            
        }

        [HttpGet]
        public ActionResult<IEnumerable<Laptop>> GetAll()
        {
            _log.LogInformation($"{LogStrings.DefaultMessage}{LogStrings.Http200}");
            return Ok(_laptopRepository.GetAll());
        }
        [HttpGet("{id}", Name = "GetLaptop")]
        public ActionResult<Laptop> GetLaptop(int id)
        {
            if (_laptopRepository.GetById(id) == null)
            {
                _log.LogError($"{LogStrings.RequestFailed}{LogStrings.Http404}");
                return NotFound("ID does not exist");
            }
            _log.LogInformation($"{LogStrings.DefaultMessage}{LogStrings.Http200}");
            return Ok(_laptopRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult<Laptop> Create([FromBody] Laptop entity)
        {
            var newItem = new Laptop()
            {
                Name = entity.Name,
                Brand = entity.Brand,
                Description = entity.Description,
                Quantity = entity.Quantity,
                Price = entity.Price,
                ScreenSize = entity.ScreenSize,
                Ram = entity.Ram,
                Storage = entity.Storage
            };
            _laptopRepository.Add(newItem);

            if (ModelState.IsValid)
            {
                _log.LogInformation($"{LogStrings.RequestSuccessful}{LogStrings.Http201}");

            }

            return CreatedAtRoute("GetLaptop",
                new
                {
                    id = newItem.Id
                },
                newItem);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_laptopRepository.GetById(id) == null)
            {
                _log.LogError($"{LogStrings.RequestFailed}{LogStrings.Http404}");
                return NotFound("ID does not exist");
            }
            _laptopRepository.Delete(id);
            _log.LogInformation($"{LogStrings.DefaultMessage}{LogStrings.Http200}");
            return Ok($"Item with ID number {id} has been deleted");
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<Laptop> patchDocument)
        {
            var item = _laptopRepository.GetById(id);
            if (item == null)
            {
                _log.LogError($"{LogStrings.RequestFailed}{LogStrings.Http404}");
                return NotFound();
            }

            var newItem = new Laptop()
            {
                Name = item.Name,
                Brand = item.Brand,
                Quantity = item.Quantity,
                Price = item.Price,
                ScreenSize = item.ScreenSize,
                Ram = item.Ram,
                Storage = item.Storage

            };
            patchDocument.ApplyTo(newItem, ModelState);

            if(!ModelState.IsValid)
            {
                _log.LogError($"{LogStrings.RequestFailed}{LogStrings.Http400}");
                return BadRequest();
            }

            item.Name = newItem.Name;
            item.Brand = newItem.Brand;
            item.Description = newItem.Description;
            item.Quantity = newItem.Quantity;
            item.Price = newItem.Price;
            item.ScreenSize = newItem.ScreenSize;
            item.Storage = newItem.Storage;
            item.Ram = newItem.Ram;
            _log.LogInformation($"{LogStrings.RequestSuccessful}{LogStrings.Http204}");
            return NoContent();
        }
    }
}
