using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using Common.Host.Models;

namespace Common.Host.Providers
{
    /// <summary>
    /// 登录租户信息
    /// </summary>
    public class TenantProvider : ITenantProvider
    {
        private IHttpContextAccessor _context;

        public TenantProvider(IHttpContextAccessor context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取租户id
        /// </summary>
        /// <returns>租户id</returns>
        public Guid GetTenantId()
        {
            var tenantId = _context.HttpContext.User.Claims.FirstOrDefault(e => e.Type == UserClaimType.TENANT_ID);
            if (tenantId != null)
            {
                return new Guid(tenantId.Value);
            }
            else
            {
                return Guid.Empty; ;
            }
        }
    }
}
