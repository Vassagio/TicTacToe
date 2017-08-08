using System.Collections.Generic;
using TicTacToe.Core.Game.Board.Tile;
using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Board
{
    public interface IBoard
    {        
        int Count { get; }
        int Size { get; }

        IEnumerator<ITile> GetEnumerator();
        ITile GetTileBy(ICoordinate coordinate);
        ITile GetTileBy(int position);
        ITile GetTileBy(int x, int y);
        TicTacToeBoard ReserveTileBy(ICoordinate coordinate, IPlayer currentPlayer);
        TicTacToeBoard ReserveTileBy(int x, int y, IPlayer currentPlayer);
        TicTacToeBoard ReserveTileBy(int position, IPlayer currentPlayer);
    }
}