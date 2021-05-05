using System.Collections.Generic;
using ChessApp.Domain;
using System.Data;
using System.Linq;
using ChessApp.Domain.Entities;

namespace ChessApp.Business
{
    public class Service
    {
        private readonly Repository _repository;

        public Service(Repository repository)
        {
            _repository = repository;
        }


        public DataTable GetPlayersAndTitlesTable()
        {
            IEnumerable<Player> players = _repository.GetPlayersAndTitles();
            var table = new DataTable();
            table.Columns.Add(columnName: "Name", typeof(string));
            table.Columns.Add(columnName: "Gender", typeof(string));
            table.Columns.Add(columnName: "Rank", typeof(string));
            table.Columns.Add(columnName: "Date Of Birth", typeof(string));
            table.Columns.Add(columnName: "Country", typeof(string));
            table.Columns.Add(columnName: "Titles", typeof(string));

            foreach (Player player in players)
            {
                for (int i = 0; i < player.Titles.Count; i++)
                {
                    if (i == 0)
                    {
                        table.Rows.Add(player.Name,
                                       player.Gender,
                                       player.Rank.ToString(),
                                       player.BirthDate.Value.ToString("yyyy MMMM"),
                                       player.Country.Name,
                                       $"{player.Titles.First().Name} ({player.Titles.First().Date.Year})");
                    }
                    else
                    {
                        table.Rows.Add(string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       $"{player.Titles.ElementAt(i).Name} ({player.Titles.ElementAt(i).Date.Year})");
                    }
                }
            }

            return table;
        }

        public DataTable GetGamesTable()
        {
            var table = new DataTable();
            var games = _repository.GetGamesWithParticipants();
            table.Columns.Add(columnName: "Result", typeof(string));
            table.Columns.Add(columnName: "Player 1", typeof(string));
            table.Columns.Add(columnName: "Player 2", typeof(string));
            table.Columns.Add(columnName: "Start Time", typeof(string));
            table.Columns.Add(columnName: "End Time", typeof(string));
            table.Columns.Add(columnName: "Tournament", typeof(string));

            foreach (var game in games)
            {
                var winnerName = _repository.GetGameWinner(game.Id).Name;
                table.Rows.Add($"{winnerName} by {game.Result}",
                               game.ParticipatesIns.Select(p => p.Player.Name).First(),
                               game.ParticipatesIns.Select(p => p.Player.Name).Last(),
                               game.StartTime.ToString(format: "g"),
                               game.EndTime.ToString(format: "g"),
                               game.Tournament.Name);
            }

            return table;
        }

        public DataTable GetMoves()
        {
            var table = new DataTable();
            var game = _repository.GetGamesWithParticipants().First();
            var moves = _repository.GetMovesOfGame(game.Id);

            table.Columns.Add(columnName: "Game", typeof(string));
            table.Columns.Add(columnName: "Player", typeof(string));
            table.Columns.Add(columnName: "Piece", typeof(string));
            table.Columns.Add(columnName: "From Square", typeof(string));
            table.Columns.Add(columnName: "To Square", typeof(string));
            table.Columns.Add(columnName: "Is Check", typeof(string));
            table.Columns.Add(columnName: "Is Capturing", typeof(string));

            foreach (var move in moves)
            {
                table.Rows.Add(game.Name,
                               move.Player.Name,
                               move.Piece.Type,
                               move.FromSquare,
                               move.ToSquare,
                               move.IsCheck,
                               move.IsCapturing);
            }

            return table;
        }

        public DataTable GetTransfersTable()
        {
            var table = new DataTable();
            IEnumerable<Transfer> transfers = _repository.GetTransfers();
            table.Columns.Add(columnName: "Name", typeof(string));
            table.Columns.Add(columnName: "Federation", typeof(string));
            table.Columns.Add(columnName: "Former Federation", typeof(string));
            table.Columns.Add(columnName: "Date", typeof(string));
            table.Columns.Add(columnName: "Fee", typeof(string));

            foreach (Transfer transfer in transfers)
            {
                table.Rows.Add(transfer.Player.Name,
                               transfer.NewFederation.Abbreviation,
                               transfer.FormerFederation.Abbreviation,
                               transfer.Date.ToString("MM/dd/yyyy"),
                               transfer.Fee);
            }

            return table;
        }

        public DataTable GetTournamentsTable() {
            var table = new DataTable();
            IEnumerable<Tournament> tournaments = _repository.GetTournaments();
            table.Columns.Add(columnName: "Name", typeof(string));
            table.Columns.Add(columnName: "Country", typeof(string));
            table.Columns.Add(columnName: "Start Date", typeof(string));
            table.Columns.Add(columnName: "End Date", typeof(string));
            table.Columns.Add(columnName: "Orginizer", typeof(string));

            foreach (Tournament tournament in tournaments) {
                for (int i = 0; i < tournament.Conducts.Count; i++) {
                    table.Rows.Add(tournament.Name,
                                   tournament.Country.Name,
                                   tournament.StartDate.Date.ToString("MM/dd/yyyy"),
                                   tournament.EndDate,
                                   tournament.Conducts.ElementAt(i).Organizer.Name);
                }
            }

            return table;
        }

        public DataTable GetVotes()
        {

            var table = new DataTable();
            var votes = _repository.GetVotes();

            table.Columns.Add(columnName: "Visitor Name", typeof(string));
            table.Columns.Add(columnName: "Game Name", typeof(string));
            table.Columns.Add(columnName: "Player Name", typeof(string));
            table.Columns.Add(columnName: "Is Vote successful", typeof(string));


            foreach (var vote in votes)
            {
                var isSuccessfulVote = _repository.GetGameWinner(vote.Game.Id).Id==vote.Player.Id;
                table.Rows.Add(vote.Visitor.Name,
                                vote.Game.Name,
                                vote.Player.Name,
                                isSuccessfulVote);
            }

            return table;
        }
    }
}
