using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class TipoDespesa
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static List<TipoDespesa> tipos { get; set; } = new List<TipoDespesa>()
        {
            new TipoDespesa { Id = 1, Nome = "Fixo" },
            new TipoDespesa { Id = 2, Nome = "Parcelado" },
            new TipoDespesa { Id = 3, Nome = "Outros" }
        };
    }
}
