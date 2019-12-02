using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentnGo.Entidades.Common
{
    public class Usuario
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Documento { get; set; }
        public TipoDocEnum TipoDoc { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string Domicilio { get; set; }
        public ProvinciaEnum Provincia { get; set; }
        public SexoEnum Sexo { get; set; }
        public List<Alquiler> Alquileres { get; set; }

        public Usuario(int id, string userName, string apellido, string nombre, string email,
            string telefono, string documento, TipoDocEnum tipoDoc, DateTime fechaNacimiento,
            string nacionalidad, string domicilio, ProvinciaEnum provincia, SexoEnum sexo, List<Alquiler> alquileres)
        {
            Id = id;
            UserName = userName;
            Apellido = apellido;
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
            Documento = documento;
            TipoDoc = tipoDoc;
            FechaNacimiento = fechaNacimiento;
            Nacionalidad = nacionalidad;
            Domicilio = domicilio;
            Provincia = provincia;
            Sexo = sexo;
            Alquileres = alquileres;
        }

        public Usuario()
        {
        }

    }
}