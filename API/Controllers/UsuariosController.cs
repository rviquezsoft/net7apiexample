using API.Services;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Models;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : BaseEntityController<Usuario>
    {
        public UsuariosController(IDBService<Usuario> dBService) : base(dBService)
        {
        }
    }
}
