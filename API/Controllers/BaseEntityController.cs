using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase where T:class
    {
        private readonly IDBService<T> _dBService;//inyección del servicio

        public BaseEntityController(IDBService<T> dBService)
        {
            _dBService = dBService;
        }

        [HttpGet]
        [EnableQuery]//Para poder realizar filtros sobre la tabla (order by,count,joins, etc)
        public async Task<IActionResult> Get()
        {
            return Ok(await _dBService.Get()); 
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T entity)
        {
            return Ok(await _dBService.Post(entity));
        }

        [HttpPatch]
        public async Task<IActionResult> Patch([FromBody] T entity)
        {
            return Ok(await _dBService.Patch(entity));
        }

    }
}
