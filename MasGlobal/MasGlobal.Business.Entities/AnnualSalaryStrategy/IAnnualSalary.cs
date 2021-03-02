using System.Threading.Tasks;

namespace MasGlobal.Business.Entities.AnnualSalaryStrategy
{
    public interface IAnnualSalary
    {
        Task<decimal> CalculateAnnualSalaryAsync(EmployeeEntity employee);
    }
}
