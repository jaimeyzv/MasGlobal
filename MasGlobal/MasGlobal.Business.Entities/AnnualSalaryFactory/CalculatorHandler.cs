using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.Business.Entities.AnnualSalaryFactory
{
    public class CalculatorHandler
    {
        private readonly Dictionary<CalculationTypes, IAnnualSalaryFactory> factories;

        public CalculatorHandler()
        {
            factories = new Dictionary<CalculationTypes, IAnnualSalaryFactory>
            {
                { CalculationTypes.HourlySalaryEmployee, new HourlyFactory() },
                { CalculationTypes.MonthlySalaryEmployee, new MonthlyFactory() }
            };
        }

        public async Task<IAnnualSalary> ExecuteCreationAsync(CalculationTypes type, EmployeeEntity employee) => await factories[type].CreateAsync(employee);
    }
}
