using API.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpleadosController : BaseEntityController<Empleado>
    {
        public EmpleadosController(IDBService<Empleado> dBService) : base(dBService)
        {
        }
    }
}
