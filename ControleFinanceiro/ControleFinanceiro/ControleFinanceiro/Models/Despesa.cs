using System;

namespace ControleFinanceiro
{
    public class Despesa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Categoria { get; set; }
        public int TipoId { get; set; }
        public DateTime Data { get; set; }
    }
}
