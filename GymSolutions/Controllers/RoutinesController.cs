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


        // GET: Routines
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult VerRutina()
        {
            return View();
        }

        public ActionResult NuevaRutina( int ejer = 1)
        {
            

            return View();
        }

        public ActionResult EditarRutina()
        {
            return View();
        }

    }
}