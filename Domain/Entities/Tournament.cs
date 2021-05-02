using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Tournament
    {
        public Tournament()
        {
            Organizers = new List<Organizer>();
        }

        public int Id { get; set; }

        public int CountryId { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<Organizer> Organizers { get; set; }
    }
}
