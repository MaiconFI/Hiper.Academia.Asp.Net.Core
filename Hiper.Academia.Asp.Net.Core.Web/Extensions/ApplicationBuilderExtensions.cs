using Hiper.Academia.Asp.Net.Core.Web.Middlewares.TimeCheck;
using Microsoft.AspNetCore.Builder;

namespace Hiper.Academia.Asp.Net.Core.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseTimeCheck(this IApplicationBuilder builder)
            => builder.UseMiddleware<TimeCheckMiddleware>();
    }
}
