using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymSolutions.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

     
        public ActionResult Explore()
        {
            if (!Request.IsAuthenticated) { // Devolvemos al usuario a la pagina de inicio si no esta logueado
                return RedirectToAction("Index", "Home");
                
            }
            ViewBag.Message = "Explorar";
            return View();
        }
    }
}