using System;
using System.Collections.Generic;

namespace WebApplication5.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? AccountId { get; set; }

        public Account Account { get; set; }
    }
}
