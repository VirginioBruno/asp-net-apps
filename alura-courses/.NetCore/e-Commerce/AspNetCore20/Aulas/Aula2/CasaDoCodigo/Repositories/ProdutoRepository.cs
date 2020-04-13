using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> livros);
        IList<Produto> GetProdutos();
    }

    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) : base(context) { }

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            var produtos = dbSet.ToList();
            
            if(produtos.Count() == 0)
            {
                foreach (var livro in livros)
                {
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }

                context.SaveChanges();
            }
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
