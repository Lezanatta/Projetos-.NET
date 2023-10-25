using ApiNova.Context;
using ApiNova.Models;
using ApiNova.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ApiNova.Repository
{
    public class ProdutosRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutosRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public PagedList<Produto> GetProdutos(ProdutosParameters produtosParameters)
            => PagedList<Produto>.ToPagedList(Get().OrderBy(p => p.Nome),
                produtosParameters.PageNumber, produtosParameters.PageSize);
        public IEnumerable<Produto> GetProdutosPreco()
        {
            return Get().OrderBy(p => p.Preco).ToList();
        }
    }
}
