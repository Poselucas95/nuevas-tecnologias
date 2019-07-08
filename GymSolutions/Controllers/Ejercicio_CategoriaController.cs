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
    public class Ejercicio_CategoriaController : Controller
    {
        private Entities db = new Entities();

        // GET: Ejercicio_Categoria
        public ActionResult Index()
        {
            var ejercicio_Categoria = db.Ejercicio_Categoria.Include(e => e.Categoria).Include(e => e.Ejercicio);
            return View(ejercicio_Categoria.ToList());
        }

        // GET: Ejercicio_Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejercicio_Categoria ejercicio_Categoria = db.Ejercicio_Categoria.Find(id);
            if (ejercicio_Categoria == null)
            {
                return HttpNotFound();
            }
            return View(ejercicio_Categoria);
        }

        // GET: Ejercicio_Categoria/Create
        public ActionResult Create()
        {
            ViewBag.ID_CATEGORIA = new SelectList(db.Categoria, "ID_CATEGORIA", "catNombre");
            ViewBag.ID_EJERCICIO = new SelectList(db.Ejercicio, "ID_EJERCICIO", "ejNombre");
            return View();
        }

        // POST: Ejercicio_Categoria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EJERCICIO_CATEGORIA,ID_EJERCICIO,ID_CATEGORIA")] Ejercicio_Categoria ejercicio_Categoria)
        {
            if (ModelState.IsValid)
            {
                db.Ejercicio_Categoria.Add(ejercicio_Categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CATEGORIA = new SelectList(db.Categoria, "ID_CATEGORIA", "catNombre", ejercicio_Categoria.ID_CATEGORIA);
            ViewBag.ID_EJERCICIO = new SelectList(db.Ejercicio, "ID_EJERCICIO", "ejNombre", ejercicio_Categoria.ID_EJERCICIO);
            return View(ejercicio_Categoria);
        }

        // GET: Ejercicio_Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejercicio_Categoria ejercicio_Categoria = db.Ejercicio_Categoria.Find(id);
            if (ejercicio_Categoria == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.Categoria, "ID_CATEGORIA", "catNombre", ejercicio_Categoria.ID_CATEGORIA);
            ViewBag.ID_EJERCICIO = new SelectList(db.Ejercicio, "ID_EJERCICIO", "ejNombre", ejercicio_Categoria.ID_EJERCICIO);
            return View(ejercicio_Categoria);
        }

        // POST: Ejercicio_Categoria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EJERCICIO_CATEGORIA,ID_EJERCICIO,ID_CATEGORIA")] Ejercicio_Categoria ejercicio_Categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ejercicio_Categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CATEGORIA = new SelectList(db.Categoria, "ID_CATEGORIA", "catNombre", ejercicio_Categoria.ID_CATEGORIA);
            ViewBag.ID_EJERCICIO = new SelectList(db.Ejercicio, "ID_EJERCICIO", "ejNombre", ejercicio_Categoria.ID_EJERCICIO);
            return View(ejercicio_Categoria);
        }

        // GET: Ejercicio_Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejercicio_Categoria ejercicio_Categoria = db.Ejercicio_Categoria.Find(id);
            if (ejercicio_Categoria == null)
            {
                return HttpNotFound();
            }
            return View(ejercicio_Categoria);
        }

        // POST: Ejercicio_Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ejercicio_Categoria ejercicio_Categoria = db.Ejercicio_Categoria.Find(id);
            db.Ejercicio_Categoria.Remove(ejercicio_Categoria);
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
