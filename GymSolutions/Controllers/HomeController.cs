using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymSolutions.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult loggedOutIfNeeded(ActionResult view) {
            if (!Request.IsAuthenticated)
            { // Devolvemos al usuario a la pagina de inicio si no esta logueado
                return RedirectToAction("Index", "Home");
            }

            return view;
        }
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
            ViewBag.Message = "Explore";
            return loggedOutIfNeeded(View());
        }

        public ActionResult ExploreRoutine(String rutinaDto) // TODO cambiar a objeto rutina
        {
            ActionResult view = PartialView(rutinaDto);

            // TODO agregar a la view data necesaria

            return loggedOutIfNeeded(view);
        }
    }
}