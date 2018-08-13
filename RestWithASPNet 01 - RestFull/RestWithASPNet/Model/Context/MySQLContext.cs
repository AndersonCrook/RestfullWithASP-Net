using Microsoft.EntityFrameworkCore;

namespace RestWithASPNet.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }

        public MySQLContext(DbContextOptions<MySQLContext> options): base(options) { }

        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
