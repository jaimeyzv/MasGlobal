using MasGlobal.Business.Entities;
using MasGlobal.Business.Entities.AnnualSalaryFactory;
using MasGlobal.Business.Entities.AnnualSalaryStrategy;
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

            // await ProcessAnnualSalaryStrategy(employeeEntities);
            await ProcessAnnualSalaryFactory(employeeEntities);

            return employeeEntities;
        }

        private async Task ProcessAnnualSalaryStrategy(List<EmployeeEntity> entities)
        {
            var calculatorContext = new CalculatorContext();

            foreach (var item in entities)
            {
                var type = (Entities.AnnualSalaryStrategy.CalculationTypes)System.Enum
                    .Parse(typeof(Entities.AnnualSalaryStrategy.CalculationTypes), item.ContractTypeName);                
                item.CalculatedAnnualSalary = await calculatorContext.calculators[type].CalculateAnnualSalaryAsync(item);
            }
        }

        private async Task ProcessAnnualSalaryFactory(List<EmployeeEntity> entities)
        {
            var calculatorHandler = new CalculatorHandler();

            foreach (var item in entities)
            {
                var type = (Entities.AnnualSalaryFactory.CalculationTypes)System.Enum
                    .Parse(typeof(Entities.AnnualSalaryFactory.CalculationTypes), item.ContractTypeName);
                var factory = await calculatorHandler.ExecuteCreationAsync(type, item);
                item.CalculatedAnnualSalary = await factory.CalculateAnnualSalaryAsync();
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
