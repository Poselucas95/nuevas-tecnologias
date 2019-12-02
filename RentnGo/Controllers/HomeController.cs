using RentnGo.DAL;
using RentnGo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentnGo.Models;
using System.Net.Mail;

namespace RentnGo.Controllers
{
    public class HomeController : Controller
    {
        readonly RentnGoDAL _dal = new RentnGoDAL();

        public ActionResult Index()
        {
            List<Auto> autos = _dal.GetUltimosAutos(4);
            return View(autos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
        public ActionResult Contact(ContactViewModel vm)
        {
            if(vm.Name != null && vm.Message != null && vm.Email != null)
            {
                MailMessage mailMsg = new MailMessage();
                mailMsg.To.Add("destino@gmail.com");
                // From
                MailAddress mailAddress = new MailAddress(vm.Email);
                mailMsg.From = mailAddress;

                // Subject and Body
                mailMsg.Subject = "asd";
                mailMsg.Body = vm.Message;

                // Init SmtpClient and send on port 587 in my case. (Usual=port25)
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                System.Net.NetworkCredential credentials =
                   new System.Net.NetworkCredential("usuario@gmail.com", "clave");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
            }

            return View();
        }

        public ActionResult Autos()
        {
            List<Auto> autos = _dal.GetAutosDisponibles();
            return View(autos);
        }

        public ActionResult Reservar(int id)
        {
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            Auto auto = _dal.GetAuto(id);
            auto.FechaFin = Convert.ToDateTime(fechaActual);
            auto.FechaInicio = Convert.ToDateTime(fechaActual);
            return View(auto);
        }

        [HttpPost]
        public ActionResult Reservar(Auto auto)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmarReserva(Auto auto)
        {
            ReservaViewModel vm = new ReservaViewModel();
            vm.Auto = auto;

            List<Alquiler> alquileres =_dal.GetAlquileresPorAuto(auto.Id);
            bool estaAlquilado = false;
            estaAlquilado = alquileres.Any(x => (x.FechaInicio >= auto.FechaInicio && x.FechaInicio <= auto.FechaFin) || (x.FechaFin >= auto.FechaInicio && x.FechaFin <= auto.FechaFin));

            DateTime a = DateTime.UtcNow;
            DateTime fechaActual = new DateTime(a.Year, a.Month, a.Day, 0, 0, 0, DateTimeKind.Utc);

            if (estaAlquilado)
            {
                vm.Mensaje = "Mala suerte, el auto se encuentra alquilado en la fecha elegida. Por favor elige otra fecha.";
                vm.Codigo = 1;
            }
            else if(auto.FechaInicio > auto.FechaFin)
            {
                vm.Mensaje = "La fecha de inicio de la reserva no puede ser mayor a la fecha de fin.";
                vm.Codigo = 2;
            }
            else if(auto.FechaInicio < fechaActual)
            {
                vm.Mensaje = "La fecha de inicio de la reserva no puede ser menor a la fecha actual.";
                vm.Codigo = 3;

            }
            else
            {
                _dal.InsertAlquiler(auto.FechaInicio, auto.FechaFin, auto.Id, User.Identity.Name);
                vm.Mensaje = "Reserva correcta";
                vm.Codigo = 0;
            }

            return View(vm);
        }

        public ActionResult MisReservas()
        {
            List<Auto> autos = _dal.GetAlquileres(User.Identity.Name);
            return View(autos);
        }
    }
}