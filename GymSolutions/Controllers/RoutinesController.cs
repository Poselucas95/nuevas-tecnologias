using GymSolutions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymSolutions.Controllers
{
    public class RoutinesController : Controller
    {
        GymSolutionEntities contexto = new GymSolutionEntities();


        // GET: Routines
        public ActionResult Index()
        {
            var rutinas = contexto.Rutina.ToList();

            return View(rutinas);
        }

        public ActionResult VerRutina()
        {
            return View();
        }

        public ActionResult NuevaRutina( int ejer = 1, int id)
        {
            GymSolutionEntities contexto = new GymSolutionEntities();

            var ejercicios = contexto.

            return View(ejercicios);
        }

        public ActionResult EditarRutina()
        {
            return View();
        }

    }
}