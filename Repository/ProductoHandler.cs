using MiPrimeraApi2.Model;
using System.Data.SqlClient;

namespace MiPrimeraApi2.Repository
{
    public class ProductoHandler
    {
        public const string ConnectionString = "Server = DESKTOP-II66TRU; Database = SistemaGestion; Trusted_connection=true";
        public static List<Producto> GetProductos()
        {
            List<Producto> Productos = new List<Producto>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Producto", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader sqlreader = sqlCommand.ExecuteReader())
                    {
                        if (sqlreader.HasRows)
                        {
                            while (sqlreader.Read())
                            {
                                Producto Producto = new Producto();

                                Producto.Id = Convert.ToInt32(sqlreader["Id"]);
                                Producto.Descripciones = sqlreader["Descripciones"].ToString();
                                Producto.Costo = Convert.ToDouble(sqlreader["Costo"]);
                                Producto.PrecioVenta = Convert.ToDouble(sqlreader["PrecioVenta"]);
                                Producto.Stock = Convert.ToInt32(sqlreader["Stock"]);
                                Producto.IdUsuario = Convert.ToInt32(sqlreader["IdUsuario"]);

                                Productos.Add(Producto);
                            }
                        }
                    }
                }
            }

            return Productos;
        }

    }
}
