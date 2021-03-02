using System.Threading.Tasks;

namespace MasGlobal.Business.Entities.AnnualSalaryFactory
{
    public class MonthlyManager : IAnnualSalary
    {
        private readonly EmployeeEntity employeeEntity;

        public MonthlyManager(EmployeeEntity employeeEntity)
        {
            this.employeeEntity = employeeEntity;
        }

        public async Task<decimal> CalculateAnnualSalaryAsync()
        {
            var result = employeeEntity.MonthlySalary * 12;
            return await Task.FromResult(result);
        }
    }
}
