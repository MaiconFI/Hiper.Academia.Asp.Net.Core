using Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias.Depositos;
using Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias.Saques;
using Microsoft.Extensions.DependencyInjection;

namespace Hiper.Academia.AspNetCore.Services.IoC
{
    public class IoCServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IDepositoServices, DepositoServices>();
            services.AddScoped<ISaqueServices, SaqueServices>();
        }
    }
}