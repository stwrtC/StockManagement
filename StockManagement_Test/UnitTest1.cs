using StockManagement;

namespace StockManagement_Test
{
    public class Tests
    {

        public static GPURepository gpuRepository = new GPURepository();
        public static LaptopRepository laptopRepository = new LaptopRepository();
        public static Search search = new Search();


        [SetUp]
        public void Setup()
        {
            gpuRepository.getGPUs().Add(new GPU("Nvidia RTX 4090 Ti", 1, 1699.99m, 24, 16384));
            gpuRepository.getGPUs().Add(new GPU("Nvidia GTX 950", 5, 209.99m, 2, 768));
            laptopRepository.getLaptops().Add(new Laptop("Chromebook", 5, 199, 17, 32, 512));
            gpuRepository.getGPUs().Add(new GPU("GTX1660", 1, 209.99m, 6, 1408));

        }
        // Create
        [Test]
        [Category("Repository Tests")]
        [Category("Add")]
        public void AddLaptop()
        {
            // Arrange
            Laptop newLaptop = new Laptop("Macbook", 5, 199, 17, 32, 512);
            // Act
            laptopRepository.Add(newLaptop);
            // Assert
            Assert.That(laptopRepository.getLaptops(), Does.Contain(newLaptop));
        }
        [Test]
        [Category("Repository Tests")]
        [Category("Add")]
        public void AddGPU()
        {
            // Arrange
            GPU newGPU = new GPU("Nvidia GTX 1080", 1, 329.99m, 8, 2560);
            // Act
            gpuRepository.Add(newGPU);
            // Assert
            Assert.That(gpuRepository.getGPUs(), Does.Contain(newGPU));
        }
        // Read
        [Test]
        [Category("Repository Tests")]

        public void ReadLaptop()
        {
            var result = laptopRepository.GetAll();            
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        [Category("Repository Tests")]

        public void ReadGPU()
        {
            GPU result = gpuRepository.GetAll().First();            
            Assert.That(result, Is.Not.Null);
        }
        [Test]
        public void GetIdByName()
        {
            // Arrange
            Laptop newLaptop = (new Laptop("Chromebook", 5, 199, 17, 32, 512));          
            var newId = laptopRepository.Add(newLaptop).Id;
            string name = "Chromebook";
            // Act
            List<int?> result = search.GetIdsByName(laptopRepository.getLaptops(), name);
            // Assert
            Assert.That(result, Does.Contain(newId));
        }
        // Update
        [Test]
        [Category("Repository Tests")]

        public void Update()
        {
            // Arrange
            GPU newGPU = new GPU("GTX1660", 1, 209.99m, 6, 1408);
            var newId = gpuRepository.Add(newGPU).Id;

            GPU updated = new GPU("Nvidia GTX 1660", 5, 209.99m, 6, 1408);
            // Act
            var result = gpuRepository.Update(newId, updated);
            // Assert
            Assert.That(result.Id, Is.EqualTo(newId));
        }
        [Test]
        [Category("Repository Tests")]

        public void Delete()
        {
            // Arrange
            GPU newGPU = new GPU("Nvidia GTX 1080", 1, 329.99m, 8, 2560);
            var newId = gpuRepository.Add(newGPU).Id;
            // Act
            gpuRepository.Delete(newId);
            // Assert
            Assert.That(gpuRepository.getGPUs().Any(x => x.Id != newId));
        }



    }
}