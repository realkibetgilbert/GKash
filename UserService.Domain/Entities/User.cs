using System;
using System.Collections.Generic;
using System.Text;

namespace UserService.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public DateTime? LastLogin { get; set; }

        public User(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ArgumentException("Phone number is required.", nameof(phoneNumber));

            PhoneNumber = phoneNumber;
            DateCreated = DateTime.UtcNow;
        }
        public void UpdateLastLogin()
        {
            LastLogin = DateTime.UtcNow;
        }

    }
}
