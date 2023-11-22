using Microsoft.AspNetCore.Mvc;
using StockManagementLibraries.Models;

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

        //[Route("Home/Search/{searchBy}/{searchString}")]
        public IActionResult Search(string searchBy, string searchString)
        {
            List<Laptop> laptopResult = new List<Laptop>();
            List<GPU> gpuResult = new List<GPU>();
            switch (searchBy)
            {
                case "ID":
                    laptopResult = _laptopRepository.GetAll().Where(x => x.Id == int.Parse(searchString)).ToList();
                    gpuResult = _gpuRepository.GetAll().Where(x => x.Id == int.Parse(searchString)).ToList();
                    ViewBag.laptops = laptopResult;
                    ViewBag.gpus = gpuResult;
                    return View();

                case "Name":
                    laptopResult = _laptopRepository.GetAll().Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
                    gpuResult = _gpuRepository.GetAll().Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
                    ViewBag.laptops = laptopResult;
                    ViewBag.gpus = gpuResult;
                    return View();

                case "Brand":
                    laptopResult = _laptopRepository.GetAll().Where(x => x.Brand.ToLower().Contains(searchString.ToLower())).ToList();
                    gpuResult = _gpuRepository.GetAll().Where(x => x.Brand.ToLower().Contains(searchString.ToLower())).ToList();
                    ViewBag.laptops = laptopResult;
                    ViewBag.gpus = gpuResult;
                    return View();

            }
            return View();
        }

    }
}
