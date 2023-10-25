using ApiNova.Models;
using ApiNova.Pagination;

namespace ApiNova.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
       PagedList<Produto> GetProdutos(ProdutosParameters produtos);
       IEnumerable<Produto> GetProdutosPreco();
    }
}
