using FinanceControl.Infrastructure;
using FinanceControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceControl.Services
{
    public class SpentService : ISpentService
    {
        private readonly FinanceControlContext _context;
        public SpentService(FinanceControlContext context)
        {
            _context = context;
        }

        public async Task<List<Spent>> GetSpents()
        {
            if (_context.SpentCategoryItems.Count() == 0)
            {
                List<SpentCategory> categories = new List<SpentCategory>
                {
                    new SpentCategory("Diversão"),
                    new SpentCategory("Estudo"),
                    new SpentCategory("Essencial")
                };

                categories.ForEach(c => _context.SpentCategoryItems.Add(c));
                await _context.SaveChangesAsync();
            }

            if (_context.SpentItems.Count() == 0)
            {
                var spents = new List<Spent>()
                {
                    new Spent("Netflix", 40.00, _context.SpentCategoryItems.First(x => x.Name == "Diversão"), DateTime.Now),
                    new Spent("Cursos", 70.00, _context.SpentCategoryItems.First(x => x.Name == "Estudo"), DateTime.Now),
                    new Spent("Mercado", 400.00, _context.SpentCategoryItems.First(x => x.Name == "Essencial"), DateTime.Now),
                    new Spent("Seguro", 250.00, _context.SpentCategoryItems.First(x => x.Name == "Essencial"), DateTime.Now),
                    new Spent("Aluguel", 500.00, _context.SpentCategoryItems.First(x => x.Name == "Essencial"), DateTime.Now),
                    new Spent("Contas", 200, _context.SpentCategoryItems.First(x => x.Name == "Essencial"), DateTime.Now),
                };

                spents.ForEach(spent => _context.SpentItems.Add(spent));
            }

            await _context.SaveChangesAsync();

            return _context.SpentItems.ToList();
        }
    }
}
