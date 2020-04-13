using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using CasaDoCodigo.ResponseModels;
using CasaDoCodigo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
        }

        public IActionResult Carrossel()
        {
            return View(produtoRepository.GetProdutos());
        }

        public IActionResult Carrinho(string codigo)
        {
            if(!string.IsNullOrEmpty(codigo))
            {
                pedidoRepository.AddItem(codigo);
            }

            var itens = pedidoRepository.GetPedido().Itens;
            var carrinhoViewModel = new CarrinhoViewModel(itens);

            return View(carrinhoViewModel);
        }

        public IActionResult Cadastro()
        {
            var pedido = pedidoRepository.GetPedido();

            if(pedido == null)
            {
                return RedirectToAction("Carrossel");
            }

            return View(pedido.Cadastro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Resumo(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                return View(pedidoRepository.UpdateCadastro(cadastro));
            }

            return RedirectToAction("Cadastro");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public UpdateQuantidadeResponse UpdateQuantidade([FromBody]ItemPedido item)
        {
            return pedidoRepository.UpdateQuantidade(item);
        }
    }
}
