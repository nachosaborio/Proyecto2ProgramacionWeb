using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;

namespace Proyecto1.Controllers
{
    public class TiqueteController : Controller
    {
        // GET: TiqueteController
        public ActionResult Index()
        {
            List<Tiquete> tiquetes = Cache.GetAllTiquetes();
            return View(tiquetes);
        }

        // GET: TiqueteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiqueteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tiquete tiquete)
        {
            try
            {
                List<Tiquete> tiquetes = Cache.GetAllTiquetes();
                if (tiquetes.Count == 0)
                {
                    tiquete.Id = 1;
                }
                else
                {
                    tiquete.Id = tiquetes.Last().Id + 1;
                }
                Cache.AddTiquete(tiquete);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TiqueteController/Edit/5
        public ActionResult Edit(int id)
        {
            Tiquete tiquete = Cache.GetTiqueteXId(id);
            return View(tiquete);
        }

        // POST: TiqueteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tiquete tiquete)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cache.UpdateTiquete(tiquete);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: TiqueteController/Delete/5
        public ActionResult Delete(int id)
        {
            Tiquete tiquete = Cache.GetTiqueteXId(id);
            return View(tiquete);
        }

        // POST: TiqueteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Tiquete tiquete)
        {
            Cache.DeleteTiquete(tiquete.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
