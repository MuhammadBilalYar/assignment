using Microsoft.Extensions.Configuration;
using System.IO;

namespace Assignment
{
    public class ConfigManager
    {
        private IConfigurationRoot _configuration = null;
        private const string CONFIG_FILENAME = "appsettings.json";
        private const int DEFAULT_MAX_THREAD = 5;
        private const int DEFAULT_MIN_THREAD = 5;
        public ConfigManager()
        {
            if (null == _configuration)
            {
                var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile(CONFIG_FILENAME, optional: true, reloadOnChange: true);

                _configuration = builder.Build();
            }
        }

        public int MaxThreads
        {
            get
            {
                bool isParsed = int.TryParse(_configuration["Max_Thread"], out int max_thread);
                return isParsed ? max_thread : DEFAULT_MAX_THREAD;
            }
        }

        public int MinThreads
        {
            get
            {
                bool isParsed = int.TryParse(_configuration["Min_Thread"], out int min_thread);
                return isParsed ? min_thread : DEFAULT_MIN_THREAD;
            }
        }
    }
}
