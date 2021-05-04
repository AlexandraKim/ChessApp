using System.Collections.Generic;

#nullable disable

namespace ChessApp.Domain.Entities {
	public class Visitor {
		public Visitor() {
			Votes = new HashSet<Vote>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public virtual ICollection<Vote> Votes { get; set; }
	}
}