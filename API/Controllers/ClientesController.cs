using API.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : BaseEntityController<Cliente>
    {
        public ClientesController(IDBService<Cliente> dBService) : base(dBService)
        {
        }
    }
}
