using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Assignment
{

    public class MockObject
    {
        public string id { get; set; }
        public DateTime createdAt { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
    }

    public class ApiClient
    {
        public ApiClient()
        {
            MockObjectsCount = 0;
            this._importer = new Importer();
        }

        public int MockObjectsCount { get; private set; }
        public Importer _importer { get; private set; }

        /// <summary>
        /// Mock API that tell us available objects 
        /// </summary>
        /// <returns></returns>
        public int AvailableInstances()
        {
            return 1500;
        }

        /// <summary>
        /// Mock API that will pull requested object from API service 
        /// </summary>
        /// <param name="start">starting object</param>
        /// <param name="end">end object</param>
        public void GetMockData(int start, int end)
        {
            try
            {
                string url = $"http://5e1aaf5c31118200148f2275.mockapi.io/50?s={start}&e={end}";
                Console.WriteLine(url);
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);

                if (HttpStatusCode.OK == response.StatusCode)
                {
                    //the only purpose to Deserialize is to get reponse count;
                    List<MockObject> objects = JsonConvert.DeserializeObject<List<MockObject>>(response.Content);
                    Console.WriteLine($"Start: {start}, End: {end}, {objects.Count}");
                    MockObjectsCount += objects.Count;
                    this._importer.WriteToFile(response.Content);
                }
                else
                {
                    throw new Exception($"{response.StatusCode}: {response.Content}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
