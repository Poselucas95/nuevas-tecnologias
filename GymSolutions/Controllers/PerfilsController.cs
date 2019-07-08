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
    public class PerfilsController : Controller
    {
        private Entities db = new Entities();

        // GET: Perfils
        public ActionResult Index()
        {
            String id = db.AspNetUsers.Where(x => x.UserName == User.Identity.Name).Select(x => x.Id).First();
            if (db.Perfil.Where(x => x.ID_PERFIL == id).Count() == 1)
            {
                var perfil = db.Perfil.Include(p => p.AspNetUsers);
                return View(perfil.ToList());
            }
            return View();
        }

        // GET: Perfils/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfil.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // GET: Perfils/Create
        public ActionResult Create()
        {
            ViewBag.ID_PERFIL = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Perfils/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PERFIL,perfilNombre,perfilApellido,perfilEdad,perfilAltura,perfilPeso")] Perfil perfil)
        {
            //Perfil perfil = new Perfil(db.AspNetUsers.Where(x => x.Email == model.Email).Select(x => x.Id).First());
            if (ModelState.IsValid)
            {
                db.Perfil.Add(perfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PERFIL = new SelectList(db.AspNetUsers, "Id", "Email", perfil.ID_PERFIL);
            return View(perfil);
        }

        // GET: Perfils/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfil.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PERFIL = new SelectList(db.AspNetUsers, "Id", "Email", perfil.ID_PERFIL);
            return View(perfil);
        }

        // POST: Perfils/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PERFIL,perfilNombre,perfilApellido,perfilEdad,perfilAltura,perfilPeso")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(perfil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PERFIL = new SelectList(db.AspNetUsers, "Id", "Email", perfil.ID_PERFIL);
            return View(perfil);
        }

        // GET: Perfils/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfil.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: Perfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Perfil perfil = db.Perfil.Find(id);
            db.Perfil.Remove(perfil);
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
