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
        public List<int?> GetIdsByName(IStockRepository<GPU> gpuRepo, string? name)
        {
            if (String.IsNullOrEmpty(name) == false)
            {
                List<int?> items = gpuRepo.GetAll().Where(x => x.Name == name).Select(x => x.Id).ToList();
                return items;
            }
            return null;
        }

        public bool IDExists(IStockRepository<GPU> gpuRepo, int id)
        {
            return gpuRepo.GetAll().Where(x => x.Id == id).Any();
        }
    }
}
