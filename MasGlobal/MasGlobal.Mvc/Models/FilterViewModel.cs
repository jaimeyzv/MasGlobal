using MasGlobal.Api.ViewModels;
using System.Collections.Generic;

namespace MasGlobal.Mvc.Models
{
    public class FilterViewModel
    {
        public string EmployeeId { get; set; }
        public IList<EmployeeViewModel> Employees { get; set; }
    }
}