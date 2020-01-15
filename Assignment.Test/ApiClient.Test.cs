using NUnit.Framework;

namespace Assignment.Test
{
    public class ApiClientTest
    {
        private ApiClient _apiClient = null;

        [SetUp]
        public void Setup()
        {
            _apiClient = new ApiClient();
        }

        [Test]
        public void ContentLength()
        {
            int length = _apiClient.AvailableInstances();
            Assert.AreEqual(150, length, "Mock API should return 150 count as available objects");
        }
        [Test]
        public void GetMockData()
        {
            ApiClient mockApi = new ApiClient();
            mockApi.GetMockData(1, 50);
            var instnaces = mockApi.MockObjectsCount;
            Assert.AreEqual(50, instnaces, "Mock API should return 150 count as available objects");
        }
    }
}
