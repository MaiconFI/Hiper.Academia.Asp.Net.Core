using Hiper.Academia.AspNetCore.Web.Middlewares.TimeCheck;
using Microsoft.AspNetCore.Builder;

namespace Hiper.Academia.AspNetCore.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseTimeCheck(this IApplicationBuilder builder)
            => builder.UseMiddleware<TimeCheckMiddleware>();
    }
}