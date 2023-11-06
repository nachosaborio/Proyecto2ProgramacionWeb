using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;

namespace Proyecto2API.Controllers
{
    [Route("api/Tiquete")]
    [ApiController]
    public class TiqueteController : ControllerBase
    {
        [HttpPost("AddTiquete")]
        public ActionResult AddTiquete([FromBody] Tiquete value)
        {
            Cache.AddTiquete(value);
            return Ok(value);
        }

        [HttpGet("GetAllTiquetes")]
        public ActionResult<IEnumerable<Tiquete>> GetAllTiquetes()
        {
            return Ok(Cache.GetAllTiquetes());
        }

        [HttpGet("GetTiqueteXId/{id}")]
        public ActionResult<Tiquete> GetTiqueteXId(int id) { 
            return Ok(Cache.GetTiqueteXId(id));
        }

        [HttpPost("UpdateTiquete")]
        public ActionResult UpdateTiquete([FromBody] Tiquete value)
        {
            Cache.UpdateTiquete(value);
            return Ok(value);
        }

        [HttpDelete("DeleteTiquete/{id}")]
        public ActionResult DeleteTiquete(int id)
        {
            Cache.DeleteTiquete(id);
            return Ok();
        }
    }
}
