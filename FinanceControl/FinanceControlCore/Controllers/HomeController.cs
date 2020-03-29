using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceControl.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceControl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISpentService _spentService;

        public HomeController(ISpentService spentService)
        {
            _spentService = spentService;
        }
        public IActionResult Index()
        {
            var spents = _spentService.GetSpents();

            return View(spents.Result);
        }
    }
}