using NUnit.Framework;

namespace Assignment.Test
{
    public class ConfigManagerTests
    {
        private ConfigManager _config = null;
        [SetUp]
        public void Setup()
        {
            _config = new ConfigManager();
        }

        [Test]
        public void MaxThreads()
        {
            Assert.AreEqual(5, _config.MaxThreads, "Config Manager should return MAX 5 threads");
        }

        [Test]
        public void MinThreads()
        {
            Assert.AreEqual(3, _config.MinThreads, "Config Manager should return MIN 3 threads");
        }
    }
}