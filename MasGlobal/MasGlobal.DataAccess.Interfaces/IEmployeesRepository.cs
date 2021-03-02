using MasGlobal.DataAccess.Interfaces.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.DataAccess.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
    }
}