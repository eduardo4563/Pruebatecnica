using MVC_CRUD.Models;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.Xml;

namespace MVC_CRUD.Datos
{
    public class Librosdatos
    {
       
        public List<librosmodel> Listar()
        {
            var  olista=new List<librosmodel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCADENASQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar_li",conexion);
               
                cmd.CommandType = CommandType.StoredProcedure;
                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new librosmodel()
                        {
                            id_libro =Convert.ToInt32(dr["id_libro"]),
                            descripcion = dr["descripcion"].ToString(),
                            asignatura = Convert.ToInt32(dr["asignatura"]),
                            stock = Convert.ToInt32(dr["stock"]),


                        });
                    }
                }
            }
            return olista;
        }

       

        public List<librosmodel> Busqueda(string busqueda)
        {
            var olista = new List<librosmodel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCADENASQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar_libros", conexion);
                cmd.Parameters.AddWithValue("busqueda", busqueda);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new librosmodel()
                        {
                            id_libro = Convert.ToInt32(dr["id_libro"]),
                            descripcion = dr["descripcion"].ToString(),
                            asignatura = Convert.ToInt32(dr["asignatura"]),
                            stock = Convert.ToInt32(dr["stock"]),
                            

                        });
                    }
                }
            }
            return olista;
        }


        public librosmodel Obtener(int Idlibros)
        {
            var olibros = new librosmodel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCADENASQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener", conexion);
                cmd.Parameters.AddWithValue("Idlibros", Idlibros);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olibros.id_libro = Convert.ToInt32(dr["id_libro"]);
                        olibros.descripcion = dr["descripcion"].ToString();
                        olibros.asignatura = Convert.ToInt32(dr["asignatura"]);
                        olibros.stock = Convert.ToInt32(dr["stock"]);
                    }
                }
            }
            return olibros;
        }


        public bool Guardar(librosmodel olirbos)
        {
            bool rpta;

            try
            {

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCADENASQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_insertar_libros", conexion);
                    cmd.Parameters.AddWithValue("id_libro", olirbos.id_libro);
                    cmd.Parameters.AddWithValue("descripcion", olirbos.descripcion);
                    cmd.Parameters.AddWithValue("asignatura", olirbos.asignatura);
                    cmd.Parameters.AddWithValue("stock", olirbos.stock);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }


        public bool Actualizar(librosmodel olirbos)
        {
            bool rpta;

            try
            {

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCADENASQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editar_libros", conexion);
                    cmd.Parameters.AddWithValue("id_libro", olirbos.id_libro);
                    cmd.Parameters.AddWithValue("descripcion", olirbos.descripcion);
                    cmd.Parameters.AddWithValue("asignatura", olirbos.asignatura);
                    cmd.Parameters.AddWithValue("stock", olirbos.stock);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }


        public bool Eliminar(int Idlibros)
        {
            bool rpta;

            try
            {

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCADENASQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_borrar_libros", conexion);
                    cmd.Parameters.AddWithValue("id_libro", Idlibros);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }


            return rpta;
        }



    }

    
}
