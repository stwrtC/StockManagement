using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementLibraries.Repositories;
using StockManagementLibraries;



namespace StockManagement.Services
{
    public class SearchLaptop : ISearchLaptop
    {
        private readonly IStockRepository<Laptop> _laptopRepo;
        public SearchLaptop(IStockRepository<Laptop> laptopRepo)
        {
            _laptopRepo = laptopRepo;
        }

        public List<int> GetIdsByName(string? name)
        {
            if (string.IsNullOrEmpty(name) == false)
            {
                List<int> items = _laptopRepo.GetAll().Where(x => x.Name == name).Select(x => x.Id).ToList();
                return items;
            }
            return null;
        }

        public bool IDExists(int id)
        {
            return _laptopRepo.GetAll().Where(x => x.Id == id).Any();
        }
    }
}
