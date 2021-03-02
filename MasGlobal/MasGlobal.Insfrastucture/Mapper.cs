using MasGlobal.Api.ViewModels;
using MasGlobal.Business.Entities;
using MasGlobal.DataAccess.Interfaces.Dtos;
using MasGlobal.Insfrastucture.Interfaces;

namespace MasGlobal.Insfrastucture
{
    public class Mapper : IMapper
    {
        public EmployeeEntity MapFromDtoToEntity(EmployeeDto dto)
        {
            return new EmployeeEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                ContractTypeName = dto.ContractTypeName,
                RoleId = dto.RoleId,
                RoleName = dto.RoleName,
                RoleDescription = dto.RoleDescription,
                HourlySalary = dto.HourlySalary,
                MonthlySalary = dto.MonthlySalary
            };
        }

        public EmployeeViewModel MapFromEntityToViewModel(EmployeeEntity entity)
        {
            return new EmployeeViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                ContractTypeName = entity.ContractTypeName,
                RoleId = entity.RoleId,
                RoleName = entity.RoleName,
                RoleDescription = entity.RoleDescription,
                HourlySalary = entity.HourlySalary,
                MonthlySalary = entity.MonthlySalary,
                CalculatedAnnualSalary = entity.CalculatedAnnualSalary
            };
        }
    }
}
