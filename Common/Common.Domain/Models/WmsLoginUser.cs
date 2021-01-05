using System;

namespace Common.Domain.Models
{
    public class WmsLoginUser
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public bool IsDefault { get; set; }
    }
}
