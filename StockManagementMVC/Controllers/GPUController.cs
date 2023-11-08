using Microsoft.AspNetCore.Mvc;
using StockManagementLibraries.Models;

namespace StockManagementMVC.Controllers
{
    public class GPUController : Controller
    {
        public readonly IStockRepository<GPU> _gpuRepository;

        public GPUController(IStockRepository<GPU> gpuRepository)
        {
            _gpuRepository = gpuRepository;
        }

        public IActionResult Index()
        {
            return View(_gpuRepository.GetAll());
        }
    }
}
