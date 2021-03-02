using MasGlobal.Business.Entities;
using MasGlobal.DataAccess.Interfaces.Dtos;

namespace MasGlobal.Insfrastucture.Interfaces
{
    public interface IMapper
    {
        EmployeeEntity MapFromDtotoEntity(EmployeeDto dto);
    }
}
