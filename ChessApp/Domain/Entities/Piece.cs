using System.Collections.Generic;
using ChessApp.Domain.Supplementary;

#nullable disable

namespace ChessApp.Domain.Entities {
	public class Piece {
		public Piece() {
			Moves = new HashSet<Move>();
		}

		public int Id { get; set; }
		public bool Color { get; set; }
		public string Square { get; set; }
		public int PlayerId { get; set; }
		public PieceType Type { get; set; }

		public virtual Player Player { get; set; }
		public virtual ICollection<Move> Moves { get; set; }
	}
}