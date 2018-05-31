using Microsoft.EntityFrameworkCore;

namespace dbCore.Models{
   
        
       public class From_Context : DbContext
        {
        public DbSet<Book> tb_data { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\sqlexpress;Database=from_db;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        

    }

}