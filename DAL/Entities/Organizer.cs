using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Organizer
    {
        public Organizer()
        {
            Tournaments = new List<Tournament>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public ICollection<Tournament> Tournaments { get; set; }
    }
}
