using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Web.Middlewares.TimeCheck
{
    public class TimeCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public TimeCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private bool AplicacaoDisponivelParaTransacoes => DateTime.Now.Hour <= 21;

        public async Task Invoke(HttpContext context)
        {
            if (AplicacaoDisponivelParaTransacoes)
                await _next(context);
            else
            {
                context.Response.StatusCode = 403;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("Você só pode realizar trasações até às 21:59:59");
            }
        }
    }
}