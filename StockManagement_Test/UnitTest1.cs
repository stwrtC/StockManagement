using StockManagement;
using StockManagement.Services;

namespace StockManagement_Test
{
    public class Tests
    {

        private static IStockRepository<Laptop> _laptops = new LaptopRepository();
        private static IStockRepository<GPU> _gpus = new GPURepository();
        private static ILaptopCalc _laptopCalc = new LaptopCalc();
        private static IGPUCalc _gpuCalc = new GPUCalc();
        private static ISearchLaptop _searchLaptop = new SearchLaptop();
        private static ISearchGPU _searchGPU = new SearchGPU();


        [SetUp]
        public void Setup()
        {
            _gpus.Add(new GPU() { Name = "Nvidia GTX 950", Quantity = 5, Price = 209.99m, Vram = 2, Cuda = 768 });
            _gpus.Add(new GPU() { Name = "Nvidia RTX 4090 Ti", Quantity = 1, Price = 1699.99m, Vram = 24, Cuda = 16384 });
            _laptops.Add(new Laptop() { Name = "Chromebook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 });
            _gpus.Add(new GPU() {Name = "GTX1660", Quantity = 1, Price = 209.99m, Vram = 6, Cuda = 1408 });

        }
       // Create
       [Test]
        public void AddLaptop()
        {
           // Arrange
           Laptop newLaptop = new Laptop() {Name = "Macbook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 };
            // Act
            _laptops.Add(newLaptop);
           // Assert
           Assert.That(_laptops.GetAll(), Does.Contain(newLaptop));
        }
        [Test]
       public void AddGPU()
        {
           // Arrange
           GPU newGPU = new GPU() {Name = "Nvidia GTX 1080", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
            // Act
            _gpus.Add(newGPU);
           // Assert
           Assert.That(_gpus.GetAll(), Does.Contain(newGPU));
        }
       // Read
       [Test]

        public void ReadLaptop()
        {
            var result = _laptops.GetAll();
            Assert.That(result, Is.Not.Null);
        }
        [Test]

        public void ReadGPU()
        {
            GPU result = _gpus.GetAll().First();
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public void GetIdByName()   
        {
           // Arrange
           Laptop newLaptop = (new Laptop() { Name = "Chromebook", Quantity = 5, Price = 199, ScreenSize = 17, Ram = 32, Storage = 512 });
           var newId = _laptops.Add(newLaptop).Id;
           string name = "Chromebook";
           // Act
           List<int?> result = _searchLaptop.GetIdsByName(_laptops, name);
           // Assert
            Assert.That(result, Does.Contain(newId));
        }
       // Update
       [Test]

        public void Update()
        {
           // Arrange
           GPU newGPU = new GPU() { Name = "GTX1660", Quantity = 1, Price = 209.99m, Vram = 6, Cuda = 1408 };
           var newId = _gpus.Add(newGPU).Id;

           GPU updated = new GPU() { Name = "Nvidia GTX 950", Quantity = 5, Price = 209.99m, Vram = 2, Cuda = 768 };
           // Act
           var result = _gpus.Update(newId, updated);
           // Assert
           Assert.That(result.Id, Is.EqualTo(newId));
        }
        [Test]

        public void Delete()
        {
           // Arrange
           GPU newGPU = new GPU() { Name = "Nvidia GTX 1080", Quantity = 1, Price = 329.99m, Vram = 8, Cuda = 2560 };
           var newId = _gpus.Add(newGPU).Id;
           // Act
           _gpus.Delete(newId);
           // Assert
           Assert.That(_gpus.GetAll().Any(x => x.Id != newId));
        }



    }
}