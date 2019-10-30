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
    public class EjerciciosController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Ejercicios
        public ActionResult Index()
        {
            return View(db.Ejercicio.ToList());
        }

        // GET: Ejercicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejercicio ejercicio = db.Ejercicio.Find(id);
            if (ejercicio == null)
            {
                return HttpNotFound();
            }
            return View(ejercicio);
        }

        // GET: Ejercicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ejercicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_EJERCICIO,ejNombre,ejDesc,ejMedia")] Ejercicio ejercicio)
        {
            if (ModelState.IsValid)
            {
                db.Ejercicio.Add(ejercicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ejercicio);
        }

        // GET: Ejercicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejercicio ejercicio = db.Ejercicio.Find(id);
            if (ejercicio == null)
            {
                return HttpNotFound();
            }
            return View(ejercicio);
        }

        // POST: Ejercicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_EJERCICIO,ejNombre,ejDesc,ejMedia")] Ejercicio ejercicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ejercicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ejercicio);
        }

        // GET: Ejercicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejercicio ejercicio = db.Ejercicio.Find(id);
            if (ejercicio == null)
            {
                return HttpNotFound();
            }
            return View(ejercicio);
        }

        // POST: Ejercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ejercicio ejercicio = db.Ejercicio.Find(id);
            db.Ejercicio.Remove(ejercicio);
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
