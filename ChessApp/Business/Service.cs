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
                                       player.BirthDate,
                                       player.Country.Name,
                                       player.Titles.First().Name);
                    } else {
                        table.Rows.Add(string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       string.Empty,
                                       player.Titles.ElementAt(i).Name);
                    }
                }
            }

            return table;
        }
    }
}
