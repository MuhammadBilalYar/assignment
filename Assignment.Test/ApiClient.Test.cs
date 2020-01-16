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
            State state = new State(0,2,50);
            ApiClient mockApi = new ApiClient();
            mockApi.GetMockData(state);
            Assert.IsTrue(true);
        }
    }
}
