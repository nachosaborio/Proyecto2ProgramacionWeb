using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;

namespace Proyecto1.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: EmpleadoControllet
        public ActionResult Index()
        {
            List<Empleado> empleados = Cache.GetAllEmpleados();
            return View(empleados);
        }

        // GET: EmpleadoControllet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpleadoControllet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoControllet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado empleado)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Cache.AddEmpleado(empleado);
                    return RedirectToAction(nameof(Index));
                }
                else { 
                    return View(); 
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoControllet/Edit/5
        public ActionResult Edit(int id)
        {
            Empleado empleado = Cache.GetEmpleadoXId(id);
            return View(empleado);
        }

        // POST: EmpleadoControllet/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Empleado empleado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cache.UpdateEmpleado(empleado);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoControllet/Delete/5
        public ActionResult Delete(int id)
        {
            Empleado empleado = Cache.GetEmpleadoXId(id);
            return View(empleado); 
        }

        // POST: EmpleadoControllet/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Empleado empleado)
        {
            Cache.DeleteEmpleado(empleado.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
