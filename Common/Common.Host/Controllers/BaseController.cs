using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Common.Domain.Models;
using Common.Host.Models;

namespace Common.Host.Controllers
{
    public class BaseController : Controller
    {
        protected Guid UserId
        {
            get
            {
                var userId = HttpContext
                .User
                .Claims
                .FirstOrDefault(e => e.Type == UserClaimType.USER_ID);

                if (userId != null)
                {
                    return new Guid(userId.Value);
                }
                return Guid.Empty;
            }
        }

        protected string UserName
        {
            get
            {
                //var username = HttpContext
                //.User
                //.Claims
                //.FirstOrDefault(e => e.Type == UserClaimType.USERNAME);

                //if (username != null)
                //{
                //    return username.Value;
                //}
                //return null;
                return "测试人";
            }
        }

        protected WmsLoginUser LoginUser
        {
            get
            {
                //var name = HttpContext
                //.User
                //.Claims
                //.FirstOrDefault(e => e.Type == UserClaimType.USER_NICKNAME);

                //var role = HttpContext
                //.User
                //.Claims
                //.FirstOrDefault(e => e.Type == UserClaimType.ROLE);

                //return new WmsLoginUser()
                //{
                //    Id = UserId,
                //    Name = name.Value,
                //    IsDefault = role.Value.Equals(UserRoleType.RULER)
                //};
                return new WmsLoginUser()
                {
                    Id = Guid.NewGuid(),
                    Name = "测试神",
                    UserName = "测试人",
                    IsDefault = true
                };
            }
        }

        protected Guid TenantId
        {
            //get
            //{
            //    var tenantId = HttpContext
            //    .User
            //    .Claims
            //    .FirstOrDefault(e => e.Type == UserClaimType.TENANT_ID);

            //    if (tenantId != null)
            //    {
            //        return new Guid(tenantId.Value);
            //    }
            //    return Guid.Empty;
            //}
            get { return Guid.NewGuid(); }
        }
    }
}