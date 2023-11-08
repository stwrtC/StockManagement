using Microsoft.AspNetCore.Mvc;
using StockManagementMVC.ViewModels;
using StockManagementLibraries.Models;

namespace StockManagementMVC.Controllers
{
    public class LaptopController : Controller
    {
        public readonly IStockRepository<Laptop> _laptopRepository;

        public LaptopController(IStockRepository<Laptop> laptopRepository)
        {
            _laptopRepository = laptopRepository;
        }

        public IActionResult List()
        {
            LaptopListViewModel laptopListViewModel = new LaptopListViewModel(_laptopRepository.GetAll());
            return View(laptopListViewModel);

        }
    }
}
