using System;
using System.Collections.Generic;

#nullable disable

namespace ChessApp.Domain.Entities {
	public class Tournament {
		public Tournament() {
			Conducts = new HashSet<Conduct>();
			Games = new HashSet<Game>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int CountryId { get; set; }

		public virtual Country Country { get; set; }
		public virtual ICollection<Conduct> Conducts { get; set; }
		public virtual ICollection<Game> Games { get; set; }
	}
}