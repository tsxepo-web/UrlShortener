using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application;
using UrlShortener.Infrastructure.Models;

namespace UrlShortener.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IUrlShortenerService _urlShortener;
        private readonly IHttpContextAccessor _contextAccessor;
        public UrlShortenerController(IUrlShortenerService urlShortener, IHttpContextAccessor contextAccessor)
        {
            _urlShortener = urlShortener;
            _contextAccessor = contextAccessor;
        }

        [HttpPost("shortUrl")]
        public async Task<IActionResult> ShortenUrl([FromBody] UrlDto url)
        {
            if (url == null)
            {
                return BadRequest("Invalid input");
            }
            string shortUrl = await _urlShortener.ShortenUrlAsync(url);
            string baseUrl = $"{_contextAccessor.HttpContext!.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}";
            string res = $"{baseUrl}/{shortUrl}";
            var response = new UrlShortResponseDto { Url = res };
            return Ok(response);
        }
    }
}