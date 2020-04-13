using CasaDoCodigo.Models;
using CasaDoCodigo.ResponseModels;
using CasaDoCodigo.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IPedidoRepository
    {
        int? GetPedidoId();
        void SetPedidoId(int pedidoId);
        Pedido GetPedido();
        void AddItem(string codigo);
        UpdateQuantidadeResponse UpdateQuantidade(ItemPedido item);
        Pedido UpdateCadastro(Cadastro cadastro);
    }

    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IItemPedidoRepository itemPedidoRepository;
        private readonly ICadastroRepository cadastroRepository;
        public PedidoRepository(ApplicationContext context, IHttpContextAccessor contextAccessor, IItemPedidoRepository itemPedidoRepository, ICadastroRepository cadastroRepository) : base(context)
        {
            this.contextAccessor = contextAccessor;
            this.itemPedidoRepository = itemPedidoRepository;
            this.cadastroRepository = cadastroRepository;
        }

        public void AddItem(string codigo)
        {
            var produto = context.Set<Produto>().Where(p => p.Codigo == codigo).SingleOrDefault();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = GetPedido();
            var itemPedido = context.Set<ItemPedido>()
                .Where(x => x.Produto.Codigo == codigo && x.Pedido.Id == pedido.Id)
                .SingleOrDefault();

            if (itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                context.Set<ItemPedido>().Add(itemPedido);
                context.SaveChanges();
            }
        }

        public Pedido GetPedido()
        {
            var pedidoId = GetPedidoId();
            var pedido = dbSet
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .Include(p => p.Cadastro)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefault();

            if(pedido == null)
            {
                pedido = new Pedido();
                dbSet.Add(pedido);
                context.SaveChanges();

                SetPedidoId(pedido.Id);
            }

            return pedido;
        }

        public int? GetPedidoId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        public void SetPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }

        public Pedido UpdateCadastro(Cadastro cadastro)
        {
            var pedido = GetPedido();
            cadastroRepository.Update(pedido.Cadastro.Id, cadastro);
            return pedido;
        }

        public UpdateQuantidadeResponse UpdateQuantidade(ItemPedido item)
        {
            var itemPedidoDB = itemPedidoRepository.GetItemPedido(item.Id);

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(item.Quantidade);

                if (item.Quantidade == 0)
                {
                    itemPedidoRepository.RemoveItemPedido(item.Id);
                }

                context.SaveChanges();
            }

            var carrinhoViewModel = new CarrinhoViewModel(GetPedido().Itens);
            var response = new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);

            return response;
        }
    }
}
