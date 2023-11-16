using Microsoft.AspNetCore.Mvc;
using StockManagementMVC.ViewModels;
using StockManagementLibraries.Models;
using log4net;
using StockManagementLibraries.Logging;
using StockManagementLibraries.Repositories;

namespace StockManagementMVC.Controllers
{
    public class LaptopController : Controller
    {
        public readonly IStockRepository<Laptop> _laptopRepository;
        private readonly ILogger _log;


        public LaptopController(IStockRepository<Laptop> laptopRepository, ILogger<LaptopController> log)
        {
            _laptopRepository = laptopRepository;
            _log = log;
        }

        public IActionResult List()
        {
            LaptopListViewModel laptopListViewModel = new LaptopListViewModel(_laptopRepository.GetAll());
            _log.LogInformation($"{LogStrings.DefaultMessage}{LogStrings.Http200}");
            return View(laptopListViewModel);

        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult<Laptop> Create(Laptop entity)
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

            if (ModelState.IsValid)
            {
                _laptopRepository.Add(newItem);
                _log.LogInformation($"{LogStrings.RequestSuccessful}{LogStrings.Http201}");
                return RedirectToAction("List");
            }

            return View(newItem);
        }

        [Route("Laptop/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var item = _laptopRepository.GetById(id);
            ViewBag.item = item;
            return View();
        }
        [Route("Laptop/ConfirmDelete/{id}")]
        public IActionResult ConfirmDelete(int id)
        {
            var item = _laptopRepository.GetById(id);
            ViewBag.item = item;
            _laptopRepository.Delete(id);
            _log.LogInformation($"{LogStrings.DefaultMessage}{LogStrings.Http200}");
            return View();
        }

        [Route("Laptop/Update/{id}")]
        public IActionResult Update(int id)
        {
            var item = _laptopRepository.GetById(id);
            ViewBag.item = item;

            return View();
        }

        [HttpPost,Route("Laptop/Update/{id}")]
        public IActionResult Update(int id, Laptop entity)
        {
            var old = _laptopRepository.GetById(id);

            if(!String.IsNullOrEmpty(entity.Name))
            {
                old.Name = entity.Name;
            }
            if (!String.IsNullOrEmpty(entity.Brand))
            {
                old.Brand = entity.Brand;
            }
            if (!String.IsNullOrEmpty(entity.Description))
            {
                old.Description = entity.Description;
            }
            if ( entity.Quantity != 0)
            {
                old.Quantity = entity.Quantity;
            }
            if (entity.Price != 0)
            {
                old.Price = entity.Price;
            }
            if (entity.ScreenSize != 0)
            {
                old.ScreenSize = entity.ScreenSize;
            }
            if (entity.Storage != 0)
            {
                old.Storage = entity.Storage;
            }
            if (entity.Ram != 0)
            {
                old.Ram = entity.Ram;
            }


            _laptopRepository.Update(old);
            return RedirectToAction("List");
        }

        [Route("Laptop/Details/{id}")]

        public IActionResult Details(int id)
        {
            var item = _laptopRepository.GetById(id);
            if(item == null)
            {
                return NotFound();
            }
            ViewBag.item = item;

            return View(item);
        }

    }
}
