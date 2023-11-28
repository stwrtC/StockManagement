using Microsoft.AspNetCore.Mvc;
using StockManagementMVC.ViewModels;
using StockManagementLibraries.Models;
using log4net;
using StockManagementLibraries.Logging;
using StockManagementLibraries.Repositories;
using System.Net.WebSockets;

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

        public ViewResult List()
        {
            ListViewModel<Laptop> laptopListViewModel = new ListViewModel<Laptop>(_laptopRepository.GetAll());
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
            ItemViewModel<Laptop> model = new ItemViewModel<Laptop>(item)
            {
                Item = item
            };
            return View(model);
        }
        [Route("Laptop/ConfirmDelete/{id}")]
        public IActionResult ConfirmDelete(int id)
        {
            var item = _laptopRepository.GetById(id);
            ItemViewModel<Laptop> model = new ItemViewModel<Laptop>(item)
            {
                Item = item
            };
            _laptopRepository.Delete(id);
            _log.LogInformation($"{LogStrings.DefaultMessage}{LogStrings.Http200}");
            return View(model);
        }

        [HttpGet, Route("Laptop/Update/{id}")]
        public IActionResult Update(int id)
        {
            var item = _laptopRepository.GetById(id);
            var viewModel = new UpdateViewModel<Laptop>();
            viewModel.Item = item;
            viewModel.UpdatedItem = new Laptop();

            return View(viewModel);
        }

        [HttpPost,Route("Laptop/Update/{id}")]
        public IActionResult Update(int id,UpdateViewModel<Laptop> model)
        {

            var old = _laptopRepository.GetById(id);
            var updated = model.UpdatedItem;


            if (!string.IsNullOrEmpty(updated.Name))
            {
                old.Name = updated.Name;
            }
            if (!string.IsNullOrEmpty(updated.Brand))
            {
                old.Brand = updated.Brand;
            }
            if (!string.IsNullOrEmpty(updated.Description))
            {
                old.Description = updated.Description;
            }
            if ( updated.Quantity != 0)
            {
                old.Quantity = updated.Quantity;
            }
            if (updated.Price != 0)
            {
                old.Price = updated.Price;
            }
            if (updated.ScreenSize != 0)
            {
                old.ScreenSize = updated.ScreenSize;
            }
            if (updated.Storage != 0)
            {
                old.Storage = updated.Storage;
            }
            if (updated.Ram != 0)
            {
                old.Ram = updated.Ram;
            }
            if (updated.ImageThumbnail != null)
            {
                old.ImageThumbnail = updated.ImageThumbnail;
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
            ItemViewModel<Laptop> model = new ItemViewModel<Laptop>(item)
            {
                Item = item
            };

            return View(model);
        }

    }
}
