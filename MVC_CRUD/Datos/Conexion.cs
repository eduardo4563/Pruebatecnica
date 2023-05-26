using System.Data.SqlClient;
namespace MVC_CRUD.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;
        
        public Conexion()
        {
            var builer = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builer.GetSection("ConnectionStrings:CadenaSQL").Value;



        }
        public string getCADENASQL()
        {
            return cadenaSQL;
        }
    }
}
