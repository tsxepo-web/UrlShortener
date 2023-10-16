using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Infrastructure;

namespace UrlShortener.Api.Middleware
{
    public class UrlShortenerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IUrlMappingRepository _repository;

        public UrlShortenerMiddleware(RequestDelegate next, IUrlMappingRepository repository)
        {
            _next = next;
            _repository = repository;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.ToUriComponent().Trim('/').ToLower();
            var urlMatch = await _repository.FindByShortUrlAsync(path);

            if (urlMatch != null)
            {
                context.Response.Redirect(urlMatch.Url, permanent: true);
            }
            else
            {
                await _next(context);
            }
        }
    }
}