using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi2.Model;
using MiPrimeraApi2.Repository;

namespace MiPrimeraApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoVentaController : ControllerBase
    {
        [HttpGet]
        public List<ProductoVendido> GetProductoVendido()
        {
            return new List<ProductoVendido>();
        }

        [HttpPost]
        public void Crear([FromBody] List<ProductoVendido> lista, int i)
        {
            VentaHandler.nuevaVentaDeProductos(lista, i);
        }

        [HttpPut]
        public void Actualizar()
        {
            
        }

        [HttpDelete]
        public void EliminarUsuario()
        {

        }
    }
}
