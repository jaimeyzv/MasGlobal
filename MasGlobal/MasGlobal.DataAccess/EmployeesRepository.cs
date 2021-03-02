using MasGlobal.Common.Wrappers;
using MasGlobal.DataAccess.Interfaces;
using MasGlobal.DataAccess.Interfaces.Dtos;
using MasGlobal.Insfrastucture.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.DataAccess
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly IConfigurationManagerWrapper configurationManagerWrapper;

        public EmployeesRepository(IConfigurationManagerWrapper configurationManagerWrapper)
        {
            this.configurationManagerWrapper = configurationManagerWrapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var client = new HttpClientWrapper<IList<EmployeeDto>>();
            var url = configurationManagerWrapper.GetAppSettings("MasGlobalUrl");
            var result = await client.GetAsync(url + "api/Employees");

            return result;            
        }
    }
}
