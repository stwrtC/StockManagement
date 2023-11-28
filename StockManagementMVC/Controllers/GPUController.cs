﻿using log4net;
using Microsoft.AspNetCore.Mvc;
using StockManagementLibraries.Logging;
using StockManagementLibraries.Models;
using StockManagementLibraries.Repositories;
using StockManagementMVC.ViewModels;

namespace StockManagementMVC.Controllers
{
    public class GPUController : Controller
    {
        public readonly IStockRepository<GPU> _gpuRepository;
        private readonly ILogger _log;

        public GPUController(IStockRepository<GPU> gpuRepository, ILogger<GPUController> log)
        {
            _gpuRepository = gpuRepository;
            _log = log;
        }

        public ViewResult List()
        {
            ListViewModel<GPU> gpuListViewModel = new ListViewModel<GPU>(_gpuRepository.GetAll());
            _log.LogInformation($"{LogStrings.DefaultMessage}{LogStrings.Http200}");
            return View(gpuListViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult<GPU> Create(GPU entity)
        {
            var newItem = new GPU()
            {
                Name = entity.Name,
                Brand = entity.Brand,
                Description = entity.Description,
                Quantity = entity.Quantity,
                Price = entity.Price,
                Vram = entity.Vram,
                Cuda = entity.Cuda
            };
            if(ModelState.IsValid)
            {
                _gpuRepository.Add(newItem);
                _log.LogInformation($"{LogStrings.RequestSuccessful}{LogStrings.Http201}");
                return RedirectToAction("List");
            }

            return View(newItem);
        }

        [Route("GPU/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var item = _gpuRepository.GetById(id);
            ItemViewModel<GPU> model = new ItemViewModel<GPU>(item)
            {
                Item = item
            };

            return View(model);
        }
        [Route("GPU/ConfirmDelete/{id}")]
        public IActionResult ConfirmDelete(int id)
        {
            var item = _gpuRepository.GetById(id);
            ItemViewModel<GPU> model = new ItemViewModel<GPU>(item)
            {
                Item = item
            };
            _gpuRepository.Delete(id);
            _log.LogInformation($"{LogStrings.DefaultMessage}{LogStrings.Http200}");
            return View(model);
        }

        [Route("GPU/Update/{id}")]
        public IActionResult Update(int id)
        {
            var item = _gpuRepository.GetById(id);
            ItemViewModel<GPU> model = new ItemViewModel<GPU>(item)
            {
                Item = item
            };

            return View(model);
        }

        [HttpPost, Route("GPU/Update/{id}")]
        public IActionResult Update(int id, GPU entity)
        {
            var old = _gpuRepository.GetById(id);

            if (!String.IsNullOrEmpty(entity.Name))
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
            if (entity.Quantity != 0)
            {
                old.Quantity = entity.Quantity;
            }
            if (entity.Price != 0)
            {
                old.Price = entity.Price;
            }
            if (entity.Cuda != 0)
            {
                old.Cuda = entity.Cuda;
            }
            if (entity.Vram != 0)
            {
                old.Vram = entity.Vram;
            }
            if(entity.ImageThumbnail != null)
            {
                old.ImageThumbnail = entity.ImageThumbnail;
            }


            _gpuRepository.Update(old);
            return RedirectToAction("List");
        }

        [Route("GPU/Details/{id}")]

        public IActionResult Details(int id)
        {
            var item = _gpuRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            ItemViewModel<GPU> model = new ItemViewModel<GPU>(item)
            {
                Item = item
            };

            return View(model);
        }

    }
}