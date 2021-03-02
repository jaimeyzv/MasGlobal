using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasGlobal.Common.Wrappers
{
    public class HttpClientWrapper<T> where T : class
    {
        public async Task<T> GetAsync(string url)
        {
            T result = null;

            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(new Uri(url)).Result;

                response.EnsureSuccessStatusCode();
               
                var respondeResult = response.Content.ReadAsStringAsync().Result;

                result = JsonConvert.DeserializeObject<T>(respondeResult);
            }

            return result;
        }
    }
}
