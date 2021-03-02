using System.Threading.Tasks;

namespace MasGlobal.Business.AnnualSalaryFactory
{
    public interface IAnnualSalary
    {
        Task<decimal> CalculateAnnualSalaryAsync();
    }
}
