using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("{id}")]
        public ActionResult<Laptop> GetLaptop(int id)
        {
            if(_laptopRepository.GetById(id) == null)
            {
                return NotFound();
            }
            return Ok(_laptopRepository.GetById(id));
        }

    }
}
