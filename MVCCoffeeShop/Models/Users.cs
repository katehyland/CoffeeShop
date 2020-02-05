using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCCoffeeShop.Models
{
    public partial class Users
    {
        public Users()
        {
            UserItems = new HashSet<UserItems>();
        }

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is required.")]
        [Compare("Passsword", ErrorMessage = "Must match password.")]
        public string ConfirmPassword { get; set; }

        public int Phone { get; set; }
        public int? Funds { get; set; }

        public ICollection<UserItems> UserItems { get; set; }
    }
}
