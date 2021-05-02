using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Piece
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public Enum Type { get; set; }

        public string Color { get; set; }

        public string Square { get; set; }
    }
}
