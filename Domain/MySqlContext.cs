using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options)
            : base(options)
        {

        }

        public DbSet<Visitor> User { get; set; }

        public DbSet<Player> Player { get; set; }

        public DbSet<Game> Game { get; set; }

        public DbSet<Result> Result { get; set; }

        public DbSet<Tournament> Tournament { get; set; }

        public DbSet<Vote> Vote { get; set; }

        public DbSet<Transfer> Transfer { get; set; }

        public DbSet<Title> Title { get; set; }

        public DbSet<Federation> Federation { get; set; }

        public DbSet<Piece> Piece { get; set; }

        public DbSet<Organizer> Organizer { get; set; }

        public DbSet<Move> Move { get; set; }

        public DbSet<Country> Country { get; set; }
    }
}
