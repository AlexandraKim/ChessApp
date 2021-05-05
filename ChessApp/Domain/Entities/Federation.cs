using System.Collections.Generic;

#nullable disable

namespace ChessApp.Domain.Entities {
	public class Federation {
		public Federation() {
			TransferFormerFederations = new HashSet<Transfer>();
			TransferNewFederations = new HashSet<Transfer>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Abbreviation { get; set; }
		public string Headquarters { get; set; }
		public string PresidentName { get; set; }
		public string FoundationDate { get; set; }
		public string Website { get; set; }

		public virtual ICollection<Transfer> TransferFormerFederations { get; set; }
		public virtual ICollection<Transfer> TransferNewFederations { get; set; }
	}
}