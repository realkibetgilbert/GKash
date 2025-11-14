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

        
    }
}
