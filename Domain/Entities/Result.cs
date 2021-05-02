using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Supplementary;

namespace Domain.Entities
{
    public class Result
    {
        public int MatchId { get; set; }

        public ResultType Type { get; set; }
    }
}
