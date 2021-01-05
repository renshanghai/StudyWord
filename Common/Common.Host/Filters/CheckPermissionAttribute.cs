using Microsoft.AspNetCore.Authorization;
using System;

namespace Common.Host
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CheckPermissionAttribute : AuthorizeAttribute
    {
        public string Permission { get; set; }

        public CheckPermissionAttribute()
        {

        }
    }
}