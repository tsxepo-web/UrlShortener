using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Infrastructure.Models;

namespace UrlShortener.Application
{
    public interface IUrlShortenerService
    {
        Task<string> ShortenUrlAsync(UrlDto url);
    }
}