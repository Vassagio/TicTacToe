using TicTacToe.Core.Game.Board.Tile.Coordinate;

namespace TicTacToe.Core.Player {
    internal sealed class UnknownPlayer : IPlayer {
        public string Name => string.Empty;
        public string Symbol => string.Empty;        
        public ICoordinate GetNextMove() => new NoCoordinate();        
    }
}