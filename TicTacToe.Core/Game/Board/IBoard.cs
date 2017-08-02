using System.Collections.Generic;
using TicTacToe.Core.Game.Board.Tile;
using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Board
{
    public interface IBoard
    {
        ITile this[int index] { get; }

        int Count { get; }
        int Size { get; }

        IEnumerator<ITile> GetEnumerator();
        ITile GetTile(ICoordinate coordinate);
        ITile GetTile(int position);
        ITile GetTile(int x, int y);
        TicTacToeBoard SetTile(ICoordinate coordinate, IPlayer currentPlayer);
    }
}