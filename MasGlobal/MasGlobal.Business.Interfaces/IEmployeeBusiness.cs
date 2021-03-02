using MasGlobal.Business.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.Business.Interfaces
{
    public interface IEmployeeBusiness
    {
        Task<IEnumerable<EmployeeEntity>> GetAllAsync();

        Task<EmployeeEntity> GetByIdAsync(int id);
    }
}
