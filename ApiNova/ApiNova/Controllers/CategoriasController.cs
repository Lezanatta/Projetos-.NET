using ApiNova.Context;
using ApiNova.Models;
using ApiNova.Pagination;
using ApiNova.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace ApiNova.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        public CategoriasController(IUnitOfWork uof) => _uof = uof;

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriaProdutos() 
            => _uof.CategoriaRepository.Get().AsNoTracking().Take(10).Include(p => p.Produtos).ToList();

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get([FromQuery] CategoriasParameters categoriasParameters)
        {
            var categorias = _uof.CategoriaRepository.GetCategorias(categoriasParameters);
            var metadata = new
            {
                categorias.TotalCount,
                categorias.PageSize,
                categorias.CurrentPage,
                categorias.TotalPages,
                categorias.HaxNext,
                categorias.HasPrevious

            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return categorias is null ? NotFound("Não contém categorias...") : categorias;
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _uof.CategoriaRepository.Get().AsNoTracking().Take(10).FirstOrDefault(c => c.CategoriaId == id);
            return categoria is null ? NotFound("Categoria não encontrada") : categoria;
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            if(categoria is null)
            {
                return BadRequest("Categoria não informada...");
            }
            _uof.CategoriaRepository.Add(categoria);
            _uof.Commit();
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId, categoria });
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var categoria = _uof.CategoriaRepository.Get().FirstOrDefault(c => c.CategoriaId == id);
            if(categoria is null)
            {
                return NotFound("Categoria não encontrada...");
            }
            _uof.CategoriaRepository.Delete(categoria);
            _uof.Commit();
            return Ok(categoria);
        }
    }
}
