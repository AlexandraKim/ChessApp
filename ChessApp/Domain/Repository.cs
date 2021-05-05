using ChessApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessApp.Domain
{
    public class Repository
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Player> GetPlayersAndTitles()
        {
            return _context.Players
                           .Include(p => p.Country)
                           .Include(p => p.Titles)
                           .ToList();
        }

        public IEnumerable<ParticipatesIn> GetParticipatesIns() {
            return _context.ParticipatesIns
                           .Include(p => p.Player)
                           .ThenInclude(p => p.Moves)
                           .ThenInclude(m => m.Piece)
                           .Include(p => p.Game)
                           .ThenInclude(g => g.Tournament)
                           .Include(p => p.Game)
                           .ThenInclude(g => g.Moves)
                           .ToList();
        }
    }
}
