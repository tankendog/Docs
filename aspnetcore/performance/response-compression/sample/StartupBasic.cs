using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace ResponseCompressionSample
{
    public class StartupBasic
    {
        #region snippet1
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseResponseCompression();

            app.Run(async context =>
            {
                // If the Accept-Encoding header is present, always add the Vary header
                // This will be added as a feature in the next release of the middleware.
                // https://github.com/aspnet/BasicMiddleware/issues/187
                var accept = context.Request.Headers[HeaderNames.AcceptEncoding];
                if (!StringValues.IsNullOrEmpty(accept))
                {
                    context.Response.Headers.Append(HeaderNames.Vary, HeaderNames.AcceptEncoding);
                }
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(LoremIpsum.Text);
            });
        }
        #endregion
    }
}
