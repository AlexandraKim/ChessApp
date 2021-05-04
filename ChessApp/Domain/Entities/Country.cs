using System.Collections.Generic;

#nullable disable

namespace ChessApp.Domain.Entities {
	public class Country {
		public Country() {
			Players = new HashSet<Player>();
			Tournaments = new HashSet<Tournament>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Alphacode { get; set; }

		public virtual ICollection<Player> Players { get; set; }
		public virtual ICollection<Tournament> Tournaments { get; set; }
	}
}