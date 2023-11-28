using Newtonsoft.Json;
using StockManagementLibraries.Repositories;


namespace StockManagementLibraries.Repositories
{
    public class JsonGPURepository : IStockRepository<GPU>
    {
        private readonly string filePath = @"C:\Users\stewartc\Documents\GPUs.json";
        private List<GPU> _gpus;


        public JsonGPURepository() 
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            string fileContent = File.ReadAllText(filePath);
            _gpus = new List<GPU>();

            _gpus = JsonConvert.DeserializeObject<List<GPU>>(fileContent);


        }
        public GPU Add(GPU item)
        {
            _gpus.Add(item);
            string updatedJSon = JsonConvert.SerializeObject(_gpus, Formatting.Indented);
            File.WriteAllText(filePath, updatedJSon);

            return GetById(item.Id);

        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _gpus.Remove(item);
                GPU itemToRemove = _gpus.Find(x => x.Id == id);
                string updatedJSon = JsonConvert.SerializeObject(_gpus, Formatting.Indented);
                File.WriteAllText(filePath, updatedJSon);
            }
        }

        public IEnumerable<GPU> GetAll()
        {
            return _gpus;
        }

        public GPU GetById(int id)
        {
            return _gpus.FirstOrDefault(x => x.Id == id);
        }

        public GPU Update(GPU gpu)
        {
            var item = GetById(gpu.Id);
            if (item != null)
            {
                item.Name = gpu.Name;
                item.Description = gpu.Description;
                item.Brand = gpu.Brand;
                item.ImageThumbnail = gpu.ImageThumbnail;
                item.Quantity = gpu.Quantity;
                item.Price = gpu.Price;
                item.Vram = gpu.Vram;
                item.Cuda = gpu.Cuda;

                string updatedJSon = JsonConvert.SerializeObject(_gpus, Formatting.Indented);
                File.WriteAllText(filePath, updatedJSon);


                return item;

            }
            return null;
        }
    }
}
