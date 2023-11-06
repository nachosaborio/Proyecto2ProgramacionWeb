using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;

namespace Proyecto2API.Controllers
{
    [Route("api/Parqueo")]
    [ApiController]
    public class ParqueoController : ControllerBase
    {
        [HttpPost("AddParqueo")]
        public ActionResult AddParqueo([FromBody] Parqueo value)
        {
            Cache.AddParqueo(value);
            return Ok(value);
        }

        [HttpGet("GetAllParqueos")]
        public ActionResult<IEnumerable<Parqueo>> GetAllParqueos()
        {
            return Ok(Cache.GetAllParqueos());
        }

        [HttpGet("GetParqueoXId/{id}")]
        public ActionResult<Parqueo> GetParqueoXId(int id) { 
            return Ok(Cache.GetParqueoXId(id));
        }

        [HttpPost("UpdateParqueo")]
        public ActionResult UpdateParqueo([FromBody] Parqueo value)
        {
            Cache.UpdateParqueo(value);
            return Ok(value);
        }

        [HttpDelete("DeleteParqueo/{id}")]
        public ActionResult DeleteParqueo(int id)
        {
            Cache.DeleteParqueo(id);
            return Ok();
        }
    }
}
