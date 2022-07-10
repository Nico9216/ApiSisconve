namespace Sisconve.Persistencia
{
    internal class Conexion

    {
        
        //private static string conexion = "Data Source=SERVERBD; Initial Catalog = Sisconve; User Id = sisconve; Password=facil12.;MultipleActiveResultSets=True";
        private static string conexion= "Server=;Database=Sisconve;Trusted_Connection=True;";
        public static string getConexion
        { get { return conexion; } }

    }
}
