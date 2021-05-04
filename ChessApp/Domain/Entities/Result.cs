using ChessApp.Domain.Supplementary;

#nullable disable

namespace ChessApp.Domain.Entities {
	public class Result {
		public int Id { get; set; }
		public int GameId { get; set; }
		public ResultType Type { get; set; }

		public virtual Game Game { get; set; }
	}
}