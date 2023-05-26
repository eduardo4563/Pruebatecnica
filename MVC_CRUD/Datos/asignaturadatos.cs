using MVC_CRUD.Models;
using System.Data.SqlClient;
using System.Data;
namespace MVC_CRUD.Datos
{
    public class asignaturadatos
    {
        public List<asignaturamodel> Listar()
        {
            var olista = new List<asignaturamodel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCADENASQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar_asignatura", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new asignaturamodel()
                        {
                            id_asig = Convert.ToInt32(dr["id_asig"]),
                            descripcion = dr["descripcion"].ToString(),
                            estado = Convert.ToInt32(dr["estado"]),
                           


                        });
                    }
                }
            }
            return olista;
        }


        public asignaturamodel Obtener(int Idasignatura)
        {
            var oasignatura = new asignaturamodel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCADENASQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener_asignatura", conexion);
                cmd.Parameters.AddWithValue("Idasignatura", Idasignatura);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oasignatura.id_asig = Convert.ToInt32(dr["id_asig"]);
                        oasignatura.descripcion = dr["descripcion"].ToString();
                        oasignatura.estado = Convert.ToInt32(dr["estado"]);
                       
                    }
                }
            }
            return oasignatura;
        }


        public bool Guardar(asignaturamodel oasig)
        {
            bool rpta;

            try
            {

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCADENASQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_insertar_asigantura", conexion);
                    cmd.Parameters.AddWithValue("id_asig", oasig.id_asig);
                    cmd.Parameters.AddWithValue("descripcion", oasig.descripcion);
                    cmd.Parameters.AddWithValue("estado", oasig.estado);
                    
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


        public bool Actualizar(asignaturamodel oasig)
        {
            bool rpta;

            try
            {

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCADENASQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editar_asignatura", conexion);
                    cmd.Parameters.AddWithValue("id_asig", oasig.id_asig);
                    cmd.Parameters.AddWithValue("descripcion", oasig.descripcion);
                    cmd.Parameters.AddWithValue("estado", oasig.estado);
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


        public bool Eliminar(int Idasignatura)
        {
            bool rpta;

            try
            {

                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCADENASQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_borrar_asignatura", conexion);
                    cmd.Parameters.AddWithValue("id_asignatura", Idasignatura);
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
