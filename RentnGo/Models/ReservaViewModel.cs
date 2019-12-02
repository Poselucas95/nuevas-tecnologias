using RentnGo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentnGo.Models
{
    public class ReservaViewModel
    {
        public Auto Auto { get; set; }
        public string Mensaje { get; set; }
        public int Codigo { get; set; }
    }
}