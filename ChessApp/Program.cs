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
			var tableView = new TableView(table) {
				X = Pos.Left(header),
				Y = Pos.Top(header) + 1,
				Width = Dim.Fill(),
				Height = Dim.Fill()
			};
			win.Add(tableView);
			Application.Run();
		}
	}
}