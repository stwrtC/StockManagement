using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StockManagementLibraries.Repositories;
using StockManagementLibraries;
using StockManagementLibraries.Models;


namespace StockManagement.API.Controllers
{
    [ApiController]
    [Route("api/laptops")]
    public class LaptopController : Controller
    {
        public readonly IStockRepository<Laptop> _laptopRepository;

        public LaptopController(IStockRepository<Laptop> laptopRepository)
        {
            _laptopRepository = laptopRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Laptop>> GetAll()
        {
            return Ok(_laptopRepository.GetAll());
        }
        [HttpGet("{id}", Name = "GetLaptop")]
        public ActionResult<Laptop> GetLaptop(int id)
        {
            if (_laptopRepository.GetById(id) == null)
            {
                return NotFound("ID does not exist");
            }
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
                return NotFound("ID does not exist");
            }
            _laptopRepository.Delete(id);
            return Ok($"Item with ID number {id} has been deleted");
        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<Laptop> patchDocument)
        {
            var item = _laptopRepository.GetById(id);
            if (item == null)
            {
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
            return NoContent();
        }
    }
}
