﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace LogInline
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Handling request. <p>");
                await next.Invoke();
                await context.Response.WriteAsync("Finished handling request.");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from 2nd delegate. <p>");
            });
        }
    }
}