using MasGlobal.Business.Entities;
using System.Threading.Tasks;

namespace MasGlobal.Business.AnnualSalaryFactory
{
    public class HourlyManager : IAnnualSalary
    {
        private readonly EmployeeEntity employeeEntity;

        public HourlyManager(EmployeeEntity employeeEntity)
        {
            this.employeeEntity = employeeEntity;
        }

        public async Task<decimal> CalculateAnnualSalaryAsync()
        {
            var result = 120 * this.employeeEntity.HourlySalary * 12;
            return await Task.FromResult(result);
        }
    }
}
