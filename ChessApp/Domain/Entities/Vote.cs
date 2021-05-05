#nullable disable

namespace ChessApp.Domain.Entities {
	public class Vote {
		public int GameId { get; set; }
		public int PlayerId { get; set; }
		public int VisitorId { get; set; }
		public int Id { get; set; }

		public virtual Game Game { get; set; }
		public virtual Player Player { get; set; }
		public virtual Visitor Visitor { get; set; }
	}
}