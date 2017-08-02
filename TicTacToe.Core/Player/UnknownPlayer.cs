using TicTacToe.Core.Game.Board.Tile.Coordinate;

namespace TicTacToe.Core.Player {
    public class UnknownPlayer : IPlayer {
        public string Name => string.Empty;
        public string Symbol => string.Empty;
        public bool IsWinner() => false;
        public ICoordinate GetNextMove() => new NoCoordinate();
    }
}