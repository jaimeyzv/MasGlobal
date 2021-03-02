using MasGlobal.Business.Entities;
using MasGlobal.Business.Entities.AnnualSalary;
using MasGlobal.Business.Interfaces;
using MasGlobal.DataAccess.Interfaces;
using MasGlobal.Insfrastucture.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobal.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeesRepository employeesRepository;
        private readonly IMapper mapper;

        public EmployeeBusiness(IEmployeesRepository employeesRepository,
            IMapper mapper)
        {
            this.employeesRepository = employeesRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetAllAsync()
        {
            var employeeDtos = await this.employeesRepository.GetAllAsync();
            if (employeeDtos == null || !employeeDtos.Any()) return new List<EmployeeEntity>();
            var employeeEntities = (from r in employeeDtos.ToList() select this.mapper.MapFromDtotoEntity(r)).ToList();

            await ProcessAnnualSalary(employeeEntities);
            
            return employeeEntities;
        }

        private async Task ProcessAnnualSalary(List<EmployeeEntity> entities)
        {
            var calculatorContext = new CalculatorContext();

            foreach (var item in entities)
            {
                var type = (CalculationTypes)System.Enum.Parse(typeof(CalculationTypes), item.ContractTypeName);
                // comment below line out to work with Strategy Pattern
                // item.CalculatedAnnualSalary = await calculatorContext.calculators[type].CalculateAnnualSalaryAsync(item);
            }
        }

        public async Task<EmployeeEntity> GetByIdAsync(int id)
        {
            var employeeEntities = await this.GetAllAsync();
            if (!employeeEntities.Any()) return null;
            var result = employeeEntities.SingleOrDefault(x => x.Id == id);

            return result;
        }
    }
}
