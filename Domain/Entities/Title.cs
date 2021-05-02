using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Title
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}
