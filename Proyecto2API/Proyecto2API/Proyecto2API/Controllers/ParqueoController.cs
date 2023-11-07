using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;

namespace Proyecto2API.Controllers
{
    [Route("api/Parqueo")]
    [ApiController]
    public class ParqueoController : ControllerBase
    {
        public ParqueoController()
        {
            Parqueo parqueo = new Parqueo { 
                    Id = 1,
                    Nombre = "Parqueo 1",
                    CapacidadMaxima = 50,
                    HoraApertura = new DateTime(1,1,1,7,0,0),
                    HoraCierrre = new DateTime(1,1,1,19,0,0)
                };
            AddParqueo(parqueo);
        }

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
