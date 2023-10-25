    using ApiNova.Context;
using ApiNova.Models;
using ApiNova.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace ApiNova.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public IEnumerable<Categoria> GetCategoriaProdutos()
        {
            return Get().Include(P => P.Produtos);
        }

        public PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParameters)
        {
            return PagedList<Categoria>.ToPagedList(Get().OrderBy(c => c.Nome),
                categoriasParameters.PageNumber, categoriasParameters.PageSize);
        }
    }
}