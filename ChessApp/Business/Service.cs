using ChessApp.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var players = _repository.GetPlayersAndTitles();
            var table = new DataTable();
            table.Columns.Add(columnName: "Name", typeof(string));
            table.Columns.Add(columnName: "Gender", typeof(string));
            table.Columns.Add(columnName: "Rank", typeof(int));
            table.Columns.Add(columnName: "Date Of Birth", typeof(string));
            table.Columns.Add(columnName: "Country", typeof(string));
            table.Columns.Add(columnName: "Titles", typeof(string));

            foreach (var player in players)
            {
                table.Rows.Add(player.Firstname +player.Lastname,
                               player.Gender,
                               player.Rank,
                               player.BirthDate,
                               player.Country.Name,
                               String.Join(",",player.Titles.Select(t=>t.Name).ToList()));
            }

            return table;
        }
    }
}
