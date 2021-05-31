using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Suatra.Domain.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            CourseAuthors = new HashSet<CourseAuthor>();
        }
        public string FirstName { get; set; }

        public string OtherName { get; set; }

        public string LastName { get; set; }

        public string Bio { get; set; }

        public string PhotoUri { get; set; }

        public DateTime? PasswordResetTokenExpiry { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiry { get; set; }

        public virtual ICollection<CourseAuthor> CourseAuthors { get; set; }

    }
}
