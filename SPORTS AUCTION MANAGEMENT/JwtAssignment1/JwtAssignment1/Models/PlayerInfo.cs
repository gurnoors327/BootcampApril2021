using System;
using System.Collections.Generic;

namespace JwtAssignment1.Models
{
    public partial class PlayerInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Nationality { get; set; }
        public string Pteam { get; set; }
        public int Age { get; set; }
        public int Price { get; set; }
    }
}
