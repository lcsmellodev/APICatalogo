using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public CategoriasController(AppDbContext context, ILogger<CategoriasController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            _logger.LogInformation("===========GET api/categorias/produtos===========");
            return _context.Categorias.Include(p => p.Produtos).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.Categorias.ToList();
        }

        //min(1) é uma maneira de restringir  os valores aceitos como parâmetro (aceita no mínimo 1)
        [HttpGet("{id:int:min(1)}", Name ="ObterCategoria")]
        public ActionResult<Categoria> Get(int id) 
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

            if(categoria == null)
            {
                return NotFound("Categoria não encontrada ...");
            }

            return categoria;

        }

        [HttpPost("{id:int}")]
        public ActionResult Post(Categoria categoria)
        {
            if (categoria is null)
            {
                return BadRequest();
            }

            _context.Categorias.Add(categoria);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
            
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            if(id != categoria.CategoriaId)
            {
                return BadRequest();
            }
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(categoria);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if (categoria is null)
            {
                return NotFound("Categoria não encontrada");
            }

            _context.Remove(categoria);
            _context.SaveChanges();
            return Ok(categoria);



        }




    }
}
