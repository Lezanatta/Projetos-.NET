using ApiNova.Models;
using ApiNova.Pagination;

namespace ApiNova.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParameters);
        IEnumerable<Categoria> GetCategoriaProdutos();
    }
}
