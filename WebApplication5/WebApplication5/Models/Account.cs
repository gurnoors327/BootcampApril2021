using System;
using System.Collections.Generic;

namespace WebApplication5.Models
{
    public partial class Account
    {
        public Account()
        {
            Users = new HashSet<Users>();
        }

        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string City { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
