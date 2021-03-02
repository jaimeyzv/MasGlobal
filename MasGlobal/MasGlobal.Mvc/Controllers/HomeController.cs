using MasGlobal.Api.ViewModels;
using MasGlobal.Mvc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MasGlobal.Mvc.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            var vm = new FilterViewModel();
            vm.Employees = new List<EmployeeViewModel>();
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Index(FilterViewModel vm)
        {
            if (string.IsNullOrEmpty(vm.EmployeeId))
            {
                var result = GetAll(vm);
                return View(result);
            }
            else
            {
                var result = GetById(vm);
                return View(result);
            }
        }

        private FilterViewModel GetAll(FilterViewModel vm)
        {
            if (client.BaseAddress == null)
                client.BaseAddress = new Uri("http://localhost:53554/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Call client.PostAsJsonAsync to send a POST request to the appropriate URI   
            HttpResponseMessage resp = client.GetAsync("employees").Result;
            //This method throws an exception if the HTTP response status is an error code.  
            //var xx = resp.EnsureSuccessStatusCode();
            if (resp.IsSuccessStatusCode)
            {
                var resultado = resp.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<IList<EmployeeViewModel>>(resultado);

                vm.Employees = result;

                return vm;
            }
            else
                return null;
        }

        private FilterViewModel GetById(FilterViewModel vm)
        {
            if (client.BaseAddress == null)
                client.BaseAddress = new Uri("http://localhost:53554/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Call client.PostAsJsonAsync to send a POST request to the appropriate URI   
            HttpResponseMessage resp = client.GetAsync("employees/" + vm.EmployeeId).Result;
            //This method throws an exception if the HTTP response status is an error code.  
            //var xx = resp.EnsureSuccessStatusCode();
            if (resp.IsSuccessStatusCode)
            {
                var resultado = resp.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<EmployeeViewModel>(resultado);

                vm.Employees = new List<EmployeeViewModel>();
                vm.Employees.Add(result);

                return vm;
            }
            else
                return null;
        }
    }
}