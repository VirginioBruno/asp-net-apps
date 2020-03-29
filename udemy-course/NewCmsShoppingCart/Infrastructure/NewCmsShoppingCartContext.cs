using Microsoft.EntityFrameworkCore;
using NewCmsShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewCmsShoppingCart.Infrastructure
{
    public class NewCmsShoppingCartContext : DbContext
    {
        public NewCmsShoppingCartContext(DbContextOptions<NewCmsShoppingCartContext> options) : base(options) { }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
