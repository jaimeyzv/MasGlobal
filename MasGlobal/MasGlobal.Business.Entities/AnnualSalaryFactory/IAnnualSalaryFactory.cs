using System.Threading.Tasks;

namespace MasGlobal.Business.Entities.AnnualSalaryFactory
{
    public interface IAnnualSalaryFactory
    {
        Task<IAnnualSalary> CreateAsync(EmployeeEntity employee);
    }
}
