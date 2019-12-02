using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentnGo.Common
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
            Auto = new Auto(reader);

            int iniIndex = reader.GetOrdinal("inicio");
            int finIndex = reader.GetOrdinal("fin");
            if (!reader.IsDBNull(iniIndex) && !reader.IsDBNull(finIndex))
            {
                FechaInicio = Convert.ToDateTime(reader["Inicio"]);
                FechaFin = Convert.ToDateTime(reader["Fin"]);
                Alquilado = DateTime.Now < FechaFin || DateTime.Now <= FechaInicio;
            }
        }
    }
}