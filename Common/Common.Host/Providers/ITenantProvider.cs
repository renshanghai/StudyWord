using System;

namespace Common.Host.Providers
{
    /// <summary>
    /// 登录租户信息
    /// </summary>
    public interface ITenantProvider
    {
        /// <summary>
        /// 获取租户id
        /// </summary>
        /// <returns>租户id</returns>
        Guid GetTenantId();
    }
}
