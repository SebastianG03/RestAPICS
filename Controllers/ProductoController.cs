using CRUDMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private  readonly ApplicationDBContext _db;

        public ProductoController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Producto> productos = await _db.Producto.ToListAsync();
            return Ok(productos);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{IdProducto}")]
        public async Task<IActionResult> Get(int IdProducto)
        {
            Producto producto = await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto == IdProducto);
            if (producto == null)
            {
                return BadRequest();
            }
            return Ok(producto);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Producto producto)
        {
            Producto producto2 = await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto == producto.IdProducto);
            if (producto != null && producto2 == null)
            {
                await _db.Producto.AddAsync(producto);
                await _db.SaveChangesAsync();
                return Ok(producto);
            }
            return BadRequest("");
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{IdProducto}")]
        public async Task<IActionResult> Delete(int IdProducto)
        {
            Producto producto = await _db.Producto.FirstOrDefaultAsync(x => x.IdProducto == IdProducto);
            if (producto != null)
            {
                _db.Producto.Remove(producto); 
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}
