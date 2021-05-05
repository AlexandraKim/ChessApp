using System;
using System.Collections.Generic;
using ChessApp.Domain.Supplementary;

#nullable disable

namespace ChessApp.Domain.Entities {
	public class Game {
		public Game() {
			ParticipatesIns = new HashSet<ParticipatesIn>();
			Votes = new HashSet<Vote>();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime StartTime { get; set; }
		public int TournamentId { get; set; }
		public DateTime EndTime { get; set; }
		public ResultType Result { get; set; }

		public virtual Tournament Tournament { get; set; }
		public virtual ICollection<ParticipatesIn> ParticipatesIns { get; set; }
		public virtual ICollection<Vote> Votes { get; set; }
		public virtual ICollection<Move> Moves { get; set; }
	}
}