using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentnGo.Common
{
    public class Auto
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Anio { get; set; }
        public double PrecioPorDia { get; set; }
        public int Asientos { get; set; }
        public int Puertas { get; set; }
        public bool Auxilio { get; set; }
        public string Color { get; set; }
        public string Foto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Alquilado { get; set; }
        public string Descripcion { get; set; }
        public int Km { get; set; }

        public Auto(int id, string marca, string modelo, string anio, double precioPorDia, int asientos, int puertas, bool auxilio, string color, string foto, string descripcion, int km)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Anio = anio;
            PrecioPorDia = precioPorDia;
            Asientos = asientos;
            Puertas = puertas;
            Auxilio = auxilio;
            Color = color;
            Foto = foto;
            Descripcion = descripcion;
            Km = km;
        }

        public Auto (SqlDataReader reader)
        {
            Id = int.Parse(reader["Id"].ToString());
            Marca = reader["Marca"].ToString();
            Modelo = reader["Modelo"].ToString();
            Anio = reader["Anio"].ToString();
            PrecioPorDia = Convert.ToDouble(reader["PrecioPorDia"].ToString());
            Asientos = int.Parse(reader["Asientos"].ToString());
            Puertas = int.Parse(reader["Puertas"].ToString());
            Auxilio = Convert.ToBoolean(reader["Auxilio"]);
            Color = reader["Color"].ToString();
            Foto = reader["Foto"].ToString();
            Descripcion = reader["Descripcion"].ToString();
            Km = int.Parse(reader["Km"].ToString());

            int iniIndex = reader.GetOrdinal("inicio");
            int finIndex = reader.GetOrdinal("fin");
            if (!reader.IsDBNull(iniIndex) && !reader.IsDBNull(finIndex))
            {
                FechaInicio = Convert.ToDateTime(reader["Inicio"]);
                FechaFin = Convert.ToDateTime(reader["Fin"]);
                Alquilado = DateTime.Now < FechaFin && DateTime.Now > FechaInicio;
            }
            else
            {
                FechaInicio = DateTime.MinValue;
                FechaFin = DateTime.MinValue;
                Alquilado = false;
            }
        }

        public Auto()
        {
        }
    }
}