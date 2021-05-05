using System;

#nullable disable

namespace ChessApp.Domain.Entities {
	public class Title {
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public int PlayerId { get; set; }

		public virtual Player Player { get; set; }
	}
}