using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;

namespace Proyecto1.Controllers
{
    public class ParqueoController : Controller
    {
        // GET: ParqueoController
        public ActionResult Index()
        {
            List<Parqueo> parqueos = Cache.GetAllParqueos();
            return View(parqueos);
        }

        // GET: ParqueoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParqueoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Parqueo parqueo)
        {
            try
            {
                List<Parqueo> parqueos = Cache.GetAllParqueos();
                if (parqueos.Count == 0)
                {
                    parqueo.Id = 1;
                }
                else
                {
                    parqueo.Id = parqueos.Last().Id + 1;
                }
                Cache.AddParqueo(parqueo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ParqueoController/Edit/5
        public ActionResult Edit(int id)
        {
            Parqueo parqueo = Cache.GetParqueoXId(id);
            return View(parqueo);
        }

        // POST: ParqueoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Parqueo parqueo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cache.UpdateParqueo(parqueo);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ParqueoController/Delete/5
        public ActionResult Delete(int id)
        {
            Parqueo parqueo = Cache.GetParqueoXId(id);
            return View(parqueo); ;
        }

        // POST: ParqueoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Parqueo parqueo)
        {
            Cache.DeleteParqueo(parqueo.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
