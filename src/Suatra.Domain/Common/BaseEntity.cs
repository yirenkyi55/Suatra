using System;

namespace Suatra.Domain.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public bool IsInActive { get; set; }

    }
}
