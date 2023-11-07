using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;

namespace Proyecto2API.Controllers
{
    [Route("api/Tiquete")]
    [ApiController]
    public class TiqueteController : ControllerBase
    {
        public TiqueteController()
        {
            Tiquete tiquete = new Tiquete { 
                Id = 1,
                Parqueo = 1,
                FechaYHoraEntrada = new DateTime(2023,1,1,7,0,0),
                FechaYHoraSalida = new DateTime(2023,1,1,19,0,0),
                Placa = "BBB000",
                TarifaPorHora = 2000f,
                TarifaPorMediaHora = 1000f
            };
            AddTiquete(tiquete);
        }

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
