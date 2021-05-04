using System;

#nullable disable

namespace ChessApp.Domain.Entities {
	public class Transfer {
		public DateTime Date { get; set; }
		public int? Fee { get; set; }
		public int PlayerId { get; set; }
		public int FormerFederationId { get; set; }
		public int NewFederationId { get; set; }
		public int Id { get; set; }

		public virtual Federation FormerFederation { get; set; }
		public virtual Federation NewFederation { get; set; }
		public virtual Player Player { get; set; }
	}
}