using MasGlobal.Business.Entities;
using MasGlobal.DataAccess.Interfaces.Dtos;
using MasGlobal.Insfrastucture.Interfaces;

namespace MasGlobal.Insfrastucture
{
    public class Mapper : IMapper
    {
        public EmployeeEntity MapFromDtotoEntity(EmployeeDto dto)
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
    }
}
