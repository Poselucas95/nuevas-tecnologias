using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymSolutions.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace GymSolutions.Controllers
{


    public class ProfileController : Controller
    {     

        public async System.Threading.Tasks.Task<ApplicationUser> GetUserAsync() {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            return await userManager.FindByEmailAsync(User.Identity.Name);
        }

        // GET: Profile
        public ActionResult Index()
        {
            
            var user = GetUserAsync();
            if (user != null) {
               
            }
                return View();
        }
    }
}