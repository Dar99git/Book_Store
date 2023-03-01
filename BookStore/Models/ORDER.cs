
namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;

    public partial class ORDER
    {
        public int OrderId { get; set; }
        public Nullable<int> Order_Quantity { get; set; }
        public byte[] Order_Payment_Method { get; set; }
        public byte[] Order_Total_Price { get; set; }
        public int Customer_Id { get; set; }
        public int Card_No { get; set; }

    }
}
