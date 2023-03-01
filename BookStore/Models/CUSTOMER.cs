

namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CUSTOMER
    {
        
        public int CustomerId { get; set; }
        public string Customer_Email { get; set; }
        public string Customer_Password { get; set; }
        public int Card_No { get; set; }

    }
}
