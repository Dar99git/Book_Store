

namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;

    public partial class BOOK
    {
        public int BookId { get; set; }
        public string Book_Name { get; set; }
        public string Book_Price { get; set; }
        public string Book_Type { get; set; }
        public int Customer_Id { get; set; }
    }
}
