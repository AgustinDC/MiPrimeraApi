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

        public static void nuevaVentaDeProductos(List<ProductoVendido> lista, int IdUser)
        {
            VentaHandler.AgregarVenta(IdUser);
            foreach (ProductoVendido Venta in lista)
            {
                VentaHandler.DescontarStock(Venta.Id, Venta.Stock);
                ProductoVendidoHandler.Agregar(Venta.IdProducto, Venta.IdVenta, Venta.Stock);
            }
        }

        private static void DescontarStock(int Id,int stock)
        {
            Producto producto = new Producto();
            producto.Id = Id;
            producto.PrecioVenta = 0;
            producto.Stock = stock;
            producto.Costo = 0;
            producto.Descripciones = "";
            producto.IdUsuario = 0;

            ProductoHandler.ActualizarDesdeVenta(producto);
        }

        public static void AgregarVenta(int IdUser)
        {
            string sqlQuery = "INSERT INTO Venta (Comentarios) VALUES (@comentarios + @IdUser)";

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@comentarios", "Se realizo la venta por el Usuario " + IdUser);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
