using ApiNova.Models;
using ApiNova.Pagination;
using ApiNova.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiNova.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public ProdutosController(IUnitOfWork uof) => _uof = uof;

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get([FromQuery] ProdutosParameters produtosParameters)
        {
             var prod = _uof.ProdutoRepository.GetProdutos(produtosParameters);

            var metadata = new
            {
                prod.TotalCount,
                prod.PageSize,
                prod.CurrentPage,
                prod.TotalPages,
                prod.HaxNext,
                prod.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            if(prod.Count == 0)
            {
                return _uof.ProdutoRepository.Get().ToList();
            }
            return prod;
        }
        [HttpGet("menorpreco")]
        public ActionResult<IEnumerable<Produto>> GetProdutosPreco()
        {
            return _uof.ProdutoRepository.GetProdutosPreco().ToList();
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var prod = _uof.ProdutoRepository.GetById(p => p.ProdutoId == id);
            return prod is null ? NotFound("Produto não encontrado...") : Ok(prod);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null) {
                return BadRequest("Produto não inserido");
            }
            _uof.ProdutoRepository.Add(produto);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);         
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId){
                return BadRequest();
            }
            _uof.ProdutoRepository.Update(produto);
            _uof.Commit();
            return Ok();

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var produto = _uof.ProdutoRepository.GetById(p => p.ProdutoId == id);
            if(produto is null)
            {
                return NotFound("Produto não encontrado...");
            }
            _uof.ProdutoRepository.Delete(produto);
            _uof.Commit();
            return Ok(produto);

        }
    }
}
