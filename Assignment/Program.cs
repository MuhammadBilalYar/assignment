using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment
{
    class Program
    {


        static void Main(string[] args)
        {
            int count = PullMockData();
            Console.ReadLine();
        }

        static int PullMockData()
        {
            ConfigManager config = new ConfigManager();

            ThreadPool.SetMinThreads(config.MinThreads, config.MinThreads);
            ThreadPool.SetMaxThreads(config.MaxThreads, config.MaxThreads);
            ThreadPool.GetMinThreads(out int minThreadInPool, out int minCThreadInPool);
            ThreadPool.GetMaxThreads(out int maxThreadInPool, out int maxCThreadInPool);

            Console.WriteLine($"Min Threads: {minThreadInPool}, Max Threads: {maxThreadInPool}");

            ApiClient mockApi = new ApiClient();

            int count = mockApi.AvailableInstances();
            int maxThreads = (int)Math.Ceiling(count / ConfigManager.MAX_INSTANCES_PER_THREAD);

            if (maxThreads > config.MaxThreads)
            {
                ThreadPool.SetMaxThreads(maxThreads, maxThreads);
                ThreadPool.GetMinThreads(out minThreadInPool, out minCThreadInPool);
                ThreadPool.GetMaxThreads(out maxThreadInPool, out  maxCThreadInPool);
                Console.WriteLine($"Min Threads: {minThreadInPool}, Max Threads: {maxThreadInPool}");
            }

            for (int i = 0; i < maxThreads; i++)
            {
                State state = new State(i, maxThreads, count);

                ThreadPool.QueueUserWorkItem(new WaitCallback(mockApi.GetMockData), state);

                Console.WriteLine($"Added {i + 1} thread/s in queue");
                Thread.Sleep(100);
            }
            return 0;
        }
    }

    public class State
    {
        public int start { get; private set; }
        public int end { get; private set; }
        public State(int itrator, int maxThreads, int count)
        {
            int objectSize = (int)ConfigManager.MAX_INSTANCES_PER_THREAD;
            this.start = (objectSize * itrator) + 1;
            if (itrator + 1 == maxThreads)
                this.end = count;
            else
                this.end = (itrator + 1) * objectSize;
        }
    }
}
