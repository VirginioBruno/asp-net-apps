using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Results
{
    public class EntradaResult
    {
        public int Id { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        public string Valor { get; set; }
        public string Data { get; set; }

    }
}
