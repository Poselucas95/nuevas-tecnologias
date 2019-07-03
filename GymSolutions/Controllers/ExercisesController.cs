using GymSolutions.Models;
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
            GymSolutionEntities contexto = new GymSolutionEntities();
            var musculos = contexto.Categoria.ToList();
            return View(musculos);
        }

        // GET: Exercises
        public ActionResult Exercise()
        {
            return View();
        }
    }
}