using StockManagement.Interafces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementLibraries.Repositories;
using StockManagementLibraries;


namespace StockManagement.Services
{
    public class Search : ISearch
    {
        private readonly IStockRepository<GPU> _gpuRepo;
        private readonly IStockRepository<Laptop> _laptopRepo;

        public Search(IStockRepository<GPU> gpuRepo, IStockRepository<Laptop> laptopRepo)
        {
            _gpuRepo = gpuRepo;
            _laptopRepo = laptopRepo;
        }

        public string GetType(int id)
        {
            if (_gpuRepo.GetById(id) != null)
            {
                return "GPU";
            }
            else if(_laptopRepo.GetById(id) != null)
            {
                return "Laptop";
            }
            return string.Empty;
        }


    }
}
