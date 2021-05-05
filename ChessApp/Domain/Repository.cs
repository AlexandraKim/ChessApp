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

        public IEnumerable<ParticipatesIn> GetParticipatesIns()
        {
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

        public IEnumerable<Game> GetGamesWithParticipants()
        {
            return _context.Games.Include(g => g.Moves).Include(g => g.Tournament).Include(g => g.ParticipatesIns).ThenInclude(p => p.Player).ToList();
        }

        public Player GetGameWinner(int id)
        {
            var game = _context.Games.Where(g => g.Id == id).Include(g => g.Moves).ThenInclude(m => m.Player).FirstOrDefault();
            var lastMove = game.Moves.Where(m => m.IsCheck == true).OrderByDescending(m => m.Time).FirstOrDefault();
            return lastMove.Player;
        }

        public IEnumerable<Move> GetMovesOfGame(int id)
        {
            var moves = from m in _context.Moves
                        join p in _context.Players
                        on m.PlayerId equals p.Id
                        join pi in _context.Pieces
                        on m.PieceId equals pi.Id
                        join g in _context.Games
                        on m.GameId equals g.Id
                        where m.GameId == id
                        select new Move
                        {
                            Id = m.Id,
                            Player = p,
                            Piece = pi,
                            FromSquare = m.FromSquare,
                            ToSquare = m.ToSquare,
                            IsCapturing = m.IsCapturing,
                            IsCheck = m.IsCheck,

                        };

            
            return moves.ToList();
        }

        public IEnumerable<Transfer> GetTransfers() {
            return _context.Transfers.Include(t => t.FormerFederation)
                           .Include(t => t.NewFederation)
                           .Include(t => t.Player)
                           .ToList();
        }
    }
}
