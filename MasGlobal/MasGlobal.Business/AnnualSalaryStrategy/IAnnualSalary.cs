using MasGlobal.Business.Entities;
using System.Threading.Tasks;

namespace MasGlobal.Business.AnnualSalaryStrategy
{
    public interface IAnnualSalary
    {
        Task<decimal> CalculateAnnualSalaryAsync(EmployeeEntity employee);
    }
}
