using StockManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    public class SearchGPU : ISearchGPU
    {
        private readonly IStockRepository<GPU> _gpuRepo;
        public SearchGPU(IStockRepository<GPU> gpuRepo)
        {
            _gpuRepo = gpuRepo;
        }
        public List<int> GetIdsByName(string? name)
        {
            if (string.IsNullOrEmpty(name) == false)
            {
                List<int> items = _gpuRepo.GetAll().Where(x => x.Name == name).Select(x => x.Id).ToList();
                return items;
            }
            return null;
        }

        public bool IDExists(int id)
        {
            return _gpuRepo.GetAll().Where(x => x.Id == id).Any();
        }
    }
}
