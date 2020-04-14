using ControleFinanceiro.Context;
using ControleFinanceiro.Models;
using ControleFinanceiro.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro
{
    public class DespesasService
    {
        public List<DespesaResult> Listar(DateTime? dataInicio, DateTime? dataFim)
        {
            var despesas = new List<DespesaResult>();

            using (var context = new ApplicationContext())
            {
                var despesasDB = context.TB_CF_DESPESAS
                    .Where(d => d.Data >= dataInicio && d.Data <= dataFim)
                    .ToList();

                foreach (var despesa in despesasDB)
                {
                    var result = new DespesaResult()
                    {
                        Despesa = despesa.Nome,
                        Tipo = TipoDespesa.tipos.FirstOrDefault(t => t.Id == despesa.TipoId).Nome,
                        Categoria = despesa.Categoria,
                        Data = despesa.Data.ToString("dd/MM/yyyy"),
                        Valor = despesa.Valor.ToString("c")
                    };

                    despesas.Add(result);
                }
            }

            return despesas;
        }

        public void Adicionar(Despesa despesa)
        {
            using (var context = new ApplicationContext())
            {
                context.TB_CF_DESPESAS.Add(despesa);
                context.SaveChanges();
            }
        }

        public void Atualizar(Despesa despesa)
        {
            using (var context = new ApplicationContext())
            {
                context.TB_CF_DESPESAS.Update(despesa);
                context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using (var context = new ApplicationContext())
            {
                var despesa = context.TB_CF_DESPESAS.Where(d => d.Id == id).SingleOrDefault();
                context.TB_CF_DESPESAS.Remove(despesa);
                context.SaveChanges();
            }
        }
    }
}
