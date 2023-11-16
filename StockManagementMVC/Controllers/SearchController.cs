using Microsoft.AspNetCore.Mvc;
using StockManagementLibraries.Models;
using StockManagementLibraries.Repositories;

namespace StockManagementMVC.Controllers
{
    public class SearchController : Controller
    {

        public readonly IStockRepository<GPU> _gpuRepository;
        public readonly IStockRepository<Laptop> _laptopRepository;

        public SearchController(IStockRepository<GPU> gpuRepository, IStockRepository<Laptop> laptopRepository)
        {
            _gpuRepository = gpuRepository;
            _laptopRepository = laptopRepository;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
