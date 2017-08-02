using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Board.Tile
{
    public interface ITile
    {
        IPlayer Player { get; }
        int Position { get; }
        ICoordinate Coordinate { get; }
        ITile SetPlayer(IPlayer player);
    }
}