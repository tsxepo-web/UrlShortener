using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Infrastructure.Models;

namespace UrlShortener.Infrastructure
{
    public interface IUrlMappingRepository
    {
        Task<UrlMapping> FindByLongUrlAsync(UrlDto url);
        Task<UrlMapping> FindByShortUrlAsync(string path);
        Task InsertAsync(UrlMapping urlMapping);
    }
}