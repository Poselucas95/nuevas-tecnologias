using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentnGo.Entidades.Common
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

        public Auto(int id, string marca, string modelo, string anio, double precioPorDia, int asientos, int puertas, bool auxilio, string color, string foto)
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
        }

        public Auto()
        {
        }
    }
}