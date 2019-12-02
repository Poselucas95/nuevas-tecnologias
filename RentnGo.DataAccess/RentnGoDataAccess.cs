using RentnGo.DAL;
using RentnGo.Entidades.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentnGo.DataAccess
{
    public class RentnGoDataAccess
    {
        private static readonly RentnGoDAL _dal = RentnGoDAL.Instance;

        public static void InsertAlquiler(DateTime inicio, DateTime fin, int idAuto, int idUsuario)
        {
            _dal.InsertAlquiler(inicio, fin, idAuto, idUsuario);
        }

        public static void InsertUsuario(Usuario usuario)
        {
            _dal.InsertarUsuario(usuario);
        }

        public static List<Alquiler> GetAlquileres(int idUsuario)
        {
            return _dal.GetAlquileres(idUsuario);
        }

        public static List<Auto> GetUltimosAutos(int cantidad)
        {
            return _dal.GetUltimosAutos(cantidad);
        }
    }
}