using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Move
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public int PieceId { get; set; }

        public string FromSquare { get; set; }

        public string ToSquare { get; set; }

        public DateTime Time { get; set; }

        public bool IsCapturing { get; set; }

        public bool IsCheck { get; set; 
    }
}
