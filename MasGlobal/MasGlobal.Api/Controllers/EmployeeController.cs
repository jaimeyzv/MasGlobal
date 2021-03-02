using MasGlobal.Business.Interfaces;
using MasGlobal.Insfrastucture.Interfaces;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MasGlobal.Api.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeBusiness employeeBusiness;
        private readonly IMapper mapper;
        
        public EmployeeController(IEmployeeBusiness employeeBusiness,
            IMapper mapper)
        {
            this.employeeBusiness = employeeBusiness;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("~/api/employees/{id}")]
        public async Task<HttpResponseMessage> GetByIdAsync(int id)
        {
            if (id < 0) return Request.CreateResponse(HttpStatusCode.BadRequest, $"Id {id} is not valid");
            var entity = await employeeBusiness.GetByIdAsync(id);
            if (entity == null) return Request.CreateResponse(HttpStatusCode.NotFound, $"Employee with id {id} does not exist.");
            var model = mapper.MapFromEntityToViewModel(entity);

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [HttpGet]
        [Route("~/api/employees/")]
        public async Task<HttpResponseMessage> GetAllAsync()
        {
            var entities = await employeeBusiness.GetAllAsync();
            var models = (from r in entities.ToList() select this.mapper.MapFromEntityToViewModel(r)).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, models);
        }
    }
}
