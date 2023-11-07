using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;

namespace Proyecto2API.Controllers
{
    [Route("api/Empleado")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        public EmpleadoController()
        {
            Empleado empleado = new Empleado
            {
                Id = 1,
                Parqueo = 1,
                FechaIngreso =  new DateTime(2000,05,10),
                Nombre = "Amtonio",
                Apellidos = "López Mora",
                FechaDeNacimiento = new DateTime(1980,03,21),
                Cedula = 100010001,
                Direccion = "Zapote, San José",
                Email = "antonio@email.com",
                Telefono = 88112233,
                PersonaDeContacto = "Antonia López Mora"
            };

            AddEmpleado(empleado);
        }

        [HttpPost("AddEmpleado")]
        public ActionResult AddEmpleado([FromBody] Empleado value)
        {
            Cache.AddEmpleado(value);
            return Ok(value);
        }

        [HttpGet("GetAllEmpleados")]
        public ActionResult<IEnumerable<Empleado>> GetAllEmpleados()
        {
            return Ok(Cache.GetAllEmpleados());
        }

        [HttpGet("GetEmpleadoXId/{id}")]
        public ActionResult<Empleado> GetEmpleadoXId(int id) { 
            return Ok(Cache.GetEmpleadoXId(id));
        }

        [HttpPost("UpdateEmpleado")]
        public ActionResult UpdateEmpleado([FromBody] Empleado value)
        {
            Cache.UpdateEmpleado(value);
            return Ok(value);
        }

        [HttpDelete("DeleteEmpleado/{id}")]
        public ActionResult DeleteEmpleado(int id)
        {
            Cache.DeleteEmpleado(id);
            return Ok();
        }
    }
}
