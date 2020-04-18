using ControleFinanceiro.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Context
{
    public class ApplicationContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB_CF;Integrated Security=True");
        }

        public DbSet<Despesa> TB_CF_DESPESAS { get; set; }
        public DbSet<Entrada> TB_CF_ENTRADAS { get; set; }
    }
}
