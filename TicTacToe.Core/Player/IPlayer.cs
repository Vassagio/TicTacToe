using TicTacToe.Core.Game.Board.Tile.Coordinate;

namespace TicTacToe.Core.Player
{
    public interface IPlayer
    {
        string Name { get; }
        string Symbol { get; }        
        ICoordinate GetNextMove();
    }
}