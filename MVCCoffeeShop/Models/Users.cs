using System;
using System.Collections.Generic;

namespace MVCCoffeeShop.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
    }
}
