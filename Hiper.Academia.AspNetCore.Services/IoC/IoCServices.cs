using Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias;
using Microsoft.Extensions.DependencyInjection;

namespace Hiper.Academia.AspNetCore.Services.IoC
{
    public class IoCServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IMovimentacaoBancariaServices, MovimentacaoBancariaServices>();
        }
    }
}