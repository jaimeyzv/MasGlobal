using MasGlobal.Business.Entities;
using System.Threading.Tasks;

namespace MasGlobal.Business.AnnualSalaryFactory
{
    public interface IAnnualSalaryFactory
    {
        Task<IAnnualSalary> CreateAsync(EmployeeEntity employee);
    }
}
