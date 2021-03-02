using System.Threading.Tasks;

namespace MasGlobal.Business.Entities.AnnualSalary
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
