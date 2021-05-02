using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Supplementary;

namespace Domain.Entities
{
    public class Piece
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public PieceType Type { get; set; }

        public bool Color { get; set; }

        public string Square { get; set; }
    }
}
