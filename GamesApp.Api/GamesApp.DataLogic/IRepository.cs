using System;
using GamesApp.BusinessLogic;

namespace GamesApp.DataLogic
{
	public interface IRepository
	{
		Task<IEnumerable<Game>> GetAllGames();
		Task<IEnumerable<Game>> CreateNewGame(Game newGame);
		//Task<IEnumerable<Game>> GetGame(string title);
	}
}

