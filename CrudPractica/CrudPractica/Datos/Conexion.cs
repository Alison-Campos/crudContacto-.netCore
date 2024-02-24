/*Todas las transacciones se van a hacer atravez de ado . net*/


namespace CrudPractica.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build(); ///obtener la cadena de conexion que esta en el archivo appsettings

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;//ahora le digo que me traiga solo lo que esta en esta seccion
        
        }

        public string getCadenaSQL()
        {
            return cadenaSQL;
        }

    }
}
