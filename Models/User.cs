using System;
using System.Collections.Generic;

namespace ProductsDb.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
    }
}
