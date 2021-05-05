#nullable disable

namespace ChessApp.Domain.Entities {
	public class ParticipatesIn {
		public int PlayerId { get; set; }
		public int GameId { get; set; }

		public virtual Game Game { get; set; }
		public virtual Player Player { get; set; }
	}
}	