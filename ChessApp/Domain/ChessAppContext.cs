using ChessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ChessApp.Domain {
	public class ChessAppContext : DbContext {
		public ChessAppContext() { }

		public ChessAppContext(DbContextOptions<ChessAppContext> options)
			: base(options) { }

		public virtual DbSet<Conduct> Conducts { get; set; }
		public virtual DbSet<Country> Countries { get; set; }
		public virtual DbSet<Federation> Federations { get; set; }
		public virtual DbSet<Game> Games { get; set; }
		public virtual DbSet<Move> Moves { get; set; }
		public virtual DbSet<Organizer> Organizers { get; set; }
		public virtual DbSet<ParticipatesIn> ParticipatesIns { get; set; }
		public virtual DbSet<Piece> Pieces { get; set; }
		public virtual DbSet<Player> Players { get; set; }
		public virtual DbSet<Result> Results { get; set; }
		public virtual DbSet<Title> Titles { get; set; }
		public virtual DbSet<Tournament> Tournaments { get; set; }
		public virtual DbSet<Transfer> Transfers { get; set; }
		public virtual DbSet<Visitor> Visitors { get; set; }
		public virtual DbSet<Vote> Votes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			if (!optionsBuilder.IsConfigured) {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
				optionsBuilder.UseMySQL(connectionString: "Server=127.0.0.1;Database=chessapp;Uid=root;");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Conduct>(entity => {
				entity.HasKey(e => new { e.TournamentId, e.OrganizerId })
				      .HasName(name: "PRIMARY");

				entity.ToTable(name: "conducts");

				entity.HasIndex(e => e.OrganizerId, name: "arranges");

				entity.Property(e => e.TournamentId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "tournament_id");

				entity.Property(e => e.OrganizerId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "organizer_id");

				entity.HasOne(d => d.Organizer)
				      .WithMany(p => p.Conducts)
				      .HasForeignKey(d => d.OrganizerId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "arranges");

				entity.HasOne(d => d.Tournament)
				      .WithMany(p => p.Conducts)
				      .HasForeignKey(d => d.TournamentId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "is_conducted");
			});

			modelBuilder.Entity<Country>(entity => {
				entity.ToTable(name: "country");

				entity.Property(e => e.Id)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "id");

				entity.Property(e => e.Alphacode)
				      .HasMaxLength(maxLength: 20)
				      .HasColumnName(name: "alphacode")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.Property(e => e.Name)
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "name")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.HasMany(c => c.Players)
				      .WithOne(p => p.Country)
				      .HasForeignKey(p => p.CountryId);
			});

			modelBuilder.Entity<Federation>(entity => {
				entity.ToTable(name: "federation");

				entity.Property(e => e.Id)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "id");

				entity.Property(e => e.Abbreviation)
				      .HasMaxLength(maxLength: 20)
				      .HasColumnName(name: "abbreviation")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.Property(e => e.FoundationDate)
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "foundation_date")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.Property(e => e.Headquarters)
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "headquarters")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.Property(e => e.Name)
				      .IsRequired()
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "name");

				entity.Property(e => e.PresidentName)
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "president_name")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.Property(e => e.Website)
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "website")
				      .HasDefaultValueSql(sql: "'NULL'");
			});

			modelBuilder.Entity<Game>(entity => {
				entity.ToTable(name: "game");

				entity.HasIndex(e => e.TournamentId, name: "consists_of");

				entity.Property(e => e.Id)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "id");

				entity.Property(e => e.EndTime)
				      .HasColumnType(typeName: "date")
				      .HasColumnName(name: "end_time");

				entity.Property(e => e.Name)
				      .IsRequired()
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "name");

				entity.Property(e => e.StartTime)
				      .HasColumnType(typeName: "date")
				      .HasColumnName(name: "start_time");

				entity.Property(e => e.TournamentId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "tournament_id");

				entity.HasOne(d => d.Tournament)
				      .WithMany(p => p.Games)
				      .HasForeignKey(d => d.TournamentId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "consists_of");
			});

			modelBuilder.Entity<Move>(entity => {
				entity.ToTable(name: "move");

				entity.HasKey(m => m.PieceId);

				entity.HasKey(m => m.PlayerId);

				entity.HasIndex(e => e.PieceId, name: "makes");

				entity.HasIndex(e => e.PlayerId, name: "starts");

				entity.Property(e => e.Id)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "id");

				entity.Property(e => e.FromSquare)
				      .IsRequired()
				      .HasMaxLength(maxLength: 2)
				      .HasColumnName(name: "from_square");

				entity.Property(e => e.IsCapturing)
				      .HasColumnType(typeName: "bit(1)")
				      .HasColumnName(name: "is_capturing")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.Property(e => e.IsCheck)
				      .HasColumnType(typeName: "bit(1)")
				      .HasColumnName(name: "is_check")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.Property(e => e.PieceId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "piece_id");

				entity.Property(e => e.PlayerId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "player_id");

				entity.Property(e => e.Time)
				      .HasColumnName(name: "time")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.Property(e => e.ToSquare)
				      .IsRequired()
				      .HasMaxLength(maxLength: 2)
				      .HasColumnName(name: "to_square");

				entity.HasOne(d => d.Piece)
				      .WithMany(p => p.Moves)
				      .HasForeignKey(d => d.PieceId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "makes");

				entity.HasOne(d => d.Player)
				      .WithMany(p => p.Moves)
				      .HasForeignKey(d => d.PlayerId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "starts");
			});

			modelBuilder.Entity<Organizer>(entity => {
				entity.ToTable(name: "organizer");

				entity.Property(e => e.Id)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "id");

				entity.Property(e => e.Name)
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "name")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.Property(e => e.Website)
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "website")
				      .HasDefaultValueSql(sql: "'NULL'");
			});

			modelBuilder.Entity<ParticipatesIn>(entity => {
				entity.HasKey(e => new { e.GameId, e.PlayerId })
				      .HasName(name: "PRIMARY");

				entity.ToTable(name: "participates_in");

				entity.HasIndex(e => e.PlayerId, name: "plays_in");

				entity.Property(e => e.GameId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "game_id");

				entity.Property(e => e.PlayerId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "player_id");

				entity.HasOne(d => d.Game)
				      .WithMany(p => p.ParticipatesIns)
				      .HasForeignKey(d => d.GameId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "is_between");

				entity.HasOne(d => d.Player)
				      .WithMany(p => p.ParticipatesIns)
				      .HasForeignKey(d => d.PlayerId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "plays_in");
			});

			modelBuilder.Entity<Piece>(entity => {
				entity.ToTable(name: "piece");

				entity.HasIndex(e => e.PlayerId, name: "controlls");

				entity.Property(e => e.Id)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "id");

				entity.Property(e => e.Color)
				      .HasColumnType(typeName: "bit(1)")
				      .HasColumnName(name: "color");

				entity.Property(e => e.PlayerId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "player_id");

				entity.Property(e => e.Square)
				      .HasMaxLength(maxLength: 2)
				      .HasColumnName(name: "square")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.Property(e => e.Type)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "type");

				entity.HasOne(d => d.Player)
				      .WithMany(p => p.Pieces)
				      .HasForeignKey(d => d.PlayerId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "controlls");
			});

			modelBuilder.Entity<Player>(entity => {
				entity.ToTable(name: "player");

				entity.HasIndex(e => e.CountryId, name: "produces");
				entity.HasKey(e => e.CountryId);

				entity.Property(e => e.Id)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "id");

				entity.Property(e => e.BirthDate)
				      .HasColumnType(typeName: "date")
				      .HasColumnName(name: "birth_date")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.Property(e => e.CountryId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "country_id");

				entity.Property(e => e.Firstname)
				      .IsRequired()
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "firstname");

				entity.Property(e => e.Gender)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "gender");

				entity.Property(e => e.Lastname)
				      .IsRequired()
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "lastname");

				entity.Property(e => e.PhoneNumber)
				      .HasMaxLength(maxLength: 32)
				      .HasColumnName(name: "phone_number")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.Property(e => e.Rank)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "rank")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.HasOne(d => d.Country)
				      .WithMany(p => p.Players)
				      .HasForeignKey(d => d.CountryId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "produces");

				entity.HasMany(p => p.Pieces)
				      .WithOne(p => p.Player)
				      .HasForeignKey(p => p.PlayerId);

				entity.HasMany(p => p.Moves)
				      .WithOne(m => m.Player)
				      .HasForeignKey(m => m.PlayerId);
			});

			modelBuilder.Entity<Result>(entity => {
				entity.ToTable(name: "result");

				entity.HasIndex(e => e.GameId, name: "results_in");

				entity.Property(e => e.Id)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "id");

				entity.Property(e => e.GameId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "game_id");

				entity.Property(e => e.Type)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "type")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.HasOne(d => d.Game)
				      .WithMany(p => p.Results)
				      .HasForeignKey(d => d.GameId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "results_in");
			});

			modelBuilder.Entity<Title>(entity => {
				entity.ToTable(name: "title");

				entity.HasIndex(e => e.PlayerId, name: "holds");

				entity.Property(e => e.Id)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "id");

				entity.Property(e => e.Date)
				      .HasColumnType(typeName: "date")
				      .HasColumnName(name: "date");

				entity.Property(e => e.Name)
				      .IsRequired()
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "name");

				entity.Property(e => e.PlayerId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "player_id");

				entity.HasOne(d => d.Player)
				      .WithMany(p => p.Titles)
				      .HasForeignKey(d => d.PlayerId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "holds");
			});

			modelBuilder.Entity<Tournament>(entity => {
				entity.ToTable(name: "tournament");

				entity.HasIndex(e => e.CountryId, name: "takes_place");

				entity.Property(e => e.Id)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "id");

				entity.Property(e => e.CountryId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "country_id");

				entity.Property(e => e.EndDate)
				      .HasColumnType(typeName: "date")
				      .HasColumnName(name: "end_date");

				entity.Property(e => e.Name)
				      .IsRequired()
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "name");

				entity.Property(e => e.StartDate)
				      .HasColumnType(typeName: "date")
				      .HasColumnName(name: "start_date");

				entity.HasOne(d => d.Country)
				      .WithMany(p => p.Tournaments)
				      .HasForeignKey(d => d.CountryId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "takes_place");
			});

			modelBuilder.Entity<Transfer>(entity => {
				entity.ToTable(name: "transfer");

				entity.HasIndex(e => e.NewFederationId, name: "approves");

				entity.HasIndex(e => e.FormerFederationId, name: "releases");

				entity.HasIndex(e => e.PlayerId, name: "signs_for");

				entity.Property(e => e.Id)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "id");

				entity.Property(e => e.Date)
				      .HasColumnType(typeName: "date")
				      .HasColumnName(name: "date");

				entity.Property(e => e.Fee)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "fee")
				      .HasDefaultValueSql(sql: "'NULL'");

				entity.Property(e => e.FormerFederationId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "former_federation_id");

				entity.Property(e => e.NewFederationId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "new_federation_id");

				entity.Property(e => e.PlayerId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "player_id");

				entity.HasOne(d => d.FormerFederation)
				      .WithMany(p => p.TransferFormerFederations)
				      .HasForeignKey(d => d.FormerFederationId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "releases");

				entity.HasOne(d => d.NewFederation)
				      .WithMany(p => p.TransferNewFederations)
				      .HasForeignKey(d => d.NewFederationId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "approves");

				entity.HasOne(d => d.Player)
				      .WithMany(p => p.Transfers)
				      .HasForeignKey(d => d.PlayerId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "signs_for");
			});

			modelBuilder.Entity<Visitor>(entity => {
				entity.ToTable(name: "visitor");

				entity.Property(e => e.Id)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "id");

				entity.Property(e => e.Email)
				      .IsRequired()
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "email");

				entity.Property(e => e.Name)
				      .IsRequired()
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "name");

				entity.Property(e => e.Password)
				      .IsRequired()
				      .HasMaxLength(maxLength: 128)
				      .HasColumnName(name: "password");
			});

			modelBuilder.Entity<Vote>(entity => {
				entity.ToTable(name: "vote");

				entity.HasIndex(e => e.GameId, name: "gets");

				entity.HasIndex(e => e.VisitorId, name: "leaves");

				entity.HasIndex(e => e.PlayerId, name: "receives");

				entity.Property(e => e.Id)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "id");

				entity.Property(e => e.GameId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "game_id");

				entity.Property(e => e.PlayerId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "player_id");

				entity.Property(e => e.VisitorId)
				      .HasColumnType(typeName: "int(11)")
				      .HasColumnName(name: "visitor_id");

				entity.HasOne(d => d.Game)
				      .WithMany(p => p.Votes)
				      .HasForeignKey(d => d.GameId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "gets");

				entity.HasOne(d => d.Player)
				      .WithMany(p => p.Votes)
				      .HasForeignKey(d => d.PlayerId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "receives");

				entity.HasOne(d => d.Visitor)
				      .WithMany(p => p.Votes)
				      .HasForeignKey(d => d.VisitorId)
				      .OnDelete(DeleteBehavior.ClientSetNull)
				      .HasConstraintName(name: "leaves");
			});

			// base.OnModelCreatingPartial(modelBuilder);
		}

		// private void OnModelCreatingPartial(ModelBuilder modelBuilder)
		// {
		//     throw new NotImplementedException();
		// }
	}
}