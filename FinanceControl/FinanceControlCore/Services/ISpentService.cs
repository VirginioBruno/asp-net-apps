using FinanceControl.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceControl.Services
{
    public interface ISpentService
    {
        Task<List<Spent>> GetSpents();
    }
}