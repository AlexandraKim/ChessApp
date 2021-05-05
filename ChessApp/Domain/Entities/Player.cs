using System;
using System.Collections.Generic;
using ChessApp.Domain.Supplementary;

#nullable disable

namespace ChessApp.Domain.Entities {
	public class Player {
		public Player() {
			Moves = new HashSet<Move>();
			ParticipatesIns = new HashSet<ParticipatesIn>();
			Pieces = new HashSet<Piece>();
			Titles = new HashSet<Title>();
			Transfers = new HashSet<Transfer>();
			Votes = new HashSet<Vote>();
		}

		public int Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public int? Rank { get; set; }
		public string PhoneNumber { get; set; }
		public GenderType Gender { get; set; }
		public DateTime? BirthDate { get; set; }
		public int CountryId { get; set; }

		public virtual Country Country { get; set; }
		public virtual ICollection<Move> Moves { get; set; }
		public virtual ICollection<ParticipatesIn> ParticipatesIns { get; set; }
		public virtual ICollection<Piece> Pieces { get; set; }
		public virtual ICollection<Title> Titles { get; set; }
		public virtual ICollection<Transfer> Transfers { get; set; }
		public virtual ICollection<Vote> Votes { get; set; }
	}
}