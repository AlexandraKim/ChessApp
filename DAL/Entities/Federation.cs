using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Federation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string Headquarters { get; set; }

        public string PresidentName { get; set; }

        public DateTime FoundationDate { get; set; }

        public string Website { get; set; }
    }
}
