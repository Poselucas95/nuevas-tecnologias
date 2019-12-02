using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentnGo.Entidades.Common
{
    public class Alquiler
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Auto Auto { get; set; }
        public bool Alquilado { get; set; }

        public Alquiler()
        {
        }
        public Alquiler(int id, DateTime fechaInicio, DateTime fechaFin, Auto auto)
        {
            Id = id;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Auto = auto;
            Alquilado = DateTime.Now >= fechaInicio && DateTime.Now <= fechaFin;
        }

        public Alquiler(SqlDataReader reader)
        {
            Id = int.Parse(reader["Id"].ToString());
            FechaInicio = Convert.ToDateTime(reader["FechaInicio"]);
            FechaFin = Convert.ToDateTime(reader["FechaFin"]);
            Auto = new Auto(reader);
            Alquilado = DateTime.Now >= FechaInicio && DateTime.Now <= FechaFin;
        }
    }
}