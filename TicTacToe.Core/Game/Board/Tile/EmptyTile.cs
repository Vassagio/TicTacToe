using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Board.Tile {
    public class EmptyTile : ITile {
        public IPlayer Player => new UnknownPlayer();
        public int Position { get; }
        public ICoordinate Coordinate { get; }

        public EmptyTile(int position, ICoordinate coordinate)
        {
            Position = position;
            Coordinate = coordinate;
        }

        public ITile SetPlayer(IPlayer player) => this;
    }
}