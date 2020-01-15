using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigManager config = new ConfigManager();
            ApiClient mockApi = new ApiClient();
            Random random = new Random();

            int count = mockApi.AvailableInstances();
            int maxThreads = random.Next(config.MinThreads, config.MaxThreads + 1);

            int dataCount = PullMockData(count, maxThreads);

            Console.WriteLine($"Avaialble data {dataCount}");
            Console.ReadLine();
        }

        static int PullMockData(int count, int maxThreads)
        {
            ApiClient mockApi = new ApiClient();

            int objectSize = count / maxThreads;

            Task[] threads = new Task[maxThreads];
            for (int i = 0; i < maxThreads; i++)
            {
                int start = (objectSize * i) + 1;
                int end = 0;
                if (i + 1 == maxThreads)
                    end = count;
                else
                    end = (i + 1) * objectSize;

                Task task = Task.Factory.StartNew(() => mockApi.GetMockData(start, end));
                threads[i] = task;
            }

            Task.WaitAll(threads);
            Console.WriteLine("All threads complete");
            return mockApi.MockObjectsCount;
        }
    }
}
