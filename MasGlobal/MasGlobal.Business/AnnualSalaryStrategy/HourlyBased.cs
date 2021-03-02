using MasGlobal.Business.Entities;
using System.Threading.Tasks;

namespace MasGlobal.Business.AnnualSalaryStrategy
{
    public class HourlyBased : IAnnualSalary
    {
        public async Task<decimal> CalculateAnnualSalaryAsync(EmployeeEntity employee)
        {
            var result = 120 * employee.HourlySalary * 12;
            return await Task.FromResult(result);
        }
    }
}
