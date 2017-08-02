using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Board.Tile {
    public class OutOfBoundsTile : ITile {
        public IPlayer Player => new UnknownPlayer();
        public int Position => 0;
        public ICoordinate Coordinate => new NoCoordinate();
        public ITile SetPlayer(IPlayer player) => this;
    }
}