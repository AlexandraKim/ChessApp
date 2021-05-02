﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Match
    {
        public Match()
        {
            Players = new List<Player>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int TournamentId { get; set; }

        public virtual Tournament Tournament { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
