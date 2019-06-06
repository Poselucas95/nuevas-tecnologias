using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymSolutions.Controllers
{
    public class ExercisesController : Controller
    {
        // GET: Exercises
        public ActionResult Index()
        {
            return View();
        }

        // GET: Exercises
        public ActionResult Exercise()
        {
            return View();
        }
    }
}