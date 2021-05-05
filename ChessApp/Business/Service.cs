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
                for (int i = 0; i < player.Titles.Count; i++) {
                    if (i == 0) {
                        table.Rows.Add(player.Name,
                                       player.Gender,
                                       player.Rank.ToString(),
                                       player.BirthDate.Value.ToString("yyyy MMMM"),
                                       player.Country.Name,
                                       $"{player.Titles.First().Name} ({player.Titles.First().Date.Year})");
                    } else {
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

        //public DataTable GetGamesTable() {
        //    var table = new DataTable();
        //    IEnumerable<ParticipatesIn> participatesIns = _repository.GetParticipatesIns();
        //    table.Columns.Add(columnName: "Result", typeof(string));
        //    table.Columns.Add(columnName: "Player 1", typeof(string));
        //    table.Columns.Add(columnName: "Player 2", typeof(string));
        //    table.Columns.Add(columnName: "Start Time", typeof(string));
        //    table.Columns.Add(columnName: "End Time", typeof(string));
        //    table.Columns.Add(columnName: "Tournament", typeof(string));
        //    table.Columns.Add(columnName: "Moves History", typeof(string));

        //    foreach (IGrouping<Game, ParticipatesIn> gameGroup in participatesIns.GroupBy(x => x.Game)) {
        //        // ParticipatesIn winner = gameGroup.First(g => g.Player.Moves.Any(m => m.IsCheck != null && m.IsCheck.Value));
        //        ParticipatesIn game = gameGroup.First();
        //        // table.Rows.Add($"{winner.Player.Name} - {game.Game.Result}",
        //        table.Rows.Add($"Winner name - {game.Game.Result}",
        //                       game.Player.Name,
        //                       gameGroup.Last().Player.Name,
        //                       game.Game.StartTime.ToString(format: "g"),
        //                       game.Game.EndTime.ToString(format: "g"),
        //                       game.Game.Tournament.Name,
        //                       game.Player.Moves.First().Piece.Type);
        //            // } else {
        //            //     table.Rows.Add(string.Empty,
        //            //                    string.Empty,
        //            //                    string.Empty,
        //            //                    string.Empty,
        //            //                    string.Empty,
        //            //                    string.Empty,
        //            //                    game.Player.Moves.First().Piece.Type);
        //        // }
        //    }

        //    return table;
        //}


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
                var winnerName = _repository.GetGameWinnerName(game.Id);
                table.Rows.Add($"Winner name - {winnerName}",
                               game.ParticipatesIns.Select(p=>p.Player.Name).First(),
                               game.ParticipatesIns.Select(p=>p.Player.Name).Last(),
                               game.StartTime.ToString(format: "g"),
                               game.EndTime.ToString(format: "g"),
                               game.Tournament.Name);
            }

            return table;
        }
    }
}
