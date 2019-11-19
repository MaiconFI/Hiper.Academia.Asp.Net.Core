using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Web.Middlewares.TimeCheck
{
    public class TimeCheckMiddleware
    {
        private readonly int _hourLimit = 23;
        private readonly RequestDelegate _next;

        public TimeCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (AplicacaoDisponivelParaTransacoes())
                await _next(context);
            else
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync($"Você só pode realizar trasações até às {_hourLimit}:59:59");
            }
        }

        private bool AplicacaoDisponivelParaTransacoes() => DateTime.Now.Hour <= _hourLimit;
    }
}