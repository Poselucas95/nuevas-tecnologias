using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GymSolutions.Models;

namespace GymSolutions.Controllers
{
    public class RutinasController : Controller
    {
        private GymSolutionEntities1 db = new GymSolutionEntities1();

        // GET: Rutinas
        public ActionResult Index()
        {
            var rutina = db.Rutina.Include(r => r.Perfil);
            return View(rutina.ToList());
        }

        // GET: Rutinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutina rutina = db.Rutina.Find(id);
            if (rutina == null)
            {
                return HttpNotFound();
            }
            return View(rutina);
        }

        // GET: Rutinas/Create
        public ActionResult Create()
        {
            ViewBag.ID_PERFIL = new SelectList(db.Perfil, "ID_PERFIL", "perfilNombre");
            return View();
        }

        // POST: Rutinas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RUTINA,rutNombre,rutFechaCreacion,rutFechaModificacion,ID_PERFIL,usuCreador")] Rutina rutina)
        {
            if (ModelState.IsValid)
            {
                db.Rutina.Add(rutina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PERFIL = new SelectList(db.Perfil, "ID_PERFIL", "perfilNombre", rutina.ID_PERFIL);
            return View(rutina);
        }

        // GET: Rutinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutina rutina = db.Rutina.Find(id);
            if (rutina == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PERFIL = new SelectList(db.Perfil, "ID_PERFIL", "perfilNombre", rutina.ID_PERFIL);
            return View(rutina);
        }

        // POST: Rutinas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RUTINA,rutNombre,rutFechaCreacion,rutFechaModificacion,ID_PERFIL,usuCreador")] Rutina rutina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rutina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PERFIL = new SelectList(db.Perfil, "ID_PERFIL", "perfilNombre", rutina.ID_PERFIL);
            return View(rutina);
        }

        // GET: Rutinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rutina rutina = db.Rutina.Find(id);
            if (rutina == null)
            {
                return HttpNotFound();
            }
            return View(rutina);
        }

        // POST: Rutinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rutina rutina = db.Rutina.Find(id);
            db.Rutina.Remove(rutina);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
