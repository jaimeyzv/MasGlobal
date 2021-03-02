using System.Threading.Tasks;

namespace MasGlobal.Business.Entities.AnnualSalary
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
