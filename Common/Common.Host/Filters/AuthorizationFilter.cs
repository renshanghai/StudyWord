using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http;

namespace Common.Host.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        IHttpClientFactory _httpClientFactory;
        public AuthorizationFilter(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
        }
    }
}
