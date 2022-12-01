using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;

namespace Suatra.Domain.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string OtherName { get; set; }

        public string LastName { get; set; }

        public string Bio { get; set; }

        public string PhotoUri { get; set; }

        public DateTimeOffset? PasswordResetTokenExpiry { get; set; }

        public string RefreshToken { get; set; }

        public DateTimeOffset RefreshTokenExpiry { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public bool IsInActive { get; set; }
    }
}