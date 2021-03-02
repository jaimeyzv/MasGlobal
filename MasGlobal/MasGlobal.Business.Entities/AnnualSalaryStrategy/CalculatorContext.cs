using System.Collections.Generic;

namespace MasGlobal.Business.Entities.AnnualSalaryStrategy
{
    public class CalculatorContext
    {
        public Dictionary<CalculationTypes, IAnnualSalary> calculators;

        public CalculatorContext()
        {
            this.calculators = new Dictionary<CalculationTypes, IAnnualSalary>();
            calculators.Add(CalculationTypes.HourlySalaryEmployee, new HourlyBased());
            calculators.Add(CalculationTypes.MonthlySalaryEmployee, new MonthlyBased());
        }
    }
}
