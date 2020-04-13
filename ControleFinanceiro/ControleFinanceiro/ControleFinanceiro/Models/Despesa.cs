using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
