#nullable disable

namespace ChessApp.Domain.Entities {
	public class Conduct {
		public int TournamentId { get; set; }
		public int OrganizerId { get; set; }

		public virtual Organizer Organizer { get; set; }
		public virtual Tournament Tournament { get; set; }
	}
}