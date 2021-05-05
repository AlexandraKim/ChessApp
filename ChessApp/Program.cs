using System.Data;
using System.Linq;
using ChessApp.Business;
using ChessApp.Domain;
using Terminal.Gui;

// Scaffold-DbContext "Server=127.0.0.1;Database=chessapp;Uid=root;" MySql.EntityFrameworkCore -OutputDir chess -f
namespace ChessApp {
	internal class Program {

		private static void Main(string[] args) {
			var _service = new Service(new Repository(new AppDbContext()));

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

			DataTable table = _service.GetPlayersAndTitlesTable();
			var playersTableView = new TableView(table) {
				X = Pos.Left(header),
				Y = Pos.Top(header) + 1,
				Width = Dim.Fill(),
				Height = Dim.Fill()
			};
			win.Add(playersTableView);

			var gamesHeader = new Label(text: "GAMES:") {
				X = Pos.Left(playersTableView),
				Y = Pos.Top(playersTableView) + table.Rows.Count + 4
			};
			win.Add(gamesHeader);

			DataTable gamesTable = _service.GetGamesTable();
			var gamesTableView = new TableView(gamesTable) {
				X = Pos.Left(gamesHeader),
				Y = Pos.Top(gamesHeader) + 1,
				Width = Dim.Fill(),
				Height = Dim.Fill()
			};
			win.Add(gamesTableView);

			var transfersHeader = new Label(text: "TRANSFERS:") {
				X = Pos.Left(gamesTableView),
				Y = Pos.Top(gamesTableView) + gamesTable.Rows.Count + 4
			};
			win.Add(transfersHeader);

			DataTable transfersTable = _service.GetTransfersTable();
			var transfersTableView = new TableView(transfersTable) {
				X = Pos.Left(transfersHeader),
				Y = Pos.Top(transfersHeader) + 1,
				Width = Dim.Fill(),
				Height = Dim.Fill()
			};
			win.Add(transfersTableView);

			var tournamentsHeader = new Label(text: "Tournaments:") {
				X = Pos.Left(transfersTableView),
				Y = Pos.Top(transfersTableView) + transfersTable.Rows.Count + 4
			};
			win.Add(tournamentsHeader);

			DataTable tournamentsTable = _service.GetTournamentsTable();
			var tournamentsTableView = new TableView(tournamentsTable) {
				X = Pos.Left(tournamentsHeader),
				Y = Pos.Top(tournamentsHeader) + 1,
				Width = Dim.Fill(),
				Height = Dim.Fill()
			};
			win.Add(tournamentsTableView);
			Application.Run();
		}
	}
}