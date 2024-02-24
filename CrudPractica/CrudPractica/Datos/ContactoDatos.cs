using CrudPractica.Models;
using System.Data.SqlClient;
//using System.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CrudPractica.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel>ObtenerLista()
        {
            var lista = new List<ContactoModel>();

            var con = new Conexion();

            using (var conexion = new SqlConnection(con.getCadenaSQL())){ // con este retorno de esa caneda estamos creando la conexio hacia sql
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) // leer uno a uno los registros y mientras hayan datos
                    {
                        lista.Add(new ContactoModel() // agreguelos a la lista
                        {
                            Idcontacto = Convert.ToInt32( dr["Idcontacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                        }); 
                    }
                }
            }
            return lista;
        }

        public ContactoModel ObtenerContacto(int Idcontacto)
        {
            var contacto = new ContactoModel();

            var con = new Conexion();

            using (var conexion = new SqlConnection(con.getCadenaSQL()))
            { // con este retorno de esa caneda estamos creando la conexio hacia sql
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdContacto", Idcontacto); // parametro que recibe el procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure; // aqui se indica que es un procedimiento almacenado

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) // leer uno a uno los registros y mientras hayan datos
                    {
                        contacto.Idcontacto = Convert.ToInt32(dr["Idcontacto"]);
                        contacto.Nombre = dr["Nombre"].ToString();
                        contacto.Telefono = dr["Telefono"].ToString();
                        contacto.Correo = dr["Correo"].ToString();
                    }
                }
            }
            return contacto;
        }

        public bool Guardar(ContactoModel contacto)
        {
            bool respuesta;
            try
            {
                var con = new Conexion();

                using (var conexion = new SqlConnection(con.getCadenaSQL()))
                { // con este retorno de esa caneda estamos creando la conexio hacia sql
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", contacto.Nombre); // parametro que recibe el procedimiento almacenado
                    cmd.Parameters.AddWithValue("Telefono", contacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", contacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure; // aqui se indica que es un procedimiento almacenado
                    cmd.ExecuteNonQuery(); // este metodo es de ejecucion porque hay que hacer un cambio en la tabla de la base de datos. Los metodos anteriores solo son de obtener info
                }
                respuesta = true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                respuesta=false;
            }
            return respuesta;
        }

        public bool Editar(ContactoModel contacto)
        {
            bool respuesta;
            try
            {
                var con = new Conexion();

                using (var conexion = new SqlConnection(con.getCadenaSQL()))
                { // con este retorno de esa caneda estamos creando la conexio hacia sql
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("Idcontacto", contacto.Idcontacto);
                    cmd.Parameters.AddWithValue("Nombre", contacto.Nombre); // parametro que recibe el procedimiento almacenado
                    cmd.Parameters.AddWithValue("Telefono", contacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", contacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure; // aqui se indica que es un procedimiento almacenado
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Eliminar(int Idcontacto)
        {
            bool respuesta;
            try
            {
                var con = new Conexion();

                using (var conexion = new SqlConnection(con.getCadenaSQL()))
                { // con este retorno de esa caneda estamos creando la conexio hacia sql
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("Idcontacto", Idcontacto);
                    cmd.CommandType = CommandType.StoredProcedure; // aqui se indica que es un procedimiento almacenado
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {

                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
