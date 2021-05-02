using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Transfer
    {
        public int Id { get; set; }

        public int FormerFederationId { get; set; }

        public int NewFederationId { get; set; }

        public int PlayerId { get; set; }

        public DateTime Date { get; set; }

        public int? Fee { get; set; }
    }
}
