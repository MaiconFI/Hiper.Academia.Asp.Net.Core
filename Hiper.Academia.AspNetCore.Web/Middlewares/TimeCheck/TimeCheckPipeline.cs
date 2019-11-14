using Microsoft.AspNetCore.Builder;

namespace Hiper.Academia.AspNetCore.Web.Middlewares.TimeCheck
{
    public class TimeCheckPipeline
    {
        public void Configure(IApplicationBuilder app)
            => app.UseMiddleware<TimeCheckMiddleware>();
    }
}