using StockManagement;
using StockManagement.Services;

namespace StockManagement_Test
{
    public class Tests
    {

        private static IStockRepository<Laptop> _laptop = new LaptopRepository();
        private static IStockRepository<GPU> _gpu = new GPURepository();
        private static ILaptopCalc _laptopCalc = new LaptopCalc();
        private static IGPUCalc _gpuCalc = new GPUCalc();
        private static ISearchLaptop _searchLaptop = new SearchLaptop();
        private static ISearchGPU _searchGPU = new SearchGPU();


        [SetUp]
        public void Setup()
        {
            _gpu.GetAll().Add(new GPU("Nvidia RTX 4090 Ti", 1, 1699.99m, 24, 16384));
            _gpu.GetAll().Add(new GPU("Nvidia GTX 950", 5, 209.99m, 2, 768));
            _laptop.GetAll().Add(new Laptop("Chromebook", 5, 199, 17, 32, 512));
            _gpu.GetAll().Add(new GPU("GTX1660", 1, 209.99m, 6, 1408));

        }
       // Create
       [Test]
        public void AddLaptop()
        {
           // Arrange
           Laptop newLaptop = new Laptop("Macbook", 5, 199, 17, 32, 512);
            // Act
            _laptop.Add(newLaptop);
           // Assert
           Assert.That(_laptop.GetAll(), Does.Contain(newLaptop));
        }
        [Test]
       public void AddGPU()
        {
           // Arrange
           GPU newGPU = new GPU("Nvidia GTX 1080", 1, 329.99m, 8, 2560);
            // Act
            _gpu.Add(newGPU);
           // Assert
           Assert.That(_gpu.GetAll(), Does.Contain(newGPU));
        }
       // Read
       [Test]

        public void ReadLaptop()
        {
            var result = _laptop.GetAll();
            Assert.That(result, Is.Not.Null);
        }
        [Test]

        public void ReadGPU()
        {
            GPU result = _gpu.GetAll().First();
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public void GetIdByName()
        {
           // Arrange
           Laptop newLaptop = (new Laptop("Chromebook", 5, 199, 17, 32, 512));
           var newId = _laptop.Add(newLaptop).Id;
           string name = "Chromebook";
           // Act
           List<int?> result = _searchLaptop.GetIdsByName(_laptop, name);
           // Assert
            Assert.That(result, Does.Contain(newId));
        }
       // Update
       [Test]

        public void Update()
        {
           // Arrange
           GPU newGPU = new GPU("GTX1660", 1, 209.99m, 6, 1408);
           var newId = _gpu.Add(newGPU).Id;

           GPU updated = new GPU("Nvidia GTX 1660", 5, 209.99m, 6, 1408);
           // Act
           var result = _gpu.Update(newId, updated);
           // Assert
           Assert.That(result.Id, Is.EqualTo(newId));
        }
        [Test]

        public void Delete()
        {
           // Arrange
           GPU newGPU = new GPU("Nvidia GTX 1080", 1, 329.99m, 8, 2560);
           var newId = _gpu.Add(newGPU).Id;
           // Act
           _gpu.Delete(newId);
           // Assert
           Assert.That(_gpu.GetAll().Any(x => x.Id != newId));
        }



    }
}