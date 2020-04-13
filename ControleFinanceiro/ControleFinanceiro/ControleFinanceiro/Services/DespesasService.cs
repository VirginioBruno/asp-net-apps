using ControleFinanceiro.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro
{
    public class DespesasService
    {
        public List<Despesa> Listar()
        {
            var despesas = new List<Despesa>();

            using (var context = new ApplicationContext())
            {
                despesas = context.TB_CF_DESPESAS.ToList();
            }

            return despesas;
        }

        public List<Despesa> ListarAtual()
        {
            var despesas = new List<Despesa>();

            using (var context = new ApplicationContext())
            {
                despesas = context.TB_CF_DESPESAS.Where(d => d.Data.Month >= DateTime.Now.Month && d.Data.Month < DateTime.Now.Month + 1).ToList();
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
