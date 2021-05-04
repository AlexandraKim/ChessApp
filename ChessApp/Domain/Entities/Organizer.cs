using System.Collections.Generic;

#nullable disable

namespace ChessApp.Domain.Entities {
	public class Organizer {
		public Organizer() {
			Conducts = new HashSet<Conduct>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Website { get; set; }

		public virtual ICollection<Conduct> Conducts { get; set; }
	}
}