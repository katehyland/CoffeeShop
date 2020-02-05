using System;
using System.Collections.Generic;

namespace MVCCoffeeShop.Models
{
    public partial class UserItems
    {
        public int UserItemId { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }

        public Items Item { get; set; }
        public Users User { get; set; }
    }
}
