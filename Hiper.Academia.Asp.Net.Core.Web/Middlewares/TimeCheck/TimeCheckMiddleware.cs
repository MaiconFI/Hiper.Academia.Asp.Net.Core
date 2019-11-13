using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Hiper.Academia.Asp.Net.Core.Web.Middlewares.TimeCheck
{
    public class TimeCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public TimeCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

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

        private bool AplicacaoDisponivelParaTransacoes => DateTime.Now.Hour > 21;
    }
}
