using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) 
        { 

        }

        public  DbSet<BOOK> BOOKs { get; set; }
        public  DbSet<CARD> CARDs { get; set; }
        public  DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public  DbSet<ORDER> ORDERs { get; set; }


    }
}
