using ControleFinanceiro.Context;
using ControleFinanceiro.Models;
using ControleFinanceiro.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Services
{
    public class EntradasService
    {
        public List<EntradaResult> Listar(DateTime? dataInicio, DateTime? dataFim)
        {
            var entradas = new List<EntradaResult>();

            using (var context = new ApplicationContext())
            {
                var entradasDB = context.TB_CF_ENTRADAS
                    .Where(d => d.Data >= dataInicio && d.Data <= dataFim)
                    .ToList();

                foreach (var item in entradasDB)
                {
                    var result = new EntradaResult()
                    {
                        Id = item.Id,
                        Descricao = item.Descricao,
                        Valor = item.Valor.ToString("c"),
                        Data = item.Data.ToString("dd/MM/yyyy")
                    };

                    entradas.Add(result);
                }
            }

            return entradas;
        }

        public void Adicionar(Entrada entrada)
        {
            using (var context = new ApplicationContext())
            {
                context.TB_CF_ENTRADAS.Add(entrada);
                context.SaveChanges();
            }
        }

        public void Atualizar(Entrada entrada)
        {
            using (var context = new ApplicationContext())
            {
                context.TB_CF_ENTRADAS.Update(entrada);
                context.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            using (var context = new ApplicationContext())
            {
                var entrada = context.TB_CF_ENTRADAS.Where(d => d.Id == id).SingleOrDefault();
                context.TB_CF_ENTRADAS.Remove(entrada);
                context.SaveChanges();
            }
        }
    }
}
