using Microsoft.AspNetCore.Mvc;
using MiPrimeraApi2.Model;
using MiPrimeraApi2.Repository;
using MiPrimeraApi2.Controllers.DTO;

namespace MiPrimeraApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public List<Producto> GetProductos()
        {
            return new List<Producto>();
        }

        [HttpPut]
        public void Actualizar([FromBody] PutProducto producto)
        {
            ProductoHandler.Actualizar(new Producto 
            { 
                Id = producto.Id,
                Costo = producto.Costo,
                Descripciones = producto.Descripciones,
                Stock = producto.Stock,
                IdUsuario = producto.IdUsuario
            });
        }

        [HttpPost]
        public void Crear()
        {
            
        }

        [HttpDelete]
        public void Eliminar([FromBody] int Id)
        {
            ProductoHandler.Borrar(Id);
        }
    }
}