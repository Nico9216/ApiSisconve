namespace Sisconve.Persistencia
{
    internal class Conexion

    {
        
        private static string conexion = "Data Source=SERVERBD; Initial Catalog = Sisconve; User Id = sisconve; Password=facil12.;MultipleActiveResultSets=True";

        public static string getConexion
        { get { return conexion; } }

    }
}
