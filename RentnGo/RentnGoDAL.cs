using RentnGo.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RentnGo.DAL
{
    public class RentnGoDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection2"].ConnectionString;

        public void InsertAlquiler(DateTime inicio, DateTime fin, int idAuto, string username)
        {

            List<Alquiler> alquileresAuto = GetAlquileresPorAuto(idAuto);
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_add_alquiler", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Inicio", SqlDbType.DateTime).Value = inicio;
                    cmd.Parameters.Add("@Fin", SqlDbType.DateTime).Value = fin;
                    cmd.Parameters.Add("@IdAuto", SqlDbType.Int).Value = idAuto;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InsertarUsuario(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_add_usuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = usuario.UserName;
                    cmd.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = usuario.Apellido;
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = usuario.Nombre;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = usuario.Email;
                    cmd.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = usuario.Telefono;
                    cmd.Parameters.Add("@Documento", SqlDbType.VarChar).Value = usuario.Documento;
                    cmd.Parameters.Add("@TipoDoc", SqlDbType.Int).Value = usuario.TipoDoc.GetHashCode();
                    cmd.Parameters.Add("@FechaNacimiento", SqlDbType.DateTime).Value = usuario.FechaNacimiento;
                    cmd.Parameters.Add("@Nacionalidad", SqlDbType.VarChar).Value = usuario.Nacionalidad;
                    cmd.Parameters.Add("@Domicilio", SqlDbType.VarChar).Value = usuario.Domicilio;
                    cmd.Parameters.Add("@Provincia", SqlDbType.Int).Value = usuario.Provincia.GetHashCode();
                    cmd.Parameters.Add("@Sexo", SqlDbType.VarChar).Value = usuario.Sexo.ToString();

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Auto> GetAlquileres(string username)
        {
            List<Auto> list = new List<Auto>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_get_alquileres", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Auto m = new Auto(reader);
                        list.Add(m);
                    }
                }
            }

            return list;
        }

        public List<Alquiler> GetAlquileresPorAuto(int idAuto)
        {
            List<Alquiler> list = new List<Alquiler>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_get_alquileres_por_auto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdAuto", SqlDbType.Int).Value = idAuto;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Alquiler m = new Alquiler(reader);
                        list.Add(m);
                    }
                }
            }

            return list;
        }

        public Auto GetAuto(int idAuto)
        {
            Auto a = new Auto();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_get_auto", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@IdAuto", SqlDbType.Int).Value = idAuto;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        a = new Auto(reader);
                    }
                }
            }

            return a;
        }

        public List<Auto> GetUltimosAutos(int cantidad)
        {
            List<Auto> autos = new List<Auto>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_get_autos_por_cantidad", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int).Value = cantidad;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        autos.Add(new Auto(reader));
                    }
                }
            }

            return autos;
        }

        public List<Auto> GetAutosDisponibles()
        {
            List<Auto> autos = new List<Auto>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_get_autos_disponibles", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        autos.Add(new Auto(reader));
                    }
                }
            }

            return autos;
        }

    }
}