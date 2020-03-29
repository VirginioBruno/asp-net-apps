using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewCmsShoppingCart.Infrastructure;
using NewCmsShoppingCart.Models;

namespace NewCmsShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly NewCmsShoppingCartContext context;

        public CategoriesController(NewCmsShoppingCartContext context)
        {
            this.context = context;
        }

        //GET /admin/categories
        public async Task<IActionResult> Index()
        {
            return View(await context.Categories.OrderBy(x => x.Sorting).ToListAsync());
        }

        //GET /admin/categories/create
        public IActionResult Create() => View();

        //POST /admin/categories/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.Slug = category.Name.ToLower().Replace(' ', '-');
                category.Sorting = 100;

                var slug = await context.Categories.FirstOrDefaultAsync(x => x.Slug == category.Slug);

                if (slug != null)
                {
                    ModelState.AddModelError("", "The category already exists.");
                    return View(category);
                }

                TempData["Success"] = "The category has been added!";

                context.Add(category);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(category);
        }
    }
}