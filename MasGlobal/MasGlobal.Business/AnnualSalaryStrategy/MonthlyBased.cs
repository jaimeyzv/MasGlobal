using MasGlobal.Business.Entities;
using System.Threading.Tasks;

namespace MasGlobal.Business.AnnualSalaryStrategy
{
    public class MonthlyBased : IAnnualSalary
    {
        public async Task<decimal> CalculateAnnualSalaryAsync(EmployeeEntity employee)
        {
            var result = employee.MonthlySalary * 12;
            return await Task.FromResult(result);
        }
    }
}
