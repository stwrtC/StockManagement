using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockManagementLibraries.Models;
using StockManagementMVC.ViewModels;

namespace StockManagementMVC.Controllers
{
    public class ShipmentController : Controller
    {

        public readonly IStockRepository<Laptop> _laptopRepository;
        public readonly IStockRepository<GPU> _gpuRepository;

        private readonly ILogger _log;


        public ShipmentController(IStockRepository<Laptop> laptopRepository, IStockRepository<GPU> gpuRepository, ILogger<LaptopController> log)
        {
            _laptopRepository = laptopRepository;
            _gpuRepository = gpuRepository;
            _log = log;
        }


        public IActionResult Index(IFormFile file)
        {
            return View(file);
        }

        public async Task<IActionResult> ShipmentDetails(IFormFile file)
        {
            IEnumerable<Laptop> _laptops = new List<Laptop>();
            IEnumerable<GPU> _gpus = new List<GPU>();
            ShipmentViewModel model = new ShipmentViewModel(_gpus, _laptops);

            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("file", "Please select a file");
                return BadRequest(ModelState);
            }

            var fileStream = new StreamReader(file.OpenReadStream());

            var fileContent = fileStream.ReadToEndAsync().Result;
            JArray jsonArray = JArray.Parse(fileContent);
            foreach(var x in jsonArray)
            {
                var laptopSection = x["Laptop"];
                model.Laptops = JsonConvert.DeserializeObject<IEnumerable<Laptop>>(laptopSection.ToString());

                var gpuSection = x["GPU"];
                model.GPUs = JsonConvert.DeserializeObject<IEnumerable<GPU>>(gpuSection.ToString());

            }

            foreach(var item in model.Laptops)
            {
                var check = _laptopRepository.GetAll().Where(x => x.Name.ToLower().Replace(" ","") == item.Name.ToLower().Replace(" ", "")).FirstOrDefault();
                if (check == null)
                {
                    _laptopRepository.Add(item);
                }
                else
                {
                    check.Quantity += item.Quantity;
                }
            }
            foreach (var item in model.GPUs)
            {
                var check = _gpuRepository.GetAll().Where(x => x.Name.ToLower().Replace(" ", "") == item.Name.ToLower().Replace(" ", "")).FirstOrDefault();
                if (check == null)
                {
                    _gpuRepository.Add(item);
                }
                else
                {
                    check.Quantity += item.Quantity;
                }

            }



            return View(model);

        }

    }
}
