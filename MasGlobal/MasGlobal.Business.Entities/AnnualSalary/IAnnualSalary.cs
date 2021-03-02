using System.Threading.Tasks;

namespace MasGlobal.Business.Entities.AnnualSalary
{
    public interface IAnnualSalary
    {
        Task<decimal> CalculateAnnualSalaryAsync(EmployeeEntity employee);
    }
}
