using MasGlobal.DataAccess.Interfaces;
using MasGlobal.DataAccess.Interfaces.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MasGlobal.DataAccess
{
    public class EmployeesRepository : IEmployeesRepository
    {
        static HttpClient client = new HttpClient();

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            //declare api client 
            
            //Initialize api client
            if (client.BaseAddress == null)
                client.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            //Call client.PostAsJsonAsync to send a POST request to the appropriate URI   
            HttpResponseMessage resp = await client.GetAsync("api/Employees");
            //This method throws an exception if the HTTP response status is an error code.  
            //var xx = resp.EnsureSuccessStatusCode();
            if (resp.IsSuccessStatusCode)
            {
                var resultado = resp.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<IEnumerable<Employee>>(resultado);

                return result;
            }
            else
                return null;
            

            //var url = $"http://localhost:8080/items?filter={filter}";
            //var request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.ContentType = "application/json";
            //request.Accept = "application/json";

            //try
            //{
            //    using (WebResponse response = request.GetResponse())
            //    {
            //        using (Stream strReader = response.GetResponseStream())
            //        {
            //            if (strReader == null) return null;
            //            using (StreamReader objReader = new StreamReader(strReader))
            //            {
            //                string responseBody = objReader.ReadToEnd();
            //                // Do something with responseBody
            //                Console.WriteLine(responseBody);
            //            }
            //        }
            //    }
            //}
            //catch (WebException ex)
            //{
            //    // Handle error
            //}
        }
    }
}
