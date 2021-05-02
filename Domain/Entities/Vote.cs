using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Vote
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MatchId { get; set; }
        
        public int PlayerId { get; set; }
    }
}
