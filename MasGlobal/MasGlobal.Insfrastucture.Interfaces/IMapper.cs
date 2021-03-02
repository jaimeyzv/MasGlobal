using MasGlobal.Api.ViewModels;
using MasGlobal.Business.Entities;
using MasGlobal.DataAccess.Interfaces.Dtos;

namespace MasGlobal.Insfrastucture.Interfaces
{
    public interface IMapper
    {
        EmployeeEntity MapFromDtoToEntity(EmployeeDto dto);

        EmployeeViewModel MapFromEntityToViewModel(EmployeeEntity entity);
    }
}
