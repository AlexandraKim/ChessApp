using System.Data;
using System.Linq;
using ChessApp.Domain;
using Terminal.Gui;

// Scaffold-DbContext "Server=127.0.0.1;Database=chessapp;Uid=root;" MySql.EntityFrameworkCore -OutputDir chess -f
namespace ChessApp {
	internal class Program {
		private static readonly AppDbContext Context = new();

		private static void Main(string[] args) {
			Application.Init();
			Toplevel top = Application.Top;
			top.Width = 1000;

			var win = new Window(title: "The Chess Board") {
				X = 0,
				Y = 1,

				Width = Dim.Fill(),
				Height = Dim.Fill()
			};
			top.Add(win);

			var header = new Label(text: "TOP PLAYERS:") { X = 3, Y = 2 };
			win.Add(header);

			DataTable table = GetPlayersTable();
			var tableView = new TableView(table) {
				X = Pos.Left(header),
				Y = Pos.Top(header) + 1,
				Width = Dim.Fill(),
				Height = Dim.Fill()
			};
			win.Add(tableView);
			Application.Run();
		}

		private static DataTable GetPlayersTable() {
			var table = new DataTable();
			table.Columns.Add(columnName: "Name", typeof(string));
			table.Columns.Add(columnName: "Gender", typeof(string));
			table.Columns.Add(columnName: "Rank", typeof(int));
			table.Columns.Add(columnName: "Date Of Birth", typeof(string));
			table.Columns.Add(columnName: "Country", typeof(string));
			table.Columns.Add(columnName: "Titles", typeof(string));

			var players = (from p in Context.Players
			               join c in Context.Countries on p.CountryId equals c.Id
			               select new {
				               Id = p.Id,
				               Name = $"{p.Firstname} {p.Lastname}",
				               p.Gender,
				               p.Rank,
				               BirthDate = p.BirthDate.Value.ToString("yyyy MMMM"),
				               Country = c.Name
			               }).ToList();
			foreach (var player in players) {
				var titles = string.Empty;
				Context.Titles
				       .Where(x => x.PlayerId == player.Id)
				       .OrderByDescending(x => x.Date)
				       .ToList()
				       .ForEach(x => titles += $"{x.Name} ({x.Date.Year}), ");
				titles.Substring(titles.Length - 2);
				table.Rows.Add(player.Name,
				               player.Gender,
				               player.Rank,
				               player.BirthDate,
				               player.Country,
				               titles);
			}
			return table;
		}
	}
}