using Microsoft.AspNetCore.Mvc;
using StockManagementLibraries.Models;
using StockManagementMVC.ViewModels;

namespace StockManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        public readonly IStockRepository<GPU> _gpuRepository;
        public readonly IStockRepository<Laptop> _laptopRepository;

        public HomeController(IStockRepository<GPU> gpuRepository, IStockRepository<Laptop> laptopRepository)
        {
            _gpuRepository = gpuRepository;
            _laptopRepository = laptopRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string searchBy, string searchString)
        {
            List<Laptop> laptopResult = new List<Laptop>();
            List<GPU> gpuResult = new List<GPU>();
            SearchViewModel model = new SearchViewModel(searchBy, searchString, gpuResult, laptopResult);
            switch (searchBy)
            {
                case "ID":
                    laptopResult = _laptopRepository.GetAll().Where(x => x.Id.ToString() == searchString).ToList();
                    gpuResult = _gpuRepository.GetAll().Where(x => x.Id.ToString() == searchString).ToList();
                    model.Laptops = laptopResult;
                    model.GPUs = gpuResult;
                    return View(model);

                case "Name":
                    laptopResult = _laptopRepository.GetAll().Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
                    gpuResult = _gpuRepository.GetAll().Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
                    model.Laptops = laptopResult;
                    model.GPUs = gpuResult;
                    return View(model);

                case "Brand":
                    laptopResult = _laptopRepository.GetAll().Where(x => x.Brand.ToLower().Contains(searchString.ToLower())).ToList();
                    gpuResult = _gpuRepository.GetAll().Where(x => x.Brand.ToLower().Contains(searchString.ToLower())).ToList();
                    model.Laptops = laptopResult;
                    model.GPUs = gpuResult;
                    return View(model);

            }
            return View();
        }

    }
}
