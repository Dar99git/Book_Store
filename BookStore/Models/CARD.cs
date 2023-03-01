

namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CARD
    {
        public int CardID { get; set; }
        public byte[] Card_Exp_Date { get; set; }
        public byte[] Card_Name { get; set; }
        public byte[] Card_Cvc { get; set; }
    }
}
