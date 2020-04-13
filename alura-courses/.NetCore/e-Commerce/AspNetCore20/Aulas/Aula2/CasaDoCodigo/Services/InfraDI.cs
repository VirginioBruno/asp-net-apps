using CasaDoCodigo.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CasaDoCodigo.Services
{
    public static class InfraDI
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IDataService, DataService>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
            services.AddTransient<ICadastroRepository, CadastroRepository>();
        }
    }
}
