using MasGlobal.Api.ViewModels;
using MasGlobal.Common.Wrappers;
using MasGlobal.Mvc.Models;
using System.Collections.Generic;
using System.Net.Http;
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
            var client = new HttpClientWrapper<IList<EmployeeViewModel>>();
            var result = client.GetAsync("http://localhost:53554/api/employees").Result;
            vm.Employees = result;

            return vm;
        }

        private FilterViewModel GetById(FilterViewModel vm)
        {
            var client = new HttpClientWrapper<EmployeeViewModel>();
            var result = client.GetAsync("http://localhost:53554/api/employees/" + vm.EmployeeId).Result;

            vm.Employees = new List<EmployeeViewModel>();
            vm.Employees.Add(result);
            
            return vm;
        }
    }
}