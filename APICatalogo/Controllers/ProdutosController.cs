
using Microsoft.AspNetCore.Mvc;
using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            List<Produto> produtos = _context.Produtos.ToList();
            if (produtos is null)
            {
                return NotFound("Produtos não encontrados");
            }
            return produtos;

        }
        //[Route("id")]
        //[HttpGet()] 
        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            Produto produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
                if(produto is null)
                {
                    return NotFound("Produto não encontrado");
                }
                return produto;
            
        }
        [HttpPost]
        public ActionResult Post(Produto produto) 
        {
            if(produto is null)
            {
                return BadRequest();
            }
            _context.Produtos.Add(produto);// adiciona produto ao contexto
            _context.SaveChanges(); // persiste mudança no banco de dados

            //
            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto); // retorna codigo de status http 2001 em caso de êxito
            //adiciona
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            /*Nessa abordagem, é necessário passar o produto completo para que o POST funcione. Para passar
            os dados parciais é necessário usar o método PATCH ou utilizar uma abordagem diferente aqui no método*/
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            Produto produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if(produto is null)
            {
                return NotFound("Produto não localizado...");
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto); //se não passar nada como parâmetro, só retornará o StatusCode

        }
        
    }
}
