using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleFinanceiro
{
    [Table("TB_CF_DESPESAS")]
    public class Despesa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Despesa")]
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Categoria { get; set; }
        [DisplayName("Tipo")]
        public int TipoId { get; set; }
        public DateTime Data { get; set; }
    }
}
