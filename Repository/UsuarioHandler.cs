using MiPrimeraApi2.Model;
using System.Data.SqlClient;

namespace MiPrimeraApi2.Repository
{
    public class UsuarioHandler
    {
        public const string ConnectionString = "Server = DESKTOP-II66TRU; Database = SistemaGestion; Trusted_connection=true";
        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> Resultado = new List<Usuario>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Usuario", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader sqlreader = sqlCommand.ExecuteReader())
                    {
                        if (sqlreader.HasRows)
                        {
                            while (sqlreader.Read())
                            {
                                Usuario Usuario = new Usuario();

                                Usuario.Id = Convert.ToInt32(sqlreader["Id"]);
                                Usuario.Nombre = sqlreader["Nombre"].ToString();
                                Usuario.Apellido = sqlreader["Apellido"].ToString();
                                Usuario.NombreUsuario = sqlreader["NombreUsuario"].ToString();
                                Usuario.Contraseña = sqlreader["Contraseña"].ToString();
                                Usuario.Mail = sqlreader["Mail"].ToString();

                                Resultado.Add(Usuario);
                            }
                        }
                    }
                }
            }
            return Resultado;
        }

        public static Usuario UsuarioConContraseña(string user,string pass)
        {
            String sqlQuery = $"SELECT * FROM Usuario WHERE NombreUsuario = '{user}' AND Contraseña = '{pass}'";

            Usuario Resultado = new Usuario();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader sqlreader = sqlCommand.ExecuteReader())
                    {
                        if (sqlreader.HasRows)
                        {
                            while (sqlreader.Read())
                            {
                                Usuario Usuario = new Usuario();

                                Usuario.Id = Convert.ToInt32(sqlreader["Id"]);
                                Usuario.Nombre = sqlreader["Nombre"].ToString();
                                Usuario.Apellido = sqlreader["Apellido"].ToString();
                                Usuario.NombreUsuario = sqlreader["NombreUsuario"].ToString();
                                Usuario.Contraseña = sqlreader["Contraseña"].ToString();
                                Usuario.Mail = sqlreader["Mail"].ToString();

                            }
                        }
                    }
                }
            }
            return Resultado;
        }
    }
}
