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

        public DbSet<Visitor> Users { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Result> Results { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<Transfer> Transfers { get; set; }

        public DbSet<Title> Titles { get; set; }

        public DbSet<Federation> Federations { get; set; }

        public DbSet<Piece> Pieces { get; set; }

        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<Move> Moves { get; set; }

        public DbSet<Chessboard> Chessboards { get; set; }

        public DbSet<Country> Countries { get; set; }
    }
}
