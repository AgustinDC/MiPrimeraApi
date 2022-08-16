using MiPrimeraApi2.Model;
using System.Data.SqlClient;

namespace MiPrimeraApi2.Repository
{
    public class VentaHandler
    {
        public const string ConnectionString = "Server = DESKTOP-II66TRU; Database = SistemaGestion; Trusted_connection=true";
        public static List<Venta> GetVentas()
        {
            List<Venta> Ventas = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Venta", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader sqlreader = sqlCommand.ExecuteReader())
                    {
                        if (sqlreader.HasRows)
                        {
                            while (sqlreader.Read())
                            {
                                Venta ObjVenta = new Venta();

                                ObjVenta.Id = Convert.ToInt32(sqlreader["Id"]);
                                ObjVenta.Comentarios = sqlreader["Comentarios"].ToString();

                                Ventas.Add(ObjVenta);
                            }
                        }
                    }
                }
            }

            return Ventas;
        }
    }
}
