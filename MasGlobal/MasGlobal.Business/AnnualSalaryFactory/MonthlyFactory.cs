using MasGlobal.Business.Entities;
using System.Threading.Tasks;

namespace MasGlobal.Business.AnnualSalaryFactory
{
    public class MonthlyFactory : IAnnualSalaryFactory
    {
        public async Task<IAnnualSalary> CreateAsync(EmployeeEntity employee)
        {
            return await Task.FromResult(new MonthlyManager(employee));
        }
    }
}
