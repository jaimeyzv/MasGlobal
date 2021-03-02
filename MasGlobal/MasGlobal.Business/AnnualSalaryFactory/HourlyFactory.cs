using MasGlobal.Business.Entities;
using System.Threading.Tasks;

namespace MasGlobal.Business.AnnualSalaryFactory
{
    public class HourlyFactory : IAnnualSalaryFactory
    {
        public async Task<IAnnualSalary> CreateAsync(EmployeeEntity employee)
        {
            return await Task.FromResult(new HourlyManager(employee));
        }
    }
}
