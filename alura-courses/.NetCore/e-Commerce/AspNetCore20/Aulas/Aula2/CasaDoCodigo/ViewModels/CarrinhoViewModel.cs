using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.ViewModels
{
    public class CarrinhoViewModel
    {
        public List<ItemPedido> Itens { get; }
        public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);

        public CarrinhoViewModel(List<ItemPedido> itens)
        {
            Itens = itens;
        }
    }
}
