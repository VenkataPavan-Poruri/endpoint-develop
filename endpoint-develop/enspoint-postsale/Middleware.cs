using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using database;
using datalayer.voicecommerce.model.sale;
using endpoint_impl.voicecommerce.stages.sale;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;


namespace enspoint_postsale
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;
        SaleRepo saleRepo;
        SalePostPipelineStage next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            PanRanges panRanges = new PanRanges();
            long input = 12210200000;
            var result = panRanges.findPanRange(input);


            SalePostContext context = null;
            SalePostSetupContext salePostSetupContextMiddleware = new SalePostSetupContext(saleRepo, next);
            salePostSetupContextMiddleware.stageExecute(context);

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}
