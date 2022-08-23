using MiPrimeraApi2.Model;
using System.Data.SqlClient;

namespace MiPrimeraApi2.Repository
{
    public class ProductoVendidoHandler
    {
        public const string ConnectionString = "Server = DESKTOP-II66TRU; Database = SistemaGestion; Trusted_connection=true";
        public static List<ProductoVendido> GetProductosVendidos()
        {
            List<ProductoVendido> ProductosVendidos = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM ProductoVendido", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader sqlreader = sqlCommand.ExecuteReader())
                    {
                        if (sqlreader.HasRows)
                        {
                            while (sqlreader.Read())
                            {
                                ProductoVendido ProductoV = new ProductoVendido();

                                ProductoV.Id = Convert.ToInt32(sqlreader["Id"]);
                                ProductoV.Stock = Convert.ToInt32(sqlreader["Stock"]);
                                ProductoV.IdProducto = Convert.ToInt32(sqlreader["IdProducto"]);
                                ProductoV.IdVenta = Convert.ToInt32(sqlreader["IdVenta"]);
                                
                                ProductosVendidos.Add(ProductoV);
                            }
                        }
                    }
                }
            }

            return ProductosVendidos;
        }

        internal static void Agregar(int id, int venta, int stock)
        {
            string sqlQuery = "INSERT INTO ProductoVendido (IdProducto, IdVenta, Stock) " + 
                              "VALUES (@IdProducto, @IdVenta, @stock)";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@IdProducto", id);
                sqlCommand.Parameters.AddWithValue("@IdVenta", venta);
                sqlCommand.Parameters.AddWithValue("@Stock", stock);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
